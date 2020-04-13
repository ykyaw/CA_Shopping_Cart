using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountAPI.Models;

namespace AccountAPI.DB
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Useraccount>().HasIndex(model => model.Email).IsUnique();

        }
        public DbSet<Useraccount> UserAccount_tbl { get; set; }

    }


}
