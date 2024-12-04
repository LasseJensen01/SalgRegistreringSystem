using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model {
    public class Case {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Links
        public List<TimeRegistration> timeRegs { get; set; } = new List<TimeRegistration>();
        public Department Department { get; set; }
        public Case(string name, string description) {
            Name = name;
            Description = description;
        }
        public Case() { }
    }
}
