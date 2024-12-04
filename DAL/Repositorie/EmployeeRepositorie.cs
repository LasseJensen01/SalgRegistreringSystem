using DAL.Context;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorie {
    public static class EmployeeRepositorie {
        public static void AddEmployee(DTO.Model.Employee employee) {
            Employee newEmployee = Mapper.EmployeeMapper.Map(employee);
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                context.Employees.Add(newEmployee);
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
    }
}
