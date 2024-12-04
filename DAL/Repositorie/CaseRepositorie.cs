using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorie {
    public static class CaseRepositorie {
        public static DTO.Model.Case GetCase(int id) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                return Mapper.CaseMapper.Map(context.Cases.Find(id));
            }
        }
        public static List<DTO.Model.Case> GetCasesByDepID(int id) {
            using (SaleRegistryContext context = new SaleRegistryContext()) {
                return Mapper.CaseMapper.Map(context.Cases.Where(c => c.DepartmentID == id).ToList());
            }
        }
    }
}
