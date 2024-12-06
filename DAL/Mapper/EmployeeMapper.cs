using DAL.Repositorie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper {
    public static class EmployeeMapper {
        public static Model.Employee Map(DTO.Model.Employee employee) {
            return new Model.Employee() {
                ID = employee.ID,
                Name = employee.Name
            };
        }
        public static List<Model.Employee> Map(List<DTO.Model.Employee> employees) {
            List<Model.Employee> mappedEmployees = new List<Model.Employee>();
            foreach (DTO.Model.Employee employee in employees) {
                mappedEmployees.Add(Map(employee));
            }
            return mappedEmployees;
        }

        public static DTO.Model.Employee Map(Model.Employee employee) {
            DTO.Model.Employee mappedEmployee = new DTO.Model.Employee(employee.Name);
            mappedEmployee.ID = employee.ID;
            mappedEmployee.DepartmentID = employee.DepartmentID.Value;
            return mappedEmployee;
        }
        public static List<DTO.Model.Employee> Map(List<Model.Employee> employees) {
            List<DTO.Model.Employee> mappedEmployees = new List<DTO.Model.Employee>();
            foreach (Model.Employee employee in employees) {
                mappedEmployees.Add(Map(employee));
            }
            return mappedEmployees;
        }
    }
}
