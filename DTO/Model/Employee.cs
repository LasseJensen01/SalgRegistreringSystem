using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model {
    public class Employee {
        public int ID { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public int DepartmentID { get; set; }
        public Employee(string name) {
            Name = name;
        }
        public Employee() { }

        public override string ToString() {
            return Name;
        }
    }
}
