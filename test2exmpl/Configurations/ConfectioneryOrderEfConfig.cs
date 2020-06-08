using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2exmpl.Entities;

namespace test2exmpl.Configurations
{
    public class ConfectioneryOrderEfConfig : IEntityTypeConfiguration<ConfectioneryOrder>
    {
        public void Configure(EntityTypeBuilder<ConfectioneryOrder> builder)
        {
            builder.HasKey(co => new { co.IdConfection, co.IdOrder });
            builder.Property(co => co.Quantity).IsRequired();
            builder.Property(co => co.Notes).IsRequired().HasMaxLength(255);
            builder.ToTable("Confectionery_Order");
            builder.HasOne(c => c.Confectionery)
                .WithMany(co => co.ConfectioneryOrders)
                .HasForeignKey(co => co.IdConfection);
            builder.HasOne(o => o.Order)
               .WithMany(co => co.ConfectioneryOrders)
               .HasForeignKey(co => co.IdOrder);

            var confectioneryOrders = new List<ConfectioneryOrder>();
            confectioneryOrders.Add(new ConfectioneryOrder
            {
                IdConfection = 1,
                IdOrder = 3,
                Quantity = 2,
                Notes = "blablabla..."
            });
            confectioneryOrders.Add(new ConfectioneryOrder
            {
                IdConfection = 2,
                IdOrder = 1,
                Quantity = 1,
                Notes = "blablabla..."
            });
            confectioneryOrders.Add(new ConfectioneryOrder
            {
                IdConfection = 3,
                IdOrder = 2,
                Quantity = 4,
                Notes = "blablabla..."
            });

            builder.HasData(confectioneryOrders);
        }
    }
}
