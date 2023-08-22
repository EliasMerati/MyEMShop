using Microsoft.EntityFrameworkCore;
using MyEMShop.Data.Entities.Banners;
using MyEMShop.Data.Entities.Order;
using MyEMShop.Data.Entities.Permission;
using MyEMShop.Data.Entities.PrivacyPolicy;
using MyEMShop.Data.Entities.Product;
using MyEMShop.Data.Entities.Slider;
using MyEMShop.Data.Entities.Tax;
using MyEMShop.Data.Entities.Terms;
using MyEMShop.Data.Entities.User;
using MyEMShop.Data.Entities.Wallet;
using System;
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

        #region Banner
        public DbSet<Banner> Banners { get; set; }
        #endregion

        #region Privacy Policy
        public DbSet<Privacy> Privacies { get; set; }
        #endregion

        #region Terms
        public DbSet<Term> Terms { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Index & Unique For Email & ProductTitle
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(u => u.ProductTitle);
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
                .HasQueryFilter(pg => !pg.IsDelete);

            //modelBuilder.Entity<Product>()
            //    .HasQueryFilter(p => !p.IsDelete);

            modelBuilder.Entity<ProductComment>()
                .HasQueryFilter(pc => !pc.IsDelete);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            #region Admin
            modelBuilder.Entity<User>()
               .HasData(new
               {
                   UserId = 1,
                   UserName = "BehDokhtAdmin",
                   RegisterDate = DateTime.Now,
                   Name = "بهناز",
                   Family = "اعتضادی فر",
                   Email = "Behnaz.Etezadi8212@gmail.com",
                   Password = "20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70",
                   IsActive = true,
                   IsDelete = false
               });
            #endregion

            #region Role
            modelBuilder.Entity<Role>()
                .HasData(new { RoleId = 1, RoleTitle = "مدیر کل سیستم", IsDelete = false },
                         new { RoleId = 2, RoleTitle = "کاربر عادی", IsDelete = false });
            #endregion

            #region Role Permissions
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
               new { RP_Id = 13, RoleId = 1, PermissionId = 13 },
               new { RP_Id = 14, RoleId = 1, PermissionId = 14 },
               new { RP_Id = 15, RoleId = 1, PermissionId = 15 },
               new { RP_Id = 16, RoleId = 1, PermissionId = 16 },
               new { RP_Id = 17, RoleId = 1, PermissionId = 17 },
               new { RP_Id = 18, RoleId = 1, PermissionId = 18 },
               new { RP_Id = 19, RoleId = 1, PermissionId = 19 },
               new { RP_Id = 20, RoleId = 1, PermissionId = 20 },
               new { RP_Id = 21, RoleId = 1, PermissionId = 21 },
               new { RP_Id = 22, RoleId = 1, PermissionId = 22 },
               new { RP_Id = 23, RoleId = 1, PermissionId = 23 },
               new { RP_Id = 24, RoleId = 1, PermissionId = 24 },
               new { RP_Id = 25, RoleId = 1, PermissionId = 25 },
               new { RP_Id = 26, RoleId = 1, PermissionId = 26 },
               new { RP_Id = 27, RoleId = 1, PermissionId = 27 },
               new { RP_Id = 28, RoleId = 1, PermissionId = 28 },
               new { RP_Id = 29, RoleId = 1, PermissionId = 29 },
               new { RP_Id = 30, RoleId = 1, PermissionId = 30 },
               new { RP_Id = 31, RoleId = 1, PermissionId = 31 },
               new { RP_Id = 32, RoleId = 1, PermissionId = 32 },
               new { RP_Id = 33, RoleId = 1, PermissionId = 33 },
               new { RP_Id = 34, RoleId = 1, PermissionId = 34 },
               new { RP_Id = 35, RoleId = 1, PermissionId = 35 },
               new { RP_Id = 36, RoleId = 1, PermissionId = 36 },
               new { RP_Id = 37, RoleId = 1, PermissionId = 37 },
               new { RP_Id = 38, RoleId = 1, PermissionId = 38 },
               new { RP_Id = 39, RoleId = 1, PermissionId = 39 },
               new { RP_Id = 40, RoleId = 1, PermissionId = 40 },
               new { RP_Id = 41, RoleId = 1, PermissionId = 41 },
               new { RP_Id = 42, RoleId = 1, PermissionId = 42 },
               new { RP_Id = 43, RoleId = 1, PermissionId = 43 },
               new { RP_Id = 44, RoleId = 1, PermissionId = 44 },
               new { RP_Id = 45, RoleId = 1, PermissionId = 45 },
               new { RP_Id = 46, RoleId = 1, PermissionId = 46 },
               new { RP_Id = 47, RoleId = 1, PermissionId = 47 },
               new { RP_Id = 48, RoleId = 1, PermissionId = 48 },
               new { RP_Id = 49, RoleId = 1, PermissionId = 49 },
               new { RP_Id = 50, RoleId = 1, PermissionId = 50 },
               new { RP_Id = 51, RoleId = 1, PermissionId = 51 },
               new { RP_Id = 52, RoleId = 1, PermissionId = 52 },
               new { RP_Id = 53, RoleId = 1, PermissionId = 53 },
               new { RP_Id = 54, RoleId = 1, PermissionId = 54 },
               new { RP_Id = 55, RoleId = 1, PermissionId = 55 });
            #endregion

            #region Permissions
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
                        new { PermissionId = 13, PermissionTitle = "افزودن محصول", ParentId = 12 },
                        new { PermissionId = 14, PermissionTitle = "ویرایش محصول", ParentId = 12 },
                        new { PermissionId = 15, PermissionTitle = "حذف محصول", ParentId = 12 },
                        new { PermissionId = 16, PermissionTitle = "مدیریت گروه ها", ParentId = 1 },
                        new { PermissionId = 17, PermissionTitle = "افزودن گروه", ParentId = 16 },
                        new { PermissionId = 18, PermissionTitle = "ویرایش گروه", ParentId = 16 },
                        new { PermissionId = 19, PermissionTitle = "حذف گروه", ParentId = 16 },
                        new { PermissionId = 20, PermissionTitle = "افزودن زیرگروه", ParentId = 16 },
                        new { PermissionId = 21, PermissionTitle = "ویرایش زیرگروه", ParentId = 16 },
                        new { PermissionId = 22, PermissionTitle = "حذف زیرگروه", ParentId = 16 },
                        new { PermissionId = 23, PermissionTitle = "مدیریت سفارشات", ParentId = 1 },
                        new { PermissionId = 24, PermissionTitle = "در حال پردازش", ParentId = 23 },
                        new { PermissionId = 25, PermissionTitle = "آماده ارسال", ParentId = 23 },
                        new { PermissionId = 26, PermissionTitle = "ارسال شده", ParentId = 23 },
                        new { PermissionId = 27, PermissionTitle = "لغو شده", ParentId = 23 },
                        new { PermissionId = 28, PermissionTitle = "مدیریت تخفیف ها", ParentId = 1 },
                        new { PermissionId = 29, PermissionTitle = "لیست تخفیف ها", ParentId = 28 },
                        new { PermissionId = 30, PermissionTitle = "افزودن تخفیف ", ParentId = 28 },
                        new { PermissionId = 31, PermissionTitle = "ویرایش تخفیف ", ParentId = 28 },
                        new { PermissionId = 32, PermissionTitle = "مدیریت مالیات ", ParentId = 1 },
                        new { PermissionId = 33, PermissionTitle = "افزودن مالیات ", ParentId = 32 },
                        new { PermissionId = 34, PermissionTitle = "ویرایش مالیات ", ParentId = 32 },
                        new { PermissionId = 35, PermissionTitle = "مدیریت اسلایدر ها", ParentId = 1 },
                        new { PermissionId = 36, PermissionTitle = "افزودن اسلایدر ", ParentId = 35 },
                        new { PermissionId = 37, PermissionTitle = "حذف اسلایدر ", ParentId = 35 },
                        new { PermissionId = 38, PermissionTitle = "مدیریت بنر ها ", ParentId = 1 },
                        new { PermissionId = 39, PermissionTitle = "مدیریت بنر های کوچک ", ParentId = 38 },
                        new { PermissionId = 40, PermissionTitle = "مدیریت بنر های بزرگ ", ParentId = 38 },
                        new { PermissionId = 41, PermissionTitle = "افزودن بنر کوچک ", ParentId = 39 },
                        new { PermissionId = 42, PermissionTitle = "افزودن بنر بزرگ ", ParentId = 40 },
                        new { PermissionId = 43, PermissionTitle = "ویرایش بنر کوچک چپ", ParentId = 38 },
                        new { PermissionId = 44, PermissionTitle = "ویرایش بنر کوچک وسط چپ ", ParentId = 38 },
                        new { PermissionId = 45, PermissionTitle = "ویرایش بنر کوچک وسط راست ", ParentId = 38 },
                        new { PermissionId = 46, PermissionTitle = "ویرایش بنر کوچک راست ", ParentId = 38 },
                        new { PermissionId = 47, PermissionTitle = "حذف بنر کوچک چپ ", ParentId = 38 },
                        new { PermissionId = 48, PermissionTitle = "حذف بنر کوچک وسط چپ ", ParentId = 38 },
                        new { PermissionId = 49, PermissionTitle = "حذف بنر کوچک وسط راست ", ParentId = 38 },
                        new { PermissionId = 50, PermissionTitle = "ویرایش بنر کوچک راست ", ParentId = 38 },
                        new { PermissionId = 51, PermissionTitle = "ویرایش بنر بزرگ چپ ", ParentId = 38 },
                        new { PermissionId = 52, PermissionTitle = "ویرایش بنر بزرگ راست ", ParentId = 38 },
                        new { PermissionId = 53, PermissionTitle = "حذف بنر بزرگ چپ ", ParentId = 38 },
                        new { PermissionId = 54, PermissionTitle = "حذف بنر بزرگ راست ", ParentId = 38 },
                        new { PermissionId = 55, PermissionTitle = "مدیریت کامنت ها ", ParentId = 1 });
            #endregion

            #region AdminRole
            modelBuilder.Entity<UserRole>()
               .HasData(new { U_RId = 1, UserId = 1, RoleId = 1 });
            #endregion

            #region Wallet Type
            modelBuilder.Entity<WalletType>()
                .HasData(new { TypeId = 1, TypeTitle = "واریز" },
                         new { TypeId = 2, TypeTitle = "برداشت" });
            #endregion

            #region Product Level
            modelBuilder.Entity<Level>()
             .HasData(new { PL_Id = 1, PL_Title = "موجود" },
                      new { PL_Id = 2, PL_Title = "ناموجود" },
                      new { PL_Id = 3, PL_Title = "به زودی" });
            #endregion

            #region Product Size
            modelBuilder.Entity<Size>()
               .HasData(new { PS_Id = 1, SizeTitle = "FreeSize" },
                        new { PS_Id = 2, SizeTitle = "Medium" },
                        new { PS_Id = 3, SizeTitle = "Large" },
                        new { PS_Id = 4, SizeTitle = "Small" },
                        new { PS_Id = 5, SizeTitle = "XXLarge" });
            #endregion

        }

    }
}
