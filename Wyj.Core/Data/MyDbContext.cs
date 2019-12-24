using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Wyj.Core.Data.EntityConfigurations;
using Wyj.Core.Helper;
using Wyj.Core.Models;

namespace Wyj.Core.Data
{
    public class MyDbContext : DbContext
    {
        private IConfiguration configuration;

        public MyDbContext(DbContextOptions<MyDbContext> options , IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("defaultDB"));

        }

        public DbSet<User> Users { get; set; }
    }
}
