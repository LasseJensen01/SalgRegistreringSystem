using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model {
    public class Department {
        public int ID { get; set; }
        public string Name { get; set; }
        //Links
        public List<Case> Cases { get; set; } = new List<Case>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public Department() { }
    }
}
