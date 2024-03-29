﻿// <auto-generated />
using System;
using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment1.Migrations
{
    [DbContext(typeof(ProductsContext))]
    partial class ProductsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Assignment1.Models.Countries", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "Canada"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "USA"
                        },
                        new
                        {
                            CountryId = 3,
                            CountryName = "Uk"
                        },
                        new
                        {
                            CountryId = 4,
                            CountryName = "China"
                        },
                        new
                        {
                            CountryId = 5,
                            CountryName = "Japan"
                        },
                        new
                        {
                            CountryId = 6,
                            CountryName = "France"
                        },
                        new
                        {
                            CountryId = 7,
                            CountryName = "Italia"
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Customers", b =>
                {
                    b.Property<int>("CustomersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomersId");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomersId = 1,
                            Address = "200 King",
                            City = "Toronto",
                            CountryId = 1,
                            Email = "thihoangtram.tran@georgebrown.ca",
                            FirstName = "Kaitlyn",
                            LastName = "Anthoni",
                            PhoneNumber = "4167221285",
                            PostalCode = "M6J 0B3",
                            State = "Ontario"
                        },
                        new
                        {
                            CustomersId = 2,
                            Address = "286 King",
                            City = "Atlanta",
                            CountryId = 3,
                            Email = "",
                            FirstName = "Ania ",
                            LastName = "Irvin",
                            PhoneNumber = "4167221285",
                            PostalCode = "M6J 111",
                            State = "Quesbec"
                        },
                        new
                        {
                            CustomersId = 3,
                            Address = "286 Richmond Hill",
                            City = "Kingdom",
                            CountryId = 5,
                            Email = "abc@gmail.com",
                            FirstName = "Kendall ",
                            LastName = "Maya",
                            PhoneNumber = "4167123456",
                            PostalCode = "M3r 7Y6",
                            State = "Ottawa"
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Incidents", b =>
                {
                    b.Property<int>("IncidentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int?>("TechniciansId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentsId");

                    b.HasIndex("CustomersId");

                    b.HasIndex("ProductsId");

                    b.HasIndex("TechniciansId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentsId = 1,
                            CustomersId = 1,
                            DateAdded = new DateTime(2021, 4, 9, 13, 53, 36, 272, DateTimeKind.Local).AddTicks(498),
                            DateClosed = new DateTime(2021, 4, 9, 13, 53, 36, 272, DateTimeKind.Local).AddTicks(979),
                            Description = "Got 100 for this assignment",
                            ProductsId = 1,
                            TechniciansId = 1,
                            Title = "Congratulation !"
                        },
                        new
                        {
                            IncidentsId = 2,
                            CustomersId = 2,
                            DateAdded = new DateTime(2021, 4, 9, 13, 53, 36, 272, DateTimeKind.Local).AddTicks(2343),
                            Description = "Some errors happen !",
                            ProductsId = 2,
                            TechniciansId = 2,
                            Title = "Could not install"
                        },
                        new
                        {
                            IncidentsId = 3,
                            CustomersId = 3,
                            DateAdded = new DateTime(2021, 4, 9, 13, 53, 36, 272, DateTimeKind.Local).AddTicks(2372),
                            Description = "Some errors happen !",
                            ProductsId = 3,
                            Title = "Could not install"
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Products", b =>
                {
                    b.Property<int>("ProductsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Rdate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductsId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductsId = 1,
                            Code = "LEAG10",
                            PName = "League Scheduler 1.0",
                            Price = 4.99m,
                            Rdate = new DateTime(2021, 4, 9, 13, 53, 36, 269, DateTimeKind.Local).AddTicks(2240)
                        },
                        new
                        {
                            ProductsId = 2,
                            Code = "LEAGD10",
                            PName = "League Scheduler Deluxe 1.0",
                            Price = 7.99m,
                            Rdate = new DateTime(2021, 4, 9, 13, 53, 36, 270, DateTimeKind.Local).AddTicks(6916)
                        },
                        new
                        {
                            ProductsId = 3,
                            Code = "DRAFT10",
                            PName = "Draft Manager 10",
                            Price = 4.99m,
                            Rdate = new DateTime(2021, 4, 9, 13, 53, 36, 270, DateTimeKind.Local).AddTicks(7024)
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Registrations", b =>
                {
                    b.Property<int>("RegistrationsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("RegistrationsId");

                    b.HasIndex("CustomersId");

                    b.HasIndex("ProductsId");

                    b.ToTable("Registrations");

                    b.HasData(
                        new
                        {
                            RegistrationsId = 1,
                            CustomersId = 1,
                            ProductsId = 1
                        },
                        new
                        {
                            RegistrationsId = 2,
                            CustomersId = 2,
                            ProductsId = 2
                        },
                        new
                        {
                            RegistrationsId = 3,
                            CustomersId = 3,
                            ProductsId = 3
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Technicians", b =>
                {
                    b.Property<int>("TechniciansId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechniciansId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechniciansId = 1,
                            Email = "thihoangtram.tran@georgebrown.ca",
                            Phone = "(041) 672-6767",
                            TName = "Wynne Tran"
                        },
                        new
                        {
                            TechniciansId = 2,
                            Email = "kiani.forough@georgebrown.ca",
                            Phone = "(041) 672-6868",
                            TName = "Forough Kiani"
                        },
                        new
                        {
                            TechniciansId = 3,
                            Email = "matias.herter@georgebrown.ca",
                            Phone = "(041) 672-8888",
                            TName = "Matias Herter"
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Customers", b =>
                {
                    b.HasOne("Assignment1.Models.Countries", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Assignment1.Models.Incidents", b =>
                {
                    b.HasOne("Assignment1.Models.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment1.Models.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment1.Models.Technicians", "Technician")
                        .WithMany()
                        .HasForeignKey("TechniciansId");

                    b.Navigation("Customers");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("Assignment1.Models.Registrations", b =>
                {
                    b.HasOne("Assignment1.Models.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment1.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
