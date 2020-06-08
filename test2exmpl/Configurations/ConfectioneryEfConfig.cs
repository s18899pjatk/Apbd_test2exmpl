using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2exmpl.Entities;

namespace test2exmpl.Configurations
{
    public class ConfectioneryEfConfig : IEntityTypeConfiguration<Confectionery>
    {
        public void Configure(EntityTypeBuilder<Confectionery> builder)
        {
            builder.HasKey(c => c.IdConfectionery);
            builder.Property(c => c.IdConfectionery).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            builder.Property(c => c.PricePerItem).IsRequired();
            builder.Property(c => c.Type).HasMaxLength(40);
            builder.ToTable("Confectionery");

            var confectioneries = new List<Confectionery>();
            confectioneries.Add(new Confectionery
            {
                IdConfectionery = 1,
                Name = "Pink Unicorn",
                Type = "Donut",
                PricePerItem = 3.50F
            });
            confectioneries.Add(new Confectionery
            {
                IdConfectionery = 2,
                Name = "Corona",
                Type = "Chockolate",
                PricePerItem = 4.30F
            });
            confectioneries.Add(new Confectionery
            {
                IdConfectionery = 3,
                Name = "Napoleon",
                Type = "Cake",
                PricePerItem = 8.20F
            });
            builder.HasData(confectioneries);
        }
    }
}
