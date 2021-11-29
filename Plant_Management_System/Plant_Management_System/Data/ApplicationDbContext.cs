using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Plant_Management_System.Models;

namespace Plant_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Plant> Plant { get; set; }
        public DbSet<Plant_Management_System.Models.WishList> WishList { get; set; }
        public DbSet<Plant_Management_System.Models.Trade> Trade { get; set; }
        public DbSet<Plant_Management_System.Models.Sale> Sale { get; set; }
        public DbSet<Plant_Management_System.Models.User> User { get; set; }
        public DbSet<CareLog> CareLog { get; set; }
        public DbSet<Propogation> Propogation { get; set; }
    }
}
