﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyEMShop.Data.Context;

namespace MyEMShop.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyEMShop.Data.Entities.Permission.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("PermissionTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PermissionId");

                    b.HasIndex("ParentId");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            PermissionTitle = "مدیریت "
                        },
                        new
                        {
                            PermissionId = 2,
                            ParentId = 1,
                            PermissionTitle = "مدیریت کاربران "
                        },
                        new
                        {
                            PermissionId = 3,
                            ParentId = 1,
                            PermissionTitle = "مدیریت نقش ها "
                        },
                        new
                        {
                            PermissionId = 4,
                            ParentId = 2,
                            PermissionTitle = "افزودن کاربر "
                        },
                        new
                        {
                            PermissionId = 5,
                            ParentId = 2,
                            PermissionTitle = "ویرایش کاربر "
                        },
                        new
                        {
                            PermissionId = 6,
                            ParentId = 2,
                            PermissionTitle = "حذف کاربر "
                        },
                        new
                        {
                            PermissionId = 7,
                            ParentId = 3,
                            PermissionTitle = "افزودن نقش "
                        },
                        new
                        {
                            PermissionId = 8,
                            ParentId = 3,
                            PermissionTitle = "ویرایش نقش "
                        },
                        new
                        {
                            PermissionId = 9,
                            ParentId = 3,
                            PermissionTitle = "حذف نقش "
                        },
                        new
                        {
                            PermissionId = 10,
                            ParentId = 2,
                            PermissionTitle = "لیست کاربران حذف شده "
                        },
                        new
                        {
                            PermissionId = 11,
                            ParentId = 2,
                            PermissionTitle = "بازگردانی کاربر "
                        },
                        new
                        {
                            PermissionId = 12,
                            ParentId = 1,
                            PermissionTitle = "مدیریت محصولات "
                        },
                        new
                        {
                            PermissionId = 13,
                            ParentId = 12,
                            PermissionTitle = "افزودن محصول"
                        });
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Permission.RolePermission", b =>
                {
                    b.Property<int>("RP_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RP_Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermission");

                    b.HasData(
                        new
                        {
                            RP_Id = 1,
                            PermissionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            RP_Id = 2,
                            PermissionId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            RP_Id = 3,
                            PermissionId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            RP_Id = 4,
                            PermissionId = 4,
                            RoleId = 1
                        },
                        new
                        {
                            RP_Id = 5,
                            PermissionId = 5,
                            RoleId = 1
                        },
                        new
                        {
                            RP_Id = 6,
                            PermissionId = 6,
                            RoleId = 1
                        },
                        new
                        {
                            RP_Id = 7,
                            PermissionId = 7,
                            RoleId = 1
                        },
                        new
                        {
                            RP_Id = 8,
                            PermissionId = 8,
                            RoleId = 1
                        },
                        new
                        {
                            RP_Id = 9,
                            PermissionId = 9,
                            RoleId = 1
                        },
                        new
                        {
                            RP_Id = 10,
                            PermissionId = 10,
                            RoleId = 1
                        },
                        new
                        {
                            RP_Id = 11,
                            PermissionId = 11,
                            RoleId = 1
                        },
                        new
                        {
                            RP_Id = 12,
                            PermissionId = 12,
                            RoleId = 1
                        },
                        new
                        {
                            RP_Id = 13,
                            PermissionId = 13,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.Color", b =>
                {
                    b.Property<int>("PC_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PC_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PC_Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.Level", b =>
                {
                    b.Property<int>("PL_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PL_Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PL_Id");

                    b.ToTable("Levels");

                    b.HasData(
                        new
                        {
                            PL_Id = 1,
                            PL_Title = "موجود"
                        },
                        new
                        {
                            PL_Id = 2,
                            PL_Title = "ناموجود"
                        },
                        new
                        {
                            PL_Id = 3,
                            PL_Title = "به زودی"
                        });
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("PC_Id")
                        .HasColumnType("int");

                    b.Property<int>("PI_Id")
                        .HasColumnType("int");

                    b.Property<int>("PL_Id")
                        .HasColumnType("int");

                    b.Property<int>("PS_Id")
                        .HasColumnType("int");

                    b.Property<string>("ProductCheck")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPrice")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ProductTitle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("SubGroup")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.HasKey("ProductId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubGroup");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.ProductColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ColorPC_Id")
                        .HasColumnType("int");

                    b.Property<int>("PC_Id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorPC_Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductColors");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.ProductGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("ParentId");

                    b.ToTable("ProductGroups");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.ProductImage", b =>
                {
                    b.Property<int>("PI_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PI_ImageName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("PI_Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.ProductLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LevelPL_Id")
                        .HasColumnType("int");

                    b.Property<int>("PL_Id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LevelPL_Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductLevels");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.ProductSize", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PS_Id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("SizePS_Id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizePS_Id");

                    b.ToTable("ProductSizes");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.Size", b =>
                {
                    b.Property<int>("PS_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SizeTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PS_Id");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            PS_Id = 1,
                            SizeTitle = "FreeSize"
                        },
                        new
                        {
                            PS_Id = 2,
                            SizeTitle = "Medium"
                        },
                        new
                        {
                            PS_Id = 3,
                            SizeTitle = "Large"
                        },
                        new
                        {
                            PS_Id = 4,
                            SizeTitle = "Small"
                        },
                        new
                        {
                            PS_Id = 5,
                            SizeTitle = "XXLarge"
                        });
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.User.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            IsDelete = false,
                            RoleTitle = "مدیر کل سیستم"
                        },
                        new
                        {
                            RoleId = 2,
                            IsDelete = false,
                            RoleTitle = "کاربر عادی"
                        });
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Activecode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Family")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Ostan")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.User.UserRole", b =>
                {
                    b.Property<int>("U_RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("U_RId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Wallet.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("IsPay")
                        .HasColumnType("bit");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WalletTypeTypeId")
                        .HasColumnType("int");

                    b.HasKey("WalletId");

                    b.HasIndex("UserId");

                    b.HasIndex("WalletTypeTypeId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Wallet.WalletType", b =>
                {
                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("TypeTitle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("TypeId");

                    b.ToTable("WalletTypes");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            TypeTitle = "واریز"
                        },
                        new
                        {
                            TypeId = 2,
                            TypeTitle = "برداشت"
                        });
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Permission.Permission", b =>
                {
                    b.HasOne("MyEMShop.Data.Entities.Permission.Permission", null)
                        .WithMany("Permissions")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Permission.RolePermission", b =>
                {
                    b.HasOne("MyEMShop.Data.Entities.Permission.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyEMShop.Data.Entities.User.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.Product", b =>
                {
                    b.HasOne("MyEMShop.Data.Entities.Product.ProductGroup", "productGroup")
                        .WithMany("Products")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyEMShop.Data.Entities.Product.ProductGroup", "GroupSub")
                        .WithMany("SubGroups")
                        .HasForeignKey("SubGroup");

                    b.Navigation("GroupSub");

                    b.Navigation("productGroup");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.ProductColor", b =>
                {
                    b.HasOne("MyEMShop.Data.Entities.Product.Color", "Color")
                        .WithMany("ProductColors")
                        .HasForeignKey("ColorPC_Id");

                    b.HasOne("MyEMShop.Data.Entities.Product.Product", "Product")
                        .WithMany("ProductColors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.ProductGroup", b =>
                {
                    b.HasOne("MyEMShop.Data.Entities.Product.ProductGroup", null)
                        .WithMany("Groups")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.ProductImage", b =>
                {
                    b.HasOne("MyEMShop.Data.Entities.Product.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.ProductLevel", b =>
                {
                    b.HasOne("MyEMShop.Data.Entities.Product.Level", "Level")
                        .WithMany("ProductLevels")
                        .HasForeignKey("LevelPL_Id");

                    b.HasOne("MyEMShop.Data.Entities.Product.Product", "Product")
                        .WithMany("ProductLevels")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.ProductSize", b =>
                {
                    b.HasOne("MyEMShop.Data.Entities.Product.Product", "Product")
                        .WithMany("ProductSizes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyEMShop.Data.Entities.Product.Size", "Size")
                        .WithMany("ProductSizes")
                        .HasForeignKey("SizePS_Id");

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.User.UserRole", b =>
                {
                    b.HasOne("MyEMShop.Data.Entities.User.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyEMShop.Data.Entities.User.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Wallet.Wallet", b =>
                {
                    b.HasOne("MyEMShop.Data.Entities.User.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyEMShop.Data.Entities.Wallet.WalletType", "WalletType")
                        .WithMany("Wallets")
                        .HasForeignKey("WalletTypeTypeId");

                    b.Navigation("User");

                    b.Navigation("WalletType");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Permission.Permission", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.Color", b =>
                {
                    b.Navigation("ProductColors");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.Level", b =>
                {
                    b.Navigation("ProductLevels");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.Product", b =>
                {
                    b.Navigation("ProductColors");

                    b.Navigation("ProductImages");

                    b.Navigation("ProductLevels");

                    b.Navigation("ProductSizes");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.ProductGroup", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Products");

                    b.Navigation("SubGroups");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Product.Size", b =>
                {
                    b.Navigation("ProductSizes");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.User.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.User.User", b =>
                {
                    b.Navigation("UserRoles");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("MyEMShop.Data.Entities.Wallet.WalletType", b =>
                {
                    b.Navigation("Wallets");
                });
#pragma warning restore 612, 618
        }
    }
}
