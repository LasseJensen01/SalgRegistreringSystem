using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Context {
    internal class SaleRegistryInitializer: CreateDatabaseIfNotExists<SaleRegistryContext> {
        protected override void Seed(SaleRegistryContext context) {
            // Init Data can be made here

            // Departments
            Department prod = new Department() {
                Name = "Production",
            };
            prod.Cases.Add(new Case("Default", ""));
            Department manage = new Department() {
                Name = "Management",
            };
            manage.Cases.Add(new Case("Default", ""));
            Department hr = new Department() {
                Name = "Human Ressources",
            };
            hr.Cases.Add(new Case("Default", ""));

            // Cases
            Case impAI = new Case() {
                Name = "Implementation of AI",
                Description = "Implementation of AI across the business"
            };
            prod.Cases.Add(impAI);
            Case devops = new Case() {
                Name = "Dev-Ops",
                Description = "Planning of future development"
            };
            manage.Cases.Add(devops);
            Case hiring = new Case() {
                Name = "New Hires",
                Description = "The hunt for new Hires"
            };
            hr.Cases.Add(hiring);

            //Employees
            Employee john = new Employee() {
                Name = "John Doe",
                Department = prod
            };
            Employee billy = new Employee() {
                Name = "Billy Bob",
                Department = prod
            };
            Employee Jane = new Employee() {
                Name = "Jane Doe",
                Department = prod
            };
            Employee tony = new Employee() {
                Name = "Tony Stark",
                Department = manage
            };

            // Assign Employees to Departments
            prod.Employees.Add(john);
            prod.Employees.Add(billy);
            prod.Employees.Add(Jane);
            manage.Employees.Add(tony);
            // Create TimeRegistration
            TimeRegistration tr1 = new TimeRegistration() {
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(8),
                Employee = john
            };
            impAI.timeRegs.Add(tr1);

            TimeRegistration tr2 = new TimeRegistration() {
                Start = DateTime.Parse("06-12-2020 10:00:00"),
                End = DateTime.Parse("06-12-2020 17:00:00"),
                Employee = tony
            };
            devops.timeRegs.Add(tr2);

            TimeRegistration tr3 = new TimeRegistration() {
                Start = DateTime.Now.AddDays(-14),
                End = DateTime.Now.AddDays(-14).AddHours(4),
                Employee = john
            };
            impAI.timeRegs.Add(tr3);

            TimeRegistration tr4 = new TimeRegistration() {
                Start = DateTime.Now.AddDays(-40),
                End = DateTime.Now.AddDays(-40).AddHours(8),
                Employee = john
            };
            impAI.timeRegs.Add(tr4);


            // Add data to DB
            context.Departments.Add(hr);
            context.Departments.Add(prod);
            context.Departments.Add(manage);


            // Save changes and commit to Database
            context.SaveChanges();
        }

        //Dont touch dummy or the Project wont recognize the DB
        private void dummy() {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
