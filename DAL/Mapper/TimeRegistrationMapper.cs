using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper {
    public static class TimeRegistrationMapper {
        private static DTO.Model.TimeRegistration Map(Model.TimeRegistration tr) {
            return new DTO.Model.TimeRegistration() {
                ID = tr.ID,
                Start = tr.Start,
                End = tr.End,
                Employee = Repositorie.EmployeeRepositorie.GetEmployee(tr.EmployeeID),
            };
        }
        public static List<DTO.Model.TimeRegistration> Map(List<Model.TimeRegistration> trs) {
            List<DTO.Model.TimeRegistration> mappedTRs = new List<DTO.Model.TimeRegistration>();
            foreach (Model.TimeRegistration tr in trs) {
                mappedTRs.Add(Map(tr));
            }
            return mappedTRs;
        }
        private static Model.TimeRegistration Map(DTO.Model.TimeRegistration tr) {
            return new Model.TimeRegistration() {
                ID = tr.ID,
                Start = tr.Start,
                End = tr.End,
                Employee = EmployeeMapper.Map(tr.Employee),
                Case = CaseMapper.Map(tr.Case)
            };
        }
        public static List<Model.TimeRegistration> Map(List<DTO.Model.TimeRegistration> trs) {
            List<Model.TimeRegistration> mappedTRs = new List<Model.TimeRegistration>();
            foreach (DTO.Model.TimeRegistration tr in trs) {
                mappedTRs.Add(Map(tr));
            }
            return mappedTRs;
        }
    }
}
