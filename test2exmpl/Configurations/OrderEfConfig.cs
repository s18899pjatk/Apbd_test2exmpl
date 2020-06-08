using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2exmpl.Entities;

namespace test2exmpl.Configurations
{
    public class OrderEfConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.idOrder);
            builder.Property(o => o.idOrder).ValueGeneratedOnAdd();
            builder.Property(o => o.DataAccepted).IsRequired();
            builder.Property(o => o.Notes).IsRequired().HasMaxLength(255);
            builder.ToTable("Order");

            var orders = new List<Order>();
            orders.Add(new Order
            {
                idOrder = 1,
                DataAccepted = new DateTime(2020, 1, 2),
                DataFinished = new DateTime(2020, 1, 3),
                Notes = "Donuts please..",
                idClient = 1,
                idEmployee = 2
            });
            orders.Add(new Order
            {
                idOrder = 2,
                DataAccepted = new DateTime(2020, 1, 3),
                DataFinished = new DateTime(2020, 1, 4),
                Notes = "Ffwww..",
                idClient = 2,
                idEmployee = 3
            });
            orders.Add(new Order
            {
                idOrder = 3,
                DataAccepted = new DateTime(2020, 2, 2),
                DataFinished = new DateTime(2020, 2, 5),
                Notes = "Data..",
                idClient = 1,
                idEmployee = 2
            });
            builder.HasData(orders);
        }
    }
}
