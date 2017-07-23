using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApplication9.Models
{
    public class PortContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Cattegories { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connString = Startup.Configuration["Data:PortContextConnection"];
            options.UseSqlServer(connString);
            base.OnConfiguring(options);
        }
    }
}
