﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model {
    public class TimeRegistration {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Employee Employee { get; set; }

        //Forekey definition -> Employee
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        //Forekey definition -> Case
        [ForeignKey("Case")]
        public int? CaseID { get; set; }
        public Case Case { get; set; }
        public TimeRegistration(DateTime start, DateTime end, Employee employee) {
            Start = start;
            End = end;
            Employee = employee;
        }
        public TimeRegistration() { }
    }
}
