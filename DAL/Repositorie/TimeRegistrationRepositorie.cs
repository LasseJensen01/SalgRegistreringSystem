using DAL.Context;
using DAL.Model;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorie {
    public static class TimeRegistrationRepositorie {
        public static List<DTO.Model.TimeRegistration> GetTimeRegsByCaseID(int id) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                return Mapper.TimeRegistrationMapper.Map(context.TimeRegistrations.Where(tr => tr.CaseID == id).ToList());
            }
        }
        public static List<DTO.Model.TimeRegistration> GetTimeRegsByEmployeeID(int id) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                return Mapper.TimeRegistrationMapper.Map(context.TimeRegistrations.Where(tr => tr.EmployeeID == id).ToList());
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
        public static void UpdateTimeReg(int trID, DateTime start, DateTime end, int employeeID) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                var tr = context.TimeRegistrations.FirstOrDefault(t => t.ID == trID);
                tr.Start = start;
                tr.End = end;
                tr.EmployeeID = employeeID;
                context.SaveChanges();
            }
        }
    }
}
