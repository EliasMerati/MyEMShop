using Microsoft.EntityFrameworkCore;
using MyEMShop.Data.Entities.Permission;
using MyEMShop.Data.Entities.User;
using MyEMShop.Data.Entities.Wallet;

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

        #region Permission
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Solve Cascading ForeignKeys

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            #endregion

            #region Seed Data
            modelBuilder.Entity<Role>()
                .HasData(new { RoleId = 1, RoleTitle = "مدیر کل سیستم", IsDelete = false },
                         new { RoleId = 2, RoleTitle = "کاربر عادی", IsDelete = false });

            modelBuilder.Entity<RolePermission>()
                .HasData(new { RP_Id = 1, RoleId = 1, PermissionId = 1 },
                         new { RP_Id = 2, RoleId = 1, PermissionId = 2 },
                         new { RP_Id = 3, RoleId = 1, PermissionId = 3 },
                         new { RP_Id = 4, RoleId = 1, PermissionId = 4 },
                         new { RP_Id = 5, RoleId = 1, PermissionId = 5 },
                         new { RP_Id = 6, RoleId = 1, PermissionId = 6 },
                         new { RP_Id = 7, RoleId = 1, PermissionId = 7 },
                         new { RP_Id = 8, RoleId = 1, PermissionId = 8 },
                         new { RP_Id = 9, RoleId = 1, PermissionId = 9 },
                         new { RP_Id = 10, RoleId = 1, PermissionId = 10 },
                         new { RP_Id = 11, RoleId = 1, PermissionId = 11 });


            modelBuilder.Entity<Permission>()
                .HasData(new { PermissionId = 1, PermissionTitle = "مدیریت " },
                         new { PermissionId = 2, PermissionTitle = "مدیریت کاربران ", ParentId = 1 },
                         new { PermissionId = 3, PermissionTitle = "مدیریت نقش ها ", ParentId = 1 },
                         new { PermissionId = 4, PermissionTitle = "افزودن کاربر ", ParentId = 2 },
                         new { PermissionId = 5, PermissionTitle = "ویرایش کاربر ", ParentId = 2 },
                         new { PermissionId = 6, PermissionTitle = "حذف کاربر ", ParentId = 2 },
                         new { PermissionId = 7, PermissionTitle = "افزودن نقش ", ParentId = 3 },
                         new { PermissionId = 8, PermissionTitle = "ویرایش نقش ", ParentId = 3 },
                         new { PermissionId = 9, PermissionTitle = "حذف نقش ", ParentId = 3 },
                         new { PermissionId = 10, PermissionTitle = "لیست کاربران حذف شده ", ParentId = 2 },
                         new { PermissionId = 11, PermissionTitle = "بازگردانی کاربر ", ParentId = 2 });


            modelBuilder.Entity<WalletType>()
                .HasData(new { TypeId = 1, TypeTitle = "واریز" },
                         new { TypeId = 2, TypeTitle = "برداشت" });
            #endregion

            #region Query Filters
            //modelBuilder.Entity<User>()
            //    .HasQueryFilter(u => !u.IsDelete);

            modelBuilder.Entity<Role>()
                .HasQueryFilter(r => !r.IsDelete);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
