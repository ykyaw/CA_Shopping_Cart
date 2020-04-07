using APIGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.DB
{
    public class DBSeeder
    {
        public DBSeeder(ShoppingContext dbcontext)
        {
            // Create movies
            ExampleMovie movie1 = new ExampleMovie();
            movie1.Id = Guid.NewGuid().ToString();
            movie1.Title = "Good Will Hunting";
            dbcontext.Add(movie1);

            ExampleMovie movie2 = new ExampleMovie();
            movie2.Id = Guid.NewGuid().ToString();
            movie2.Title = "Men In Black";
            dbcontext.Add(movie2);

            // Book movie
            ExampleBooking booking1 = new ExampleBooking();
            booking1.Id = Guid.NewGuid().ToString();
            booking1.MovieId = movie1.Id;
            booking1.UtcTimestamp = DateTime.UtcNow;
            dbcontext.Add(booking1);

            dbcontext.SaveChanges();
        }
    }
}
