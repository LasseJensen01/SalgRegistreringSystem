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


            // Save changes and commit to Database
            context.SaveChanges();
        }

        //Dont touch dummy or the Project wont recognize the DB
        private void dummy() {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
