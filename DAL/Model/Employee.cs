using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model {
    public class Employee {

        public int ID { get; set; }
        public string Name { get; set; }
        // Links
        public Department Department { get; set; }
        [ForeignKey("Deparment")]
        public int DepartmentID { get; set; }
        public Employee() { }
    }
}
