using Microsoft.EntityFrameworkCore;
using MyEMShop.Data.Entities.User;
using MyEMShop.Data.Entities.Wallet;
using System.Drawing;
using System.Linq;

namespace MyEMShop.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        #endregion

        #region Wallet
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Solve Cascading ForeignKeys

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #endregion

            #region Seed Data
            modelBuilder.Entity<Role>()
                .HasData(new { RoleId = 1, RoleTitle = "Admin", RoleName = "مدیر کل سیستم" },
                         new { RoleId = 2, RoleTitle = "User", RoleName = "کاربر عادی" });

            modelBuilder.Entity<WalletType>()
                .HasData(new { TypeId = 1, TypeTitle = "واریز" },
                         new { TypeId = 2, TypeTitle = "برداشت" });
            #endregion


            base.OnModelCreating(modelBuilder);
        }

    }
}
