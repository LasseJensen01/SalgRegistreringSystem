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
    }
}
