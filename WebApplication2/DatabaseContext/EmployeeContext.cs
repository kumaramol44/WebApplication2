using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
#pragma warning disable
namespace WebApplication2
{

    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .HasColumnName("Id");

            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Age).IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Gender).IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.ProfileImage).IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary).IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.WorkContact).IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Mobile).IsRequired();

        }
    }
}