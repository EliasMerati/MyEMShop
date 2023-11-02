using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEMShop.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    AboutUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUsText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.AboutUsId);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    BannerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BannerImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BannerLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BannerType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.BannerId);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    PC_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PC_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.PC_Id);
                });

            migrationBuilder.CreateTable(
                name: "contactUsConections",
                columns: table => new
                {
                    CUC_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Question = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactUsConections", x => x.CUC_Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUsInfos",
                columns: table => new
                {
                    ContactUsInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactUsAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactUsOstanCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactUsPelak = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactUsPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactUsWorkTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactUsImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContactUsDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsInfos", x => x.ContactUsInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false),
                    UsableCount = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "FaqGroups",
                columns: table => new
                {
                    FaqGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaqGroupTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqGroups", x => x.FaqGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    PL_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PL_Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.PL_Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    PermissionTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_Permission_Permission_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Permission",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Privacies",
                columns: table => new
                {
                    PrivacyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrivacyText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privacies", x => x.PrivacyId);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_ProductGroups_ProductGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    PS_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.PS_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    SliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderImageName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.SliderId);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    TaxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.TaxId);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    TermId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.TermId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Activecode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Family = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ostan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", maxLength: 300, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "VisitorDevices",
                columns: table => new
                {
                    VisitorDeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorId = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSpider = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorDevices", x => x.VisitorDeviceId);
                });

            migrationBuilder.CreateTable(
                name: "VisitorOs",
                columns: table => new
                {
                    VisitorOSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorId = table.Column<int>(type: "int", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorOs", x => x.VisitorOSId);
                });

            migrationBuilder.CreateTable(
                name: "VisitorVersions",
                columns: table => new
                {
                    VisitorBrowserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorId = table.Column<int>(type: "int", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorVersions", x => x.VisitorBrowserId);
                });

            migrationBuilder.CreateTable(
                name: "WalletTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    TypeTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    FaqId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaqGroupId = table.Column<int>(type: "int", nullable: false),
                    FaqQuestion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FaqAnswer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.FaqId);
                    table.ForeignKey(
                        name: "FK_Faqs_FaqGroups_FaqGroupId",
                        column: x => x.FaqGroupId,
                        principalTable: "FaqGroups",
                        principalColumn: "FaqGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    SubGroup = table.Column<int>(type: "int", nullable: true),
                    PL_Id = table.Column<int>(type: "int", nullable: false),
                    PS_Id = table.Column<int>(type: "int", nullable: false),
                    ProductTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Productmark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Save = table.Column<int>(type: "int", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    MainImageProduct = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ProductDemo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isspecial = table.Column<bool>(type: "bit", nullable: false),
                    ShortKey = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_SubGroup",
                        column: x => x.SubGroup,
                        principalTable: "ProductGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RP_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.RP_Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderSum = table.Column<int>(type: "int", nullable: false),
                    IsFinally = table.Column<bool>(type: "bit", nullable: false),
                    OrderPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderOstan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderState = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDiscountCodes",
                columns: table => new
                {
                    UserDiscountCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiscountCodes", x => x.UserDiscountCodeId);
                    table.ForeignKey(
                        name: "FK_UserDiscountCodes_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDiscountCodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    U_RId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.U_RId);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferrerLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Protocol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhisicalPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserVisitorBrowserId = table.Column<int>(type: "int", nullable: true),
                    OperationSystemVisitorOSId = table.Column<int>(type: "int", nullable: true),
                    VisitorDeviceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorId);
                    table.ForeignKey(
                        name: "FK_Visitors_VisitorDevices_VisitorDeviceId",
                        column: x => x.VisitorDeviceId,
                        principalTable: "VisitorDevices",
                        principalColumn: "VisitorDeviceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visitors_VisitorOs_OperationSystemVisitorOSId",
                        column: x => x.OperationSystemVisitorOSId,
                        principalTable: "VisitorOs",
                        principalColumn: "VisitorOSId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visitors_VisitorVersions_BrowserVisitorBrowserId",
                        column: x => x.BrowserVisitorBrowserId,
                        principalTable: "VisitorVersions",
                        principalColumn: "VisitorBrowserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    WalletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalletTypeTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.WalletId);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wallets_WalletTypes_WalletTypeTypeId",
                        column: x => x.WalletTypeTypeId,
                        principalTable: "WalletTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColorProduct",
                columns: table => new
                {
                    ColorsPC_Id = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorProduct", x => new { x.ColorsPC_Id, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_ColorProduct_Colors_ColorsPC_Id",
                        column: x => x.ColorsPC_Id,
                        principalTable: "Colors",
                        principalColumn: "PC_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColorProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteProducts",
                columns: table => new
                {
                    FP_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProducts", x => x.FP_Id);
                    table.ForeignKey(
                        name: "FK_FavoriteProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    AdminRead = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    PI_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PI_ImageName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.PI_Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PL_Id = table.Column<int>(type: "int", nullable: false),
                    LevelPL_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLevels_Levels_LevelPL_Id",
                        column: x => x.LevelPL_Id,
                        principalTable: "Levels",
                        principalColumn: "PL_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLevels_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PS_Id = table.Column<int>(type: "int", nullable: false),
                    SizePS_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Sizes_SizePS_Id",
                        column: x => x.SizePS_Id,
                        principalTable: "Sizes",
                        principalColumn: "PS_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "AboutUsId", "AboutUsText" },
                values: new object[] { 1, "<p>در فروشگاه به دخت، ما معتقدیم که هر زنی شایسته لباسی زیبا و جذاب برای هر مناسبتی است. ما طیف گسترده ای از لباس های مجلسی زنانه را در طرح ها، رنگ ها و اندازه های مختلف ارائه می دهیم تا هر زنی بتواند لباسی را پیدا کند که به او احساس اعتماد به نفس و زیبایی بدهد.</p> <p>ما به کیفیت لباس های خود متعهد هستیم و فقط از مواد و ساخت با کیفیت بالا استفاده می کنیم. ما همچنین به خدمات مشتری خود متعهد هستیم و تیم ما همیشه آماده کمک به شما در یافتن لباس مناسب برای مناسبت خاص شما است.</p> <p>اگر به دنبال لباس مجلسی زنانه زیبا و با کیفیت هستید، فروشگاه به دخت مکان مناسبی برای شما است. شما طیف گسترده ای از گزینه ها را برای انتخاب دارید و تیم ما همیشه آماده کمک به شما است.</p> <p>در اینجا برخی از دلایلی که چرا باید از فروشگاه به دخت لباس مجلسی بخرید آورده شده است:</p> <ul> <li><strong>ما طیف گسترده ای از لباس های مجلسی زنانه را در طرح ها، رنگ ها و اندازه های مختلف ارائه می دهیم.</strong></li> <li><strong>ما به کیفیت لباس های خود متعهد هستیم و فقط از مواد و ساخت با کیفیت بالا استفاده می کنیم.</strong></li> <li><strong>ما به خدمات مشتری خود متعهد هستیم و تیم ما همیشه آماده کمک به شما در یافتن لباس مناسب برای مناسبت خاص شما است.</strong></li> </ul> <p>ما مشتاقیم تا شما را در فروشگاه خود ببینیم و به شما کمک کنیم تا لباس مجلسی رویایی خود را پیدا کنید.</p> <div> <div> <div>&nbsp;</div> <div> <div> <div>&nbsp;</div> <div> <p>&nbsp;</p> <p>&nbsp;</p> </div> </div> </div> </div> </div>" });

            migrationBuilder.InsertData(
                table: "ContactUsInfos",
                columns: new[] { "ContactUsInfoId", "ContactUsAddress", "ContactUsDesc", "ContactUsImage", "ContactUsOstanCity", "ContactUsPelak", "ContactUsPhone", "ContactUsWorkTime" },
                values: new object[] { 1, "خیابان امیر کبیر - امیر کبیر 9/5", "فقط در ساعات کاری جوابگو هستیم , زمان دیگر پاسخگو نخواهیم بود", null, "خراسان رضوی - نیشابور", "141", "09015519699", "شنبه تا پنج شنبه از ساعت 8 الی 18 به استثنای روزهای تعطیل رسمی" });

            migrationBuilder.InsertData(
                table: "FaqGroups",
                columns: new[] { "FaqGroupId", "FaqGroupTitle" },
                values: new object[,]
                {
                    { 1, "حساب کاربری و سفارشات من" },
                    { 2, "خرید" },
                    { 3, "پرداخت ها" },
                    { 4, "وضعیت سفارش" },
                    { 5, "حمل و نقل" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "PL_Id", "PL_Title" },
                values: new object[,]
                {
                    { 2, "ناموجود" },
                    { 1, "موجود" },
                    { 3, "به زودی" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "PermissionTitle" },
                values: new object[] { 1, null, "مدیریت " });

            migrationBuilder.InsertData(
                table: "Privacies",
                columns: new[] { "PrivacyId", "PrivacyText" },
                values: new object[] { 1, "<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<img alt=\"\" src=\"/Template/image/product/CkEditors Image/1aef6903-01e5-4e48-b95c-8d07ad3e8dac.png\" style=\"height:250px; width:700px\" /></p>\r\n\r\n<p><strong>سیاست حفظ حریم خصوصی </strong>:</p>\r\n\r\n<p><br />\r\nفروشگاه به دخت با احترام برای حریم شخصی و خصوصی کاربران خود، برای خرید، ثبت نظر و یا استفاده از برخی امکانات سایت ، اطلاعاتی را از کاربران خواهد خواست تا بتواند خدماتی امن و مطمئن به آنها ارائه دهد. همچنین برای پردازش و ارسال پوشاک خریداری شده مشتریان، اطلاعاتی مانند آدرس، شماره تماس و ایمیل مورد نیاز است که ممکن است جهت هماهنگی ارسال و یا تایید آنها، فروشگاه به دخت نسبت به اعتبارسنجی آن اقدام کند.&nbsp;</p>\r\n\r\n<p>فروشگاه به دخت همچنین خود را موظف می داند&nbsp;&nbsp;در حفظ اطلاعات مشتریان نهایت تلاش خود را مبذول دارد. قطعا مورد توجه خواهد بود که عضویت کاربران در وب سایت به دخت، به منزله قبول قوانین جمهوری اسلامی ایران از جمله قوانین تجارت الکترونیک و قوانین مالی و مالیاتی و قوانین سایت فروشگاه به دخت است.&nbsp;</p>\r\n\r\n<p>طی فرایند خرید، فاکتور رسمی و بنا به درخواست مشتریان حقوقی گواهی ارزش افزوده صادر می شود، از این رو وارد کردن اطلاعاتی مانند نام و کدملی برای اشخاص حقیقی&nbsp;&nbsp;لازم است. همچنین آدرس ایمیل و تلفن هایی که مشتری در پروفایل خود ثبت می&shy; کند، تنها &nbsp;آدرس ایمیل و تلفن&shy; های رسمی و مورد تایید مشتری است و تمام مکاتبات و پاسخ های شرکت از طریق آنها صورت می گیرد.</p>\r\n\r\n<p>فروشگاه لباس زنانه به دخت ممکن است نقد و نظرهای ارسالی کاربران را در راستای رعایت &nbsp;قوانین وب سایت ویرایش کند. همچنین اگر نظر یا پیام ارسال شده توسط کاربر، مشمول مصادیق محتوای مجرمانه باشد، فروشگاه لباس زنانه نیک می&zwnj;تواند از اطلاعات ثبت شده برای پیگیری قانونی استفاده کند. حفظ و نگهداری رمز عبور بر عهده کاربران است و برای جلوگیری از هرگونه سوءاستفاده احتمالی، کاربران نباید آن را برای شخص دیگری فاش کنند. فروشگاه لباس زنانه به دخت هویت شخصی کاربران را محرمانه دانسته و اطلاعات شخصی آنان را به هیچ شخص یا سازمان دیگری منتقل نمی&zwnj;کند، مگر اینکه با حکم قانونی مجبور باشد اطلاعاتی را در اختیار مراجع ذی&zwnj;صلاح قرار دهد. فروشگاه به دخت مانند اکثر وب سایت&zwnj;ها از جمع آوری IP و کوکی &zwnj;ها استفاده می&zwnj;کند، اما پروتکل، سرور و لایه&zwnj;های امنیتی سایت به دخت و روش&zwnj; های مناسب مدیریت داده&zwnj;ها اطلاعات کاربران را محافظت و از دسترسی&zwnj; های غیر قانونی جلوگیری می&zwnj;کند.&nbsp;&nbsp;فروشگاه به دخت برای حفاظت و نگهداری اطلاعات و حریم شخصی کاربران همه&shy; توان خود را به کار می&zwnj;گیرد و امیدوار است که تجربه&zwnj; خریدی امن، راحت و خوشایند پوشاک را به مشتریان خود ارائه نماید.</p>\r\n" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "IsDelete", "RoleTitle" },
                values: new object[,]
                {
                    { 1, false, "مدیر کل سیستم" },
                    { 2, false, "کاربر عادی" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "PS_Id", "SizeTitle" },
                values: new object[,]
                {
                    { 1, "FreeSize" },
                    { 2, "Medium" },
                    { 3, "Large" },
                    { 4, "Small" },
                    { 5, "XXLarge" }
                });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "TermId", "TermDescription" },
                values: new object[] { 1, "<h1>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<img alt=\"\" src=\"/Template/image/product/CkEditors Image/b2fe2093e3224a47bbdf2f5f6d8303e7.jpg\" style=\"height:315px; width:851px\" /></h1>\r\n\r\n<h2><strong>متن شرایط و قوانین استفاده از سایت:</strong></h2>\r\n\r\n<p>استفاده از خدمات وب سایت و&nbsp;ایجاد حساب کاربری در&nbsp;به دخت منوط به پذیرش قوانین می باشد .&nbsp;</p>\r\n\r\n<p>لازم به ذکر است که ثبت سفارش نیز در هر زمان به معنی پذیرفتن کلیه قوانین و شرایط به دخت توسط کاربر است.</p>\r\n\r\n<h2><ins><span class=\"marker\"><strong>قوانین عمومی :</strong></span></ins></h2>\r\n\r\n<p>1- تنها خود کاربر می تواند از حساب کاربری و خدمات سایت استفاده نماید و کاربر نباید اطلاعات حساب کاربری خود را در اختیار دیگران قرار دهد.</p>\r\n\r\n<p>2-کاربران برای سفارش حتما باید از منوی کاربری ، آدرس و مشخصات پستی خود را به طور کامل تکمیل کنند و بعد از آن اقدام به ثبت سفارش نمایند.</p>\r\n\r\n<p>3- بدیهی است به فاکتورهای فاقد آدرس کامل پستی ترتیب اثر داده نخواهد شد.</p>\r\n\r\n<p>4- مسئولیت صحت آدرس و اطلاعات وارد شده به عهده ی کاربر است.</p>\r\n\r\n<p>5- هر گونه افترا و تهمت بی پایه و اساس جهت خدشه دار کردن نام به دخت از طرف هر فردی در فضای مجازی منتشر شود ، طبق ماده ی 698 قانون اساسی از فرد اعاده ی حیثیت میشود و اگر فرد حساب کاربری در سایت به دخت داشته باشد ، حساب کاربری شخص مسدود میگردد.</p>\r\n\r\n<p>6- با استناد به قانون جرایم رایانه ای تعیین شده در قانون مجازات های اسلامی و با توجه به مصادیق محتوای مجرمانه جرایم رایانه ای ، در صورت تخلف از قوانین سایت ، پیگیری های قانونی جهت جلوگیری از سوء استفاده متخلفین توسط مراجع ذی صلاح به عمل خواهد آمد.</p>\r\n\r\n<p>7- توجه داشته باشید که کلیه ی اصول و رویه های به دخت ، منطبق با قوانین جمهوری اسلامی ایران و قانون تجارت الکترونیکی و قانون حمایت از حقوق مصرف کننده است و متعاقبا کاربر نیز موظف به رعایت قوانین مرتبط با کاربر است.</p>\r\n\r\n<h2><ins><span class=\"marker\"><strong>ثبت، پردازش ، ارسال و انصراف سفارشات:</strong></span></ins></h2>\r\n\r\n<p>1- روز کاری به معنی روز شنبه تا پنج شنبه هر هفته به استثنای روز های تعطیل رسمی و عمومی در ایران است.&nbsp;</p>\r\n\r\n<p>2- فرایند ارسال بین 7 تا 10 روز کاری زمان می برد.</p>\r\n\r\n<p>3- کلیه سفارش ها در روز های کاری و اولین روز کاری پس از تعطیلات پردازش میشوند.</p>\r\n\r\n<p>4- به دخت به مشتریان خود از 7 روز هفته و 24 ساعت در روز امکان سفارش گذاری می دهد.</p>\r\n\r\n<p>5- با توجه به زمان بندی ارسال ، امکان انصراف سفارشات ثبت و پرداخت شده تنها 12 ساعت پس از ثبت سفارش امکان پذیر است.</p>\r\n\r\n<h2><ins><span class=\"marker\"><strong>نظرات کاربران :</strong></span></ins></h2>\r\n\r\n<p>هدف از ایجاد بخش نظرات کاربران در به دخت ، اشتراک گذاری تجربه ی خرید و کاربری محصولاتی است که به فروش می رسد.</p>\r\n\r\n<p>1- هر کاربر مجاز است در چهارچوب شرایط و قوانین سایت ، نظر یا نظرات خود را به اشتراک بگذارد و پس از بررسی کارشناسان تایید ، نظر را روی سایت مشاهده کند.</p>\r\n\r\n<p>2- بدیهی است که اگر قوانین سایت در نظرات کاربری رعایت نشود ، نظر کاربر تایید نمی شود و در نتیجه در سایت نمایش داده نخواهد شد.</p>\r\n\r\n<p>3- به دخت در قبال درستی یا نادرستی نظرات در سایت مسئولیتی به عهده نخواهد داشت.</p>\r\n\r\n<h2><ins><span class=\"marker\"><strong>شرایط و قوانین درج نظر در بخش نظرات کاربران :</strong></span></ins></h2>\r\n\r\n<p>1- نقد کاربران باید شامل نقاط قوت و ضعف محصول باشد.</p>\r\n\r\n<p>2- در استفاده ی شخصی ، مزایا و معایب به صورت تیتر وار در محل درج شود.</p>\r\n\r\n<p>3-نقد مناسب نقدی است که به طور واقع بینانه ، معایب و مزایای هر محصول را کنار هم بررسی کند.</p>\r\n\r\n<p>4-تنها نظراتی تایید خواهد شد که مرتبط با محصول مورد نظر باشد.</p>\r\n\r\n<p>5- بحث و گفتگو در سایت پذیرفته نمیشود و حذف می گردد.</p>\r\n\r\n<p>6- با توجه به مسئولیت سایت در قبال لینک های موجود در آن ،کاربر نباید لینک سایت دیگری را در نظرات خود ثبت کند.</p>\r\n\r\n<p>7- دقت داشته باشید تا جای ممکن از هر گونه لینک دادن (فرستادن) دیگر کاربران به سایت های دیگر و درج ایمیل یا نام کاربری شبکه های اجتماعی ، خودداری کنید.</p>\r\n\r\n<p>&nbsp;</p>\r\n\r\n<h3>&nbsp;<span class=\"marker\"><strong>در صورتی که در قوانین مندرج تغییراتی در آینده ایجاد شود، در همین صفحه بروزرسانی و منتشر می گردد.</strong></span></h3>\r\n\r\n<h3><span class=\"marker\"><strong>&nbsp;احتمال بروز رسانی قوانین سایت در چندین نوبت در سال وجود دارد.</strong></span></h3>\r\n\r\n<div>\r\n<div>\r\n<div>&nbsp;</div>\r\n\r\n<div>\r\n<div>\r\n<div>&nbsp;</div>\r\n\r\n<div>\r\n<p>&nbsp;</p>\r\n\r\n<p>&nbsp;</p>\r\n</div>\r\n</div>\r\n</div>\r\n</div>\r\n</div>\r\n" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Activecode", "Address", "City", "Email", "Family", "IsActive", "IsDelete", "Name", "Ostan", "Password", "PhoneNumber", "PostalCode", "RegisterDate", "UserName" },
                values: new object[] { 1, null, null, null, "Behnaz.Etezadi8212@gmail.com", "اعتضادی فر", true, false, "بهناز", null, "20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70", null, null, new DateTime(2023, 10, 31, 15, 38, 32, 311, DateTimeKind.Local).AddTicks(4229), "BehDokhtAdmin" });

            migrationBuilder.InsertData(
                table: "WalletTypes",
                columns: new[] { "TypeId", "TypeTitle" },
                values: new object[,]
                {
                    { 1, "واریز" },
                    { 2, "برداشت" }
                });

            migrationBuilder.InsertData(
                table: "Faqs",
                columns: new[] { "FaqId", "FaqAnswer", "FaqGroupId", "FaqQuestion" },
                values: new object[,]
                {
                    { 1, "ثبت حساب کاربری برای خرید و ثبت آدرس و موارد لازم برای ارسال سفارش صورت میگیرد", 1, "ثبت حساب کاربری به چه منظور صورت میگیرد؟" },
                    { 12, "کالایی که خریداری شده ، قابل بازگشت نیست و فقط میتوان تا 12 ساعت بعد از ثبت فاکتور ،با هماهنگی با واحد پشتیبانی سایت به دخت آن را لغو کرد", 5, "نیاز به بازگشت یه کالا دارم، چطور باید اقدام کنم؟ " },
                    { 11, "بستگی به اداره ی پست دارد. ", 5, "چرا کالا به موقع به من تحویل نشده؟ " },
                    { 9, "فقط تا 12 ساعت بعد از ثبت سفارش امکان لغو سفارش وجود دارد و در غیراین صورت لغو سفارش انجام نخواهد شد.", 4, "چطور و چه زمانی میتوانم سفارش خود را لغو کنم؟ " },
                    { 8, "در قسمت پنل کاربری ، فاکتور های من قابل مشاهده است", 4, "چطور وضعیت سفارش خود را مشاهده کنم؟" },
                    { 7, "بله. مالیات بر ارزش افزوده هم به قیمت کالا اضافه و در قیمت نهایی محاسبه میشود.", 3, "آیا مالیات هم به قیمت خرید افزوده میشود؟ " },
                    { 10, "زمانی که وضعیت سفارش به ارسال شده تغییر پیدا کند یعنی سفارش مشتری تحویل اداره ی پست شده است. و زمان رسیدن سفارش به دست مشتری بستگی به اداره ی پست دارد.", 5, "کالا چه زمانی به دست من میرسد؟ " },
                    { 5, "جنس عالی ، دوخت عالی و حرفه ای ", 2, "مزیت خرید از شما چیست؟ " },
                    { 4, "بله. برای خرید محصول از فروشگاه به دخت نیاز به ساخت اکانت کاربری است.", 2, "برای خرید از فروشگاه شما نیاز به اکانت دارم؟ " },
                    { 3, "بله. به این خاطر که محصولی که سفارش داده میشود ، بعد از ثبت سفارش وارد پروسه ی تولید میشود.", 1, "آیا میتوان محصولی که موجود نیست را سفارش داد؟ " },
                    { 2, "از طریق پنل کاربری و قسمت فاکتور های من وضعیت سفارش قابل پیگیری است", 1, "چطور وضعیت سفارش خود را دنبال کنم؟" },
                    { 6, " هزینه ی کالای خریداری شده را به دو صورت میتوان پرداخت کرد : 1- از طریق شارژ کیف پول که در قسمت پنل کاربری و قسمت کیف پول قابل دسترسی است . 2- از طریق درگاه پرداخت مستقیم", 3, "چطور هزینه ی کالای خود را بپردازم؟ " }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "PermissionTitle" },
                values: new object[,]
                {
                    { 55, 1, "مدیریت کامنت ها" },
                    { 72, 1, "مدیریت اطلاعات تماس با ما" },
                    { 69, 1, "مدیریت تماس با ما" },
                    { 60, 1, "مدیریت سوالات متداول" },
                    { 58, 1, "سیاست حریم خصوصی " },
                    { 56, 1, " شرایط و قوانین " },
                    { 38, 1, "مدیریت بنر ها " },
                    { 12, 1, "مدیریت محصولات " },
                    { 32, 1, "مدیریت مالیات " },
                    { 28, 1, "مدیریت تخفیف ها" },
                    { 23, 1, "مدیریت سفارشات" },
                    { 16, 1, "مدیریت گروه ها" },
                    { 3, 1, "مدیریت نقش ها " },
                    { 2, 1, "مدیریت کاربران " },
                    { 35, 1, "مدیریت اسلایدر ها" }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RP_Id", "PermissionId", "RoleId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "U_RId", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "PermissionTitle" },
                values: new object[,]
                {
                    { 4, 2, "افزودن کاربر " },
                    { 26, 23, "ارسال شده" },
                    { 27, 23, "لغو شده" },
                    { 74, 72, "ویرایش اطلاعات تماس با ما" },
                    { 30, 28, "افزودن تخفیف " },
                    { 31, 28, "ویرایش تخفیف " },
                    { 33, 32, "افزودن مالیات " },
                    { 34, 32, "ویرایش مالیات " },
                    { 36, 35, "افزودن اسلایدر " },
                    { 25, 23, "آماده ارسال" },
                    { 37, 35, "حذف اسلایدر " },
                    { 40, 38, "مدیریت بنر های بزرگ " },
                    { 57, 56, "ویرایش شرایط و قوانین " },
                    { 59, 58, "ویرایش سیاست حریم خصوصی" },
                    { 61, 60, "مدیریت گروه سوال" },
                    { 62, 60, "مدیریت سوالات" },
                    { 70, 69, "حذف سوال تماس با ما" },
                    { 71, 69, "جوابدهی سوال تماس با ما" },
                    { 73, 72, "افزودن اطلاعات تماس با ما " },
                    { 39, 38, "مدیریت بنر های کوچک " },
                    { 24, 23, "در حال پردازش" },
                    { 29, 28, "لیست تخفیف ها" },
                    { 22, 16, "حذف زیرگروه" },
                    { 5, 2, "ویرایش کاربر " },
                    { 6, 2, "حذف کاربر " },
                    { 10, 2, "لیست کاربران حذف شده " },
                    { 11, 2, "بازگردانی کاربر " },
                    { 7, 3, "افزودن نقش " },
                    { 8, 3, "ویرایش نقش " },
                    { 13, 12, "افزودن محصول" },
                    { 14, 12, "ویرایش محصول" },
                    { 9, 3, "حذف نقش " },
                    { 18, 16, "ویرایش گروه" },
                    { 21, 16, "ویرایش زیرگروه" },
                    { 20, 16, "افزودن زیرگروه" },
                    { 19, 16, "حذف گروه" },
                    { 17, 16, "افزودن گروه" },
                    { 15, 12, "حذف محصول" }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RP_Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 69, 69, 1 },
                    { 23, 23, 1 },
                    { 60, 60, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RP_Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 58, 58, 1 },
                    { 32, 32, 1 },
                    { 55, 55, 1 },
                    { 38, 38, 1 },
                    { 16, 16, 1 },
                    { 3, 3, 1 },
                    { 35, 35, 1 },
                    { 28, 28, 1 },
                    { 12, 12, 1 },
                    { 56, 56, 1 },
                    { 72, 72, 1 }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "PermissionTitle" },
                values: new object[,]
                {
                    { 41, 39, "افزودن بنر کوچک " },
                    { 45, 39, "ویرایش بنر کوچک وسط راست " },
                    { 46, 39, "ویرایش بنر کوچک راست " },
                    { 47, 39, "حذف بنر کوچک چپ " },
                    { 48, 39, "حذف بنر کوچک وسط چپ " },
                    { 49, 39, "حذف بنر کوچک وسط راست " },
                    { 50, 39, "ویرایش بنر کوچک راست " },
                    { 42, 40, "افزودن بنر بزرگ " },
                    { 51, 40, "ویرایش بنر بزرگ چپ " },
                    { 52, 40, "ویرایش بنر بزرگ راست " },
                    { 53, 40, "حذف بنر بزرگ چپ " },
                    { 54, 40, "حذف بنر بزرگ راست " },
                    { 44, 39, "ویرایش بنر کوچک وسط چپ " },
                    { 43, 39, "ویرایش بنر کوچک چپ" },
                    { 63, 61, "افزودن گروه سوال" },
                    { 64, 61, "ویرایش گروه سوال" },
                    { 65, 61, "حذف گروه سوال" },
                    { 66, 62, "افزودن سوال" },
                    { 67, 62, "ویرایش سوال" },
                    { 68, 62, "حذف سوال" }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RP_Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 59, 59, 1 },
                    { 61, 61, 1 },
                    { 39, 39, 1 },
                    { 62, 62, 1 },
                    { 70, 70, 1 },
                    { 71, 71, 1 },
                    { 57, 57, 1 },
                    { 40, 40, 1 },
                    { 4, 4, 1 },
                    { 37, 37, 1 },
                    { 5, 5, 1 },
                    { 6, 6, 1 },
                    { 10, 10, 1 },
                    { 11, 11, 1 },
                    { 7, 7, 1 },
                    { 8, 8, 1 },
                    { 9, 9, 1 },
                    { 13, 13, 1 },
                    { 14, 14, 1 },
                    { 15, 15, 1 },
                    { 17, 17, 1 },
                    { 18, 18, 1 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RP_Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 73, 73, 1 },
                    { 19, 19, 1 },
                    { 21, 21, 1 },
                    { 22, 22, 1 },
                    { 24, 24, 1 },
                    { 25, 25, 1 },
                    { 26, 26, 1 },
                    { 27, 27, 1 },
                    { 29, 29, 1 },
                    { 30, 30, 1 },
                    { 31, 31, 1 },
                    { 33, 33, 1 },
                    { 34, 34, 1 },
                    { 36, 36, 1 },
                    { 20, 20, 1 },
                    { 74, 74, 1 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RP_Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 41, 41, 1 },
                    { 66, 66, 1 },
                    { 65, 65, 1 },
                    { 64, 64, 1 },
                    { 63, 63, 1 },
                    { 54, 54, 1 },
                    { 53, 53, 1 },
                    { 52, 52, 1 },
                    { 51, 51, 1 },
                    { 42, 42, 1 },
                    { 50, 50, 1 },
                    { 49, 49, 1 },
                    { 48, 48, 1 },
                    { 47, 47, 1 },
                    { 46, 46, 1 },
                    { 45, 45, 1 },
                    { 44, 44, 1 },
                    { 43, 43, 1 },
                    { 67, 67, 1 },
                    { 68, 68, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorProduct_ProductsProductId",
                table: "ColorProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_FaqGroupId",
                table: "Faqs",
                column: "FaqGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_ProductId",
                table: "FavoriteProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_ParentId",
                table: "Permission",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_ProductId",
                table: "ProductComments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_UserId",
                table: "ProductComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroups_ParentId",
                table: "ProductGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLevels_LevelPL_Id",
                table: "ProductLevels",
                column: "LevelPL_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLevels_ProductId",
                table: "ProductLevels",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupId",
                table: "Products",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTitle",
                table: "Products",
                column: "ProductTitle");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubGroup",
                table: "Products",
                column: "SubGroup");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_ProductId",
                table: "ProductSizes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_SizePS_Id",
                table: "ProductSizes",
                column: "SizePS_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountCodes_DiscountId",
                table: "UserDiscountCodes",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountCodes_UserId",
                table: "UserDiscountCodes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_BrowserVisitorBrowserId",
                table: "Visitors",
                column: "BrowserVisitorBrowserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_OperationSystemVisitorOSId",
                table: "Visitors",
                column: "OperationSystemVisitorOSId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_VisitorDeviceId",
                table: "Visitors",
                column: "VisitorDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_WalletTypeTypeId",
                table: "Wallets",
                column: "WalletTypeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "ColorProduct");

            migrationBuilder.DropTable(
                name: "contactUsConections");

            migrationBuilder.DropTable(
                name: "ContactUsInfos");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "FavoriteProducts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Privacies");

            migrationBuilder.DropTable(
                name: "ProductComments");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductLevels");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "UserDiscountCodes");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "FaqGroups");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "VisitorDevices");

            migrationBuilder.DropTable(
                name: "VisitorOs");

            migrationBuilder.DropTable(
                name: "VisitorVersions");

            migrationBuilder.DropTable(
                name: "WalletTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductGroups");
        }
    }
}
