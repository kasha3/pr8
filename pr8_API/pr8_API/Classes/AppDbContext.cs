using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace pr8_API.Classes
{
    internal class AppDbContext : DbContext
    {
        public DbSet<WeatherCache> WeatherCache { get; set; }
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;port=3307;database=pr8;uid=root;pwd;", new MySqlServerVersion(new System.Version(8, 0, 11)));
        }
    }
}
