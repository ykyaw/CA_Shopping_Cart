using APIGateway.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.DB
{
    public class ShoppingContext:DbContext
    {
        protected IConfiguration configuration;

        public ShoppingContext(DbContextOptions<ShoppingContext> options)
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

        //below mapping to the physical relational table

        // For inheritance to work, parent and child models have be declared in our database context
        // All base and child properties reside in one table, differentiated by the ‘Discriminator’ column

        //public DbSet<Seat> Seats { get; set; }
        //public DbSet<BookedSeat> BookedSeats { get; set; }
        //public DbSet<ReservedSeat> ReservedSeats { get; set; }

        public DbSet<ExampleBooking> ExampleBookings { set; get; }
        public DbSet<ExampleMovie> ExampleMovies { set; get; }

    }
}
