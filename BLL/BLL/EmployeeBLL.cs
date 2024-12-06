using DAL.Repositorie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL {
    public static class EmployeeBLL{
        public static DTO.Model.Employee GetEmployee(int id) {
            return DAL.Repositorie.EmployeeRepositorie.GetEmployee(id);
        }
        public static List<DTO.Model.Employee> GetEmployeesByDepID(int id) {
            return DAL.Repositorie.EmployeeRepositorie.GetEmployeesByDeptID(id);
        }
        public static List<DTO.Model.Employee> GetAllEmployees() {
            return DAL.Repositorie.EmployeeRepositorie.GetAllEmployees();
        }
        public static void CreateEmployee(string name, int depID) {
            EmployeeRepositorie.AddEmployee(name, depID);
        }
        public static void UpdateEmployee(int empID, string name, int depID) {
            EmployeeRepositorie.UpdateEmployee(empID, name, depID);
        }
    }
}
