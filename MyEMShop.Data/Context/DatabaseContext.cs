using Microsoft.EntityFrameworkCore;
using MyEMShop.Data.Entities.User;

namespace MyEMShop.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Data
            modelBuilder.Entity<Role>()
                .HasData(new { RoleId = 1, RoleTitle = "Admin", RoleName = "مدیر کل سیستم" },
                         new { RoleId = 2, RoleTitle = "User", RoleName = "کاربر عادی" }); 
            #endregion

            base.OnModelCreating(modelBuilder); 
        }

    }
}
