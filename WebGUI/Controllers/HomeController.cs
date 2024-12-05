using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult SubmitTimeRegistration(string startTime, DateTime? startDate, string endTime, DateTime? endDate, int? selectedEmployeeID, int? selectedDepartmentID, int? selectedCaseID) {
            if (startDate.HasValue && !string.IsNullOrEmpty(startTime) &&
                endDate.HasValue && !string.IsNullOrEmpty(endTime)) {
                DateTime start = ParseTotalDateTime(startTime, startDate);
                DateTime end = ParseTotalDateTime(endTime, endDate);
                Employee e = BLL.BLL.EmployeeBLL.GetEmployee(selectedEmployeeID.Value);
                Case c = BLL.BLL.CaseBLL.GetCase(selectedCaseID.Value);
                BLL.BLL.TimeRegistrationBLL.AddTimeRegistration(start, end, e, c);
            }

            List<Department> d = BLL.BLL.DepartmentBLL.GetDepartments();
            ViewBag.Departments = new SelectList(d, "Name");

            selectedDepartmentID = d.FirstOrDefault().ID;

            var viewModel = new DepartmentViewModel() {
                Cases = BLL.BLL.CaseBLL.GetCasesByDepID(selectedDepartmentID.Value),
                Employees = BLL.BLL.EmployeeBLL.GetEmployeesByDepID(selectedDepartmentID.Value),
                Departments = d
            };

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