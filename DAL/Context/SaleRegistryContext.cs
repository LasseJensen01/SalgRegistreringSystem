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
            // Employee -> Department (Many -> One)
            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentID)
                .WillCascadeOnDelete(false);

            //TimeRegistration -> Employee (Many -> One)
            modelBuilder.Entity<TimeRegistration>()
                .HasRequired(tr => tr.Employee)
                .WithMany() // <-- Allows for TimeRegistration to be saved on employees too
                .HasForeignKey(tr => tr.EmployeeID)
                .WillCascadeOnDelete(false);

            //TimeRegistration -> Case (Many -> One)
            modelBuilder.Entity<TimeRegistration>()
                .HasOptional(tr => tr.Case)
                .WithMany(c => c.timeRegs)
                .HasForeignKey(tr => tr.CaseID)
                .WillCascadeOnDelete(false);

            //Case -> Department (Many to One)
            modelBuilder.Entity<Case>()
                .HasOptional(c => c.Department)
                .WithMany(d => d.Cases)
                .HasForeignKey(c => c.DepartmentID)
                .WillCascadeOnDelete(false);
            // Remove the Pluralization before saving to the Database
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);


            
        }
    }
}
