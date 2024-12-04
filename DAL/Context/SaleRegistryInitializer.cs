using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context {
    internal class SaleRegistryInitializer: CreateDatabaseIfNotExists<SaleRegistryContext> {
        protected override void Seed(SaleRegistryContext context) {
            // Init Data can be made here
            Department prod = new Department() {
                Name = "Production",
                ID = 1
            };
            Case gruntWork = new Case() {
                Name = "Grunt Work",
                Description = "Do gruntwork nerds"
            };
            prod.Cases.Add(gruntWork);
            Employee lucas = new Employee() {
                Name = "Lucas",
                Department = prod
            };
            Employee lasse = new Employee() {
                Name = "Lasse",
                Department = prod
            };
            Employee simon = new Employee() {
                Name = "Simon",
                Department = prod
            };
            prod.Employees.Add(lucas);
            prod.Employees.Add(lasse);
            prod.Employees.Add(simon);
            TimeRegistration tr = new TimeRegistration() {
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(8),
                Employee = lucas
            };
            gruntWork.timeRegs.Add(tr);
            context.Departments.Add(prod);
            //context.Employees.Add(lucas);


            // Save changes and commit to Database
            context.SaveChanges();
        }

        //Dont touch dummy or the Project wont recognize the DB
        private void dummy() {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
