using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGUI.Views.ViewModels {
    public class DepartmentViewModel {
        public int SelectedDepartmentId { get; set; }
        public List<DTO.Model.Department> Departments { get; set; }
        public List<DTO.Model.Employee> Employees { get; set; }
        public List<DTO.Model.Case> Cases { get; set; }
        public string Errormsg { get; set; } = "";
    }
}