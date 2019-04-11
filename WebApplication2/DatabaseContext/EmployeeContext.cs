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
            : base()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeContext, WebApplication2.Migrations.Configuration>());
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmpSubject> Subjects { get; set; }



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

            modelBuilder.Entity<Employee>()
                .Property(e => e.Mobile).IsRequired();

            modelBuilder.Entity<EmpSubject>()
                .Property(e => e.Id)
                .HasColumnName("Id");


            modelBuilder.Entity<EmpSubject>()
                .HasRequired<Employee>(s => s.Employee)
                .WithMany(g => g.Subjects)
                .HasForeignKey<int>(s => s.EmployeeId);
        }
    }
}