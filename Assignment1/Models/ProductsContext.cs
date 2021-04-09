using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class ProductsContext:DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Technicians> Technicians { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Countries> Country { get; set; }
        public DbSet<Incidents> Incidents { get; set; }
        public DbSet<Registrations> Registrations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductsId = 1,
                    Code = "LEAG10",
                    PName = "League Scheduler 1.0",
                    Price = 4.99M,
                    Rdate = DateTime.Now
                }
                );
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductsId = 2,
                    Code = "LEAGD10",
                    PName = "League Scheduler Deluxe 1.0",
                    Price = 7.99M,
                    Rdate = DateTime.Now
                }
                );
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductsId = 3,
                    Code = "DRAFT10",
                    PName = "Draft Manager 10",
                    Price = 4.99M,
                    Rdate = DateTime.Now
                }
                );



            modelBuilder.Entity<Technicians>().HasData(
                new Technicians
                {
                    TechniciansId = 1,
                    TName = "Wynne Tran",
                    Email = "thihoangtram.tran@georgebrown.ca",
                    Phone = "(041) 672-6767"
                }
                );

            modelBuilder.Entity<Technicians>().HasData(
                new Technicians
                {
                    TechniciansId = 2,
                    TName = "Forough Kiani",
                    Email = "kiani.forough@georgebrown.ca",
                    Phone = "(041) 672-6868"
                }
                );

            modelBuilder.Entity<Technicians>().HasData(
                new Technicians
                {
                    TechniciansId = 3,
                    TName = "Matias Herter",
                    Email = "matias.herter@georgebrown.ca",
                    Phone = "(041) 672-8888"
                }
                );

            modelBuilder.Entity<Customers>().HasData(
                new Customers
                {
                    CustomersId = 1,
                    FirstName = "Kaitlyn",
                    LastName = "Anthoni",
                    Address = "200 King",
                    City = "Toronto",
                    State = "Ontario",
                    PostalCode = "M6J 0B3",
                    CountryId = 1,
                    Email = "thihoangtram.tran@georgebrown.ca",
                    PhoneNumber = "4167221285"
                }
                );

            modelBuilder.Entity<Customers>().HasData(
                new Customers
                {
                    CustomersId = 2,
                    FirstName = "Ania ",
                    LastName = "Irvin",
                    Address = "286 King",
                    City = "Atlanta",
                    State = "Quesbec",
                    PostalCode = "M6J 111",
                    CountryId = 3,
                    Email = "",
                    PhoneNumber = "4167221285"
                }
                );

            modelBuilder.Entity<Customers>().HasData(
                new Customers
                {
                    CustomersId = 3,
                    FirstName = "Kendall ",
                    LastName = "Maya",
                    Address = "286 Richmond Hill",
                    City = "Kingdom",
                    State = "Ottawa",
                    PostalCode = "M3r 7Y6",
                    CountryId = 5,
                    Email = "abc@gmail.com",
                    PhoneNumber = "4167123456"
                }
                );

            modelBuilder.Entity<Countries>().HasData(
                new Countries { CountryId = 1, CountryName = "Canada" },
                new Countries { CountryId = 2, CountryName = "USA" },
                new Countries { CountryId = 3, CountryName = "Uk" },
                new Countries { CountryId = 4, CountryName = "China" },
                new Countries { CountryId = 5, CountryName = "Japan" },
                new Countries { CountryId = 6, CountryName = "France" },
                new Countries { CountryId = 7, CountryName = "Italia" }
            );

            modelBuilder.Entity<Incidents>().HasData(
                new Incidents
                {
                    IncidentsId = 1,
                    CustomersId = 1,
                    ProductsId = 1,
                    Title = "Congratulation !",
                    Description = "Got 100 for this assignment",
                    TechniciansId = 1,
                    DateAdded = DateTime.Now,
                    DateClosed = DateTime.Now

                }
                );
            modelBuilder.Entity<Incidents>().HasData(
                new Incidents
                {
                    IncidentsId = 2,
                    CustomersId = 2,
                    ProductsId = 2,
                    Title = "Could not install",
                    Description = "Some errors happen !",
                    TechniciansId = 2,
                    DateAdded = DateTime.Now,
                    DateClosed = null

                }
                );

            modelBuilder.Entity<Incidents>().HasData(
                new Incidents
                {
                    IncidentsId = 3,
                    CustomersId = 3,
                    ProductsId = 3,
                    Title = "Could not install",
                    Description = "Some errors happen !",
                    TechniciansId = null,
                    DateAdded = DateTime.Now,
                    DateClosed = null

                }
                );

            modelBuilder.Entity<Registrations>().HasData(
                new Registrations
                {
                    RegistrationsId = 1,
                    CustomersId = 1,
                    ProductsId = 1
                }
                );

            modelBuilder.Entity<Registrations>().HasData(
                new Registrations
                {
                    RegistrationsId = 2,
                    CustomersId = 2,
                    ProductsId = 2
                }
                );

            modelBuilder.Entity<Registrations>().HasData(
                new Registrations
                {
                    RegistrationsId = 3,
                    CustomersId = 3,
                    ProductsId = 3
                }
                );
        }


    }
}
