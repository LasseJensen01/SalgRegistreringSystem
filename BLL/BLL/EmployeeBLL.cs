using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL {
    public static class EmployeeBLL{
        public static void CreateEmployee() {
            throw new NotImplementedException();
        }
        public static void UpdateEmployee() {
            throw new NotImplementedException();
        }
        public static void DeleteEmployee() {
            throw new NotImplementedException();
        }
        public static DTO.Model.Employee GetEmployee(int id) {
            return DAL.Repositorie.EmployeeRepositorie.GetEmployee(id);
        }
        public static void GetEmployees() {
            throw new NotImplementedException();
        }
    }
}
