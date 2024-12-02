using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context {
    internal class SaleRegistryContext : DbContext {
        public SaleRegistryContext() : base("SaleRegistry") {

        }
        // Tables for the Database inserted here
        public DbSet<Case> Cases { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TimeRegistration> TimeRegistrations { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            // Remove the Pluralization before saving to the Database
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
