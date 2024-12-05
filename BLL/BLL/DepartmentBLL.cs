using DAL.Model;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL {
    public static class DepartmentBLL {
        public static List<DTO.Model.Department> GetDepartments() {
            return DAL.Repositorie.DepartmentRepositorie.GetDepartments();
        }
    }
}
