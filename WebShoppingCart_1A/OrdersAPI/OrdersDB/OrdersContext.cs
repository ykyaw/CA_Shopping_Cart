using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrdersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersAPI.OrdersDB
{


    public class OrdersContext : DbContext
    {
        protected IConfiguration configuration;

        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            // model.Entity<Useraccount>().HasIndex(model => model.email).IsUnique();

        }
        public DbSet<Orders> Orders_tbl { get; set; }

    }



}
