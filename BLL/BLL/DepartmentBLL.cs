﻿using DAL.Model;
using DAL.Repositorie;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL {
    public static class DepartmentBLL {
        public static List<DTO.Model.Department> GetDepartments() {
            return DAL.Repositorie.DepartmentRepositorie.GetDepartments();
        }
        public static void CreateDepartment(string name) {
            DepartmentRepositorie.CreateDepartment(name);
        }
        public static void UpdateDepartment(string name, int depID) {
            DepartmentRepositorie.UpdateDepartment(name, depID);
        }
    }
}
