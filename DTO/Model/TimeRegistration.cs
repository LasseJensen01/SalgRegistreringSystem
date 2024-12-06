using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model {
    public class TimeRegistration {
        public int ID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        //Links
        public Employee Employee { get; set; }
        public Case Case { get; set; }
        public TimeRegistration(DateTime start, DateTime end, Employee employee) {
            Start = start;
            End = end;
            Employee = employee;
        }
        public TimeRegistration() { }

        public override string ToString() {
            TimeSpan time = End - Start;
            return Employee.Name + ": " + time.Hours + " Hr " + time.Minutes + " Min";
        }
    }
}
