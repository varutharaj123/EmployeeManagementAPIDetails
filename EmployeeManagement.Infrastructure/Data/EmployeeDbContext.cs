using System.Collections.Generic;
using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Data
{
    public class EmployeeDbContext : DbContext
    {


        public EmployeeDbContext(
        DbContextOptions<EmployeeDbContext> options)
        : base(options)
        {

        }



        public DbSet<Employee> Employees { get; set; }



        protected override void OnModelCreating(
        ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Employee>()
            .HasKey(x => x.EmployeeId);



            modelBuilder.Entity<Employee>()
            .Property(x => x.EmployeeName)
            .HasMaxLength(100)
            .IsRequired();



            modelBuilder.Entity<Employee>()
            .Property(x => x.Email)
            .HasMaxLength(150)
            .IsRequired();



        }

    }
}
