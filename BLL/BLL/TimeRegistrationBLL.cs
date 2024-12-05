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
    }
}
