using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebGUI.Views.ViewModels;

namespace WebGUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Department> d = BLL.BLL.DepartmentBLL.GetDepartments();
            ViewBag.Departments = new SelectList(d, "Name");

            int selectedDepartmentID = d.FirstOrDefault().ID;

            var viewModel = new DepartmentViewModel() {
                Cases = BLL.BLL.CaseBLL.GetCasesByDepID(selectedDepartmentID),
                Employees = BLL.BLL.EmployeeBLL.GetEmployeesByDepID(selectedDepartmentID),
                Departments = d
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(int selectedDepartmentID) {
            List<Department> d = BLL.BLL.DepartmentBLL.GetDepartments();
            ViewBag.Departments = new SelectList(d, "ID", "Name");

            var viewModel = new DepartmentViewModel() {
                Cases = BLL.BLL.CaseBLL.GetCasesByDepID(selectedDepartmentID),
                Employees = BLL.BLL.EmployeeBLL.GetEmployeesByDepID(selectedDepartmentID),
                Departments = d
            };
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult SubmitTimeRegistration(string startTime, DateTime? startDate, string endTime, DateTime? endDate, int? selectedEmployeeID, int? selectedCaseID) {

            //Define Viewmodel from start in case of errors

            List<Department> d = BLL.BLL.DepartmentBLL.GetDepartments();
            int selectedDepartmentID = d.FirstOrDefault().ID;
            var viewModel = new DepartmentViewModel() {
                Cases = BLL.BLL.CaseBLL.GetCasesByDepID(selectedDepartmentID),
                Employees = BLL.BLL.EmployeeBLL.GetEmployeesByDepID(selectedDepartmentID),
                Departments = d,
                Errormsg = ""
            };
            //Checks if Empoyee and case has been checked and arent null
            if (selectedEmployeeID == null || selectedCaseID == null) {
                viewModel.Errormsg = "Error: Employee or Case not checked";
                return View("Index", viewModel);
            }

            // Check and parse times
            if (startDate.HasValue && !string.IsNullOrEmpty(startTime) &&
                endDate.HasValue && !string.IsNullOrEmpty(endTime)) {
                DateTime start = ParseTotalDateTime(startTime, startDate);
                DateTime end = ParseTotalDateTime(endTime, endDate);
                //Checks if datetime is a valid input
                if (start > end) {
                    viewModel.Errormsg = "Error: Invalid datetime";
                    return View("Index",viewModel);
                }
                TimeSpan sum = end - start;
                //Checks if a timereg is above 1 day as such is invalid
                if (sum.Days > 0) {
                    viewModel.Errormsg = "Error: Timeregistrations limited to less than 24 hours";
                    return View("Index", viewModel);
                }
                Employee e = BLL.BLL.EmployeeBLL.GetEmployee(selectedEmployeeID.Value);
                Case c = BLL.BLL.CaseBLL.GetCase(selectedCaseID.Value);
                BLL.BLL.TimeRegistrationBLL.AddTimeRegistration(start, end, e, c);
            }

            ViewBag.Departments = new SelectList(d, "Name");
            return View("Index", viewModel);
        }

        private DateTime ParseTotalDateTime(string hourMin, DateTime? date) {
            DateTime parsedStartTime;
            if (DateTime.TryParse(hourMin, out var parsedTime)) {
                parsedStartTime = new DateTime(
                    date.Value.Year,
                    date.Value.Month,
                    date.Value.Day,
                    parsedTime.Hour,
                    parsedTime.Minute,
                    parsedTime.Second
                    );
                return parsedStartTime;
            }
            return new DateTime();
        }
    }
}