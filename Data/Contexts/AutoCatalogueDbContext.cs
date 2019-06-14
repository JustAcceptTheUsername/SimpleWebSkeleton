using AutoCatalogue.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoCatalogue.Contexts
{
    public class AutoCatalogueDbContext : DbContext
    {
        public AutoCatalogueDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> Types { get; set; }
        public DbSet<Make> Makes { get; set; }
    }
}