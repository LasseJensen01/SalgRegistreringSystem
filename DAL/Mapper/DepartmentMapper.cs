using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper {
    public static class DepartmentMapper {
        public static DTO.Model.Department Map(Department department) {
            return new DTO.Model.Department() {
                ID = department.ID,
                Name = department.Name,
                Cases = Repositorie.CaseRepositorie.GetCasesByDepID(department.ID),
                Employees = Repositorie.EmployeeRepositorie.GetEmployeesByDeptID(department.ID)
            };
        }

        public static List<DTO.Model.Department> Map(List<Model.Department> deps) {
            List<DTO.Model.Department> mappedDeps = new List<DTO.Model.Department>();
            foreach (Model.Department dep in deps) {
                mappedDeps.Add(Map(dep));
            }
            return mappedDeps;
        }
    }
}
