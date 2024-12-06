using DAL.Repositorie;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL {
    public static class CaseBLL {
        public static List<DTO.Model.Case> GetCasesByDepID(int id) {
            return DAL.Repositorie.CaseRepositorie.GetCasesByDepID(id);
        }

        public static Case GetCase(int id) {
            return DAL.Repositorie.CaseRepositorie.GetCase(id);
        }

        public static void CreateCase(string name, string description, int depID) {
            CaseRepositorie.CreateCase(name, description, depID);
        }
        public static void UpdateCase(string name, int caseID) {
            CaseRepositorie.UpdateCase(name, caseID);
        }
    }
}
