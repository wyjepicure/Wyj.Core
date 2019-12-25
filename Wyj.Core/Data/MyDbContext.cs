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
            modelBuilder.Entity<UserRole>()
                .HasKey(t => new { t.UserId,t.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.Role)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(pt => pt.RoleId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("defaultDB"));

        }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
