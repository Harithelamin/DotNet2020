using ITPE3200_1_20H_nor_way.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ITPE3200_1_20H_nor_way.DAL
{
    public class Nor_Way_Context : DbContext
    {

        public Nor_Way_Context(DbContextOptions<Nor_Way_Context> options)
                : base(options)
        {
            // denne brukes for å opprette databasen fysisk dersom den ikke er opprettet
            // dette er uavhenig av initiering av databasen (seeding)
            // når man endrer på strukturen på KundeContxt her er det fornuftlig å slette denne fysisk før nye kjøringer
            Database.EnsureCreated();
        }

        public  DbSet<Station> Stations { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<Bestilling> Bestillings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Station>()
            //       .HasMany(s => s.Trips);
           // modelBuilder.Entity<Trip>()
                 //  .HasOne(t => t.DepartureStation).WithOne(t => t.Trips)
                   
            //.HasKey(t => new { t.DepartureStation, t. ArrivalStation});

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           

            // må importere pakken Microsoft.EntityFrameworkCore.Proxies
            // og legge til"viritual" på de attriuttene som ønskes å lastes automatisk (LazyLoading)
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}

