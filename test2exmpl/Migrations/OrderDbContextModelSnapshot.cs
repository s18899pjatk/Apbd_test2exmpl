﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test2exmpl.Entities;

namespace test2exmpl.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    partial class OrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("test2exmpl.Entities.Confectionery", b =>
                {
                    b.Property<int>("IdConfectionery")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<float>("PricePerItem")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdConfectionery");

                    b.ToTable("Confectionery");

                    b.HasData(
                        new
                        {
                            IdConfectionery = 1,
                            Name = "Pink Unicorn",
                            PricePerItem = 3.5f,
                            Type = "Donut"
                        },
                        new
                        {
                            IdConfectionery = 2,
                            Name = "Corona",
                            PricePerItem = 4.3f,
                            Type = "Chockolate"
                        },
                        new
                        {
                            IdConfectionery = 3,
                            Name = "Napoleon",
                            PricePerItem = 8.2f,
                            Type = "Cake"
                        });
                });

            modelBuilder.Entity("test2exmpl.Entities.ConfectioneryOrder", b =>
                {
                    b.Property<int>("IdConfection")
                        .HasColumnType("int");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdConfection", "IdOrder");

                    b.HasIndex("IdOrder");

                    b.ToTable("Confectionery_Order");

                    b.HasData(
                        new
                        {
                            IdConfection = 1,
                            IdOrder = 3,
                            Notes = "blablabla...",
                            Quantity = 2
                        },
                        new
                        {
                            IdConfection = 2,
                            IdOrder = 1,
                            Notes = "blablabla...",
                            Quantity = 1
                        },
                        new
                        {
                            IdConfection = 3,
                            IdOrder = 2,
                            Notes = "blablabla...",
                            Quantity = 4
                        });
                });

            modelBuilder.Entity("test2exmpl.Entities.Customer", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdClient");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            IdClient = 1,
                            Name = "Bobby",
                            Surname = "Jack"
                        },
                        new
                        {
                            IdClient = 2,
                            Name = "Jack",
                            Surname = "Joe"
                        },
                        new
                        {
                            IdClient = 3,
                            Name = "Rogan",
                            Surname = "Paul"
                        });
                });

            modelBuilder.Entity("test2exmpl.Entities.Employee", b =>
                {
                    b.Property<int>("idEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("idEmployee");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            idEmployee = 1,
                            Name = "Jonny",
                            Surname = "James"
                        },
                        new
                        {
                            idEmployee = 2,
                            Name = "Bukky",
                            Surname = "Brown"
                        },
                        new
                        {
                            idEmployee = 3,
                            Name = "Adam",
                            Surname = "James"
                        },
                        new
                        {
                            idEmployee = 4,
                            Name = "Sonny",
                            Surname = "Ludvic"
                        });
                });

            modelBuilder.Entity("test2exmpl.Entities.Order", b =>
                {
                    b.Property<int>("idOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAccepted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataFinished")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("idClient")
                        .HasColumnType("int");

                    b.Property<int>("idEmployee")
                        .HasColumnType("int");

                    b.HasKey("idOrder");

                    b.HasIndex("idClient");

                    b.HasIndex("idEmployee");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            idOrder = 1,
                            DataAccepted = new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataFinished = new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "Donuts please..",
                            idClient = 1,
                            idEmployee = 2
                        },
                        new
                        {
                            idOrder = 2,
                            DataAccepted = new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataFinished = new DateTime(2020, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "Ffwww..",
                            idClient = 2,
                            idEmployee = 3
                        },
                        new
                        {
                            idOrder = 3,
                            DataAccepted = new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataFinished = new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Notes = "Data..",
                            idClient = 1,
                            idEmployee = 2
                        });
                });

            modelBuilder.Entity("test2exmpl.Entities.ConfectioneryOrder", b =>
                {
                    b.HasOne("test2exmpl.Entities.Confectionery", "Confectionery")
                        .WithMany("ConfectioneryOrders")
                        .HasForeignKey("IdConfection")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test2exmpl.Entities.Order", "Order")
                        .WithMany("ConfectioneryOrders")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("test2exmpl.Entities.Order", b =>
                {
                    b.HasOne("test2exmpl.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("idClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test2exmpl.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("idEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
