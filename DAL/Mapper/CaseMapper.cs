using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper {
    public static class CaseMapper {
        public static DTO.Model.Case Map(Model.Case c) {
            return new DTO.Model.Case() {
                ID = c.ID,
                Name = c.Name,
                Description = c.Description,
                timeRegs = TimeRegistrationMapper.Map(c.timeRegs),
            };
        }
        public static List<DTO.Model.Case> Map(List<Model.Case> cs) {
            List<DTO.Model.Case> mappedCases = new List<DTO.Model.Case>();
            foreach (Model.Case c in cs) {
                mappedCases.Add(Map(c));
            }
            return mappedCases;
        }
        public static Model.Case Map(DTO.Model.Case c) {
            return new Model.Case() {
                ID = c.ID,
                Name = c.Name,
                Description = c.Description,
                timeRegs = TimeRegistrationMapper.Map(c.timeRegs),
            };
        }
    }
}
