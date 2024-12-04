using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model {
    public class Case {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TimeRegistration> timeRegs { get; set; } = new List<TimeRegistration>();

        //ForeignKeys -> Department
        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }
        public Department Department { get; set; }
        public Case(string name, string description) {
            Name = name;
            Description = description;
        }
        public Case() { }
    }
}
