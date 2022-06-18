using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthenticationService.DataAccess
{
    public class AuthContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        private readonly string _connectionString;

        public AuthContext()
        {
            _connectionString = @"Data Source=V-FURSENKO-1\SQLEXPRESS;Initial Catalog=AUTH;Integrated Security=True";
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Role>(_ =>
            {
                _.ToTable("SecurityRole");
                _.HasKey(_ => _.Id);
            });

            builder.Entity<User>(_ =>
            {
                _.ToTable("SecurityUser");
                _.HasKey(_ => _.Id);
            });

            builder.Entity<UserRole>(_ =>
            {
                _.ToTable("SecurityUserRole");
                _.Property("UserId").HasColumnName("SecurityUserId");
                _.Property("RoleId").HasColumnName("SecurityRoleId");
                _.HasKey(_ => new { _.UserId, _.RoleId });
            });

            builder.Entity<User>()
             .HasMany(user => user.Roles)
             .WithMany(role => role.Users)
             .UsingEntity<UserRole>(
                 left => left
                     .HasOne(pt => pt.Role)
                     .WithMany()
                     .HasForeignKey(_ => _.RoleId),
                 right => right
                     .HasOne(pt => pt.User)
                     .WithMany()
                     .HasForeignKey(pt => pt.UserId));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
