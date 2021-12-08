using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plant_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plant_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plant { get; set; }

        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<PropagationEvent> PropagationEvent { get; set; }

        public DbSet<SaleEvent> SaleEvent { get; set; }

        public DbSet<TradeEvent> TradeEvent { get; set; }

        public DbSet<CareLogEvent> CareLogEvent { get; set; }

        public DbSet<WishList> WishList { get; set; }
    }
}
