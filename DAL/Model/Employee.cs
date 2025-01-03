﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model {
    public class Employee {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        //Foreignkey definition -> Department
        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }
        public Department Department { get; set; }
        public Employee(string name) {
            Name = name;
        }
        public Employee() { }
    }
}
