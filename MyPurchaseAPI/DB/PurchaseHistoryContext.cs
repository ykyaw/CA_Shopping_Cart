using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyPurchaseAPI.Models;

namespace MyPurchaseAPI.DB
{
    public class PurchaseHistoryContext:DbContext
    {
        protected IConfiguration configuration;

        public PurchaseHistoryContext(DbContextOptions<PurchaseHistoryContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            //// unique name within a column
            //model.Entity<Cinema>().HasIndex(tbl => tbl.Name).IsUnique();

            //// composite keys
            //model.Entity<Seat>().HasAlternateKey(tbl =>
            //    new { tbl.ScreeningId, tbl.Row, tbl.Col }
            //);
        }

        public DbSet<PurchaseHistory> PurchaseHistories { set; get; }
        public DbSet<PurchaseActivationCode> PurchaseActivationCodes { set; get; }
    }
}
