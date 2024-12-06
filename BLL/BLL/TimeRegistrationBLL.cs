using DAL.Repositorie;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL {
    public static class TimeRegistrationBLL {
        public static void AddTimeRegistration(DateTime start, DateTime end, Employee employee, Case c) {
            DTO.Model.TimeRegistration tr = new TimeRegistration(start, end, employee);
            tr.Case = c;
            TimeRegistrationRepositorie.AddTimeRegs(tr);
        }
        public static List<DTO.Model.TimeRegistration> GetByCaseID(int id) {
            return TimeRegistrationRepositorie.GetTimeRegsByCaseID(id);
        }

        public static List<DTO.Model.TimeRegistration> GetByEmployeeID(int id) {
            return TimeRegistrationRepositorie.GetTimeRegsByEmployeeID(id);
        }

        public static void Update(int trID, DateTime start, DateTime end, int employeeID) {
            TimeRegistrationRepositorie.UpdateTimeReg(trID, start, end, employeeID);
        }
    }
}
