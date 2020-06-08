using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2exmpl.Configurations;

namespace test2exmpl.Entities
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Confectionery> Confectioneries { get; set; }
        public DbSet<ConfectioneryOrder> ConfectioneryOrders { get; set; }

        public OrderDbContext()
        {

        }

        public OrderDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConfectioneryEfConfig());
            modelBuilder.ApplyConfiguration(new ConfectioneryOrderEfConfig());
            modelBuilder.ApplyConfiguration(new CustomerEfConfig());
            modelBuilder.ApplyConfiguration(new EmployeeEfConfig());
            modelBuilder.ApplyConfiguration(new OrderEfConfig());
        }
    }
}
