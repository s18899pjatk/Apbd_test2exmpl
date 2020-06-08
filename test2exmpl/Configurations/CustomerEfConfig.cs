using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2exmpl.Entities;

namespace test2exmpl.Configurations
{
    public class CustomerEfConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.IdClient);
            builder.Property(c => c.IdClient).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Surname).IsRequired().HasMaxLength(60);
            builder.ToTable("Customer");
            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.idClient)
                .IsRequired();

            var customers = new List<Customer>();
            customers.Add(new Customer()
            {
                IdClient = 1,
                Name = "Bobby",
                Surname = "Jack",
            });
            customers.Add(new Customer()
            {
                IdClient = 2,
                Name = "Jack",
                Surname = "Joe",
            });
            customers.Add(new Customer()
            {
                IdClient = 3,
                Name = "Rogan",
                Surname = "Paul",
            });
            builder.HasData(customers);
        }
    }
}
