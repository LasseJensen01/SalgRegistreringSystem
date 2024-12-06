using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorie {
    public static class DepartmentRepositorie {
        public static DTO.Model.Department GetDepartment(int? id) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                return Mapper.DepartmentMapper.Map(context.Departments.Find(id));
            }
        }
        public static List<DTO.Model.Department> GetDepartments() {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                return Mapper.DepartmentMapper.Map(context.Departments.ToList());
            }
        }
        public static void CreateDepartment(string name) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                var dep = new Model.Department(name);
                dep.Cases.Add(new Model.Case("Default", ""));
                context.Departments.Add(dep);
                context.SaveChanges();
            }
        }
    }
}
