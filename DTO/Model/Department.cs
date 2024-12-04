using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model {
    public class Department {
        public int ID { get; set; }
        public string Name { get; set; }
        //Links
        public List<Case> Cases { get; set; } = new List<Case>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public Department(string name) {
            Name = name;
        }
        public Department() { }
        public override string ToString() {
            return Name;
        }
    }
}
