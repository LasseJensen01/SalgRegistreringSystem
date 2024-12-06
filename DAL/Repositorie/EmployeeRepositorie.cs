using DAL.Context;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorie {
    public static class EmployeeRepositorie {
        public static void AddEmployee(string name, int depID) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                var em = new Model.Employee(name);
                em.DepartmentID = depID;
                context.Employees.Add(em);
                context.SaveChanges();
            }
        }
        public static DTO.Model.Employee GetEmployee(int id) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                Employee employee = context.Employees.Find(id);
                return Mapper.EmployeeMapper.Map(employee);
            }
        }
        public static List<DTO.Model.Employee> GetEmployeesByDeptID(int ID) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                return Mapper.EmployeeMapper.Map(context.Employees.Where(e => e.DepartmentID == ID).ToList());
            }
        }
        public static List<DTO.Model.Employee> GetAllEmployees() {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                return Mapper.EmployeeMapper.Map(context.Employees.ToList());
            }
        }
        public static void UpdateEmployee(int empID, string name, int depID) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                var emp = context.Employees.FirstOrDefault(e => e.ID == empID);
                emp.Name = name;
                emp.DepartmentID = depID;
                context.SaveChanges();
            }
        }

    }
}
