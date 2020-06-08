using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2exmpl.Entities;

namespace test2exmpl.Configurations
{
    public class EmployeeEfConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.idEmployee);
            builder.Property(e => e.idEmployee).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Surname).IsRequired().HasMaxLength(60);
            builder.ToTable("Employee");
            builder.HasMany(e => e.Orders)
                .WithOne(o => o.Employee)
                .HasForeignKey(o => o.idEmployee)
                .IsRequired();

            var employees = new List<Employee>();
            employees.Add(new Employee
            {
                idEmployee = 1,
                Name = "Jonny",
                Surname = "James"
            }); ;
            employees.Add(new Employee
            {
                idEmployee = 2,
                Name = "Bukky",
                Surname = "Brown"
            });
            employees.Add(new Employee
            {
                idEmployee = 3,
                Name = "Adam",
                Surname = "James"
            });
            employees.Add(new Employee
            {
                idEmployee = 4,
                Name = "Sonny",
                Surname = "Ludvic"
            });
            builder.HasData(employees);
        }
    }
}
