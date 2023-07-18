using Microsoft.EntityFrameworkCore;
using MyEMShop.Data.Entities.Slider;
using MyEMShop.Data.Entities.Order;
using MyEMShop.Data.Entities.Permission;
using MyEMShop.Data.Entities.Product;
using MyEMShop.Data.Entities.User;
using MyEMShop.Data.Entities.Wallet;
using System.Linq;
using MyEMShop.Data.Entities.Tax;
using System.Drawing.Text;

namespace MyEMShop.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserDiscountCode> UserDiscountCodes { get; set; }
        #endregion

        #region Wallet
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }
        #endregion

        #region Permission
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        #endregion

        #region Order
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        #endregion

        #region Slider
        public DbSet<Slider> Sliders { get; set; }
        #endregion

        #region product
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<ProductLevel> ProductLevels { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<FavoriteProducts> FavoriteProducts { get; set; }
        #endregion

        #region Tax
        public DbSet<Tax> Taxes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Index & Unique For Email
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            #endregion

            #region Solve Cascading ForeignKeys

            foreach (var relationship in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior is DeleteBehavior.Cascade))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #endregion

            SeedData(modelBuilder);

            #region Query Filters
            //modelBuilder.Entity<User>()
            //    .HasQueryFilter(u => !u.IsDelete);

            modelBuilder.Entity<Role>()
                .HasQueryFilter(r => !r.IsDelete);

            modelBuilder.Entity<ProductGroup>()
                .HasQueryFilter(g => !g.IsDelete);

            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.IsDelete);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            
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
                         new { RP_Id = 11, RoleId = 1, PermissionId = 11 },
                         new { RP_Id = 12, RoleId = 1, PermissionId = 12 },
                         new { RP_Id = 13, RoleId = 1, PermissionId = 13 });


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
                         new { PermissionId = 11, PermissionTitle = "بازگردانی کاربر ", ParentId = 2 },
                         new { PermissionId = 12, PermissionTitle = "مدیریت محصولات ", ParentId = 1 },
                         new { PermissionId = 13, PermissionTitle = "افزودن محصول", ParentId = 12 });


            modelBuilder.Entity<WalletType>()
                .HasData(new { TypeId = 1, TypeTitle = "واریز" },
                         new { TypeId = 2, TypeTitle = "برداشت" });

            modelBuilder.Entity<Level>()
               .HasData(new { PL_Id = 1, PL_Title = "موجود" },
                        new { PL_Id = 2, PL_Title = "ناموجود" },
                        new { PL_Id = 3, PL_Title = "به زودی" });

            modelBuilder.Entity<Size>()
                .HasData(new { PS_Id = 1, SizeTitle = "FreeSize" },
                         new { PS_Id = 2, SizeTitle = "Medium" },
                         new { PS_Id = 3, SizeTitle = "Large" },
                         new { PS_Id = 4, SizeTitle = "Small" },
                         new { PS_Id = 5, SizeTitle = "XXLarge" });
            
        }

    }
}
