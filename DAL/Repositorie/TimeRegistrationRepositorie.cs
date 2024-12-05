using DAL.Context;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorie {
    public static class TimeRegistrationRepositorie {
        public static List<TimeRegistration> GetTimeRegsByCaseID(int id) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                return Mapper.TimeRegistrationMapper.Map(context.TimeRegistrations.Where(tr => tr.CaseID == id).ToList());
            }
        }
        public static void AddTimeRegs(DTO.Model.TimeRegistration timeRegistration) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                DAL.Model.TimeRegistration tr = Mapper.TimeRegistrationMapper.Map(timeRegistration);
                context.TimeRegistrations.Add(tr);
                context.Entry(tr.Case).State = System.Data.Entity.EntityState.Unchanged;
                context.Entry(tr.Employee).State = System.Data.Entity.EntityState.Unchanged;
                context.SaveChanges();
            }
        }
    }
}
