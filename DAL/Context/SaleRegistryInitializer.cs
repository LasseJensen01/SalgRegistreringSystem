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
            Employee lucas = new Employee() {
                Name = "Lucas",
                ID = 1,
                Department = prod,
            };
            context.Departments.Add(prod);
            context.Employees.Add(lucas);


            // Save changes and commit to Database
            context.SaveChanges();
        }

        //Dont touch dummy or the Project wont recognize the DB
        private void dummy() {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
