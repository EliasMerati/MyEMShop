using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Application.Services;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Web.Filters;
using WebMarkupMin.AspNetCore7;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
//services.AddControllersWithViews();
services.AddRazorPages();

#region Authentication
services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(opt =>
{
    opt.LoginPath = "/Login";
    opt.LogoutPath = "/LogOut";
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
});
#endregion

#region Context
services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("BehDokhtConnectionString")));
#endregion

#region Services
services.AddScoped<IAccountServices, AccountServices>();
services.AddScoped<IUserPannelService, UserPannelService>();
services.AddScoped<IViewRenderService, RenderViewToString>();
services.AddScoped<IUserWalletService, UserWalletService>();
services.AddScoped<IManageUserService, ManageUserService>();
services.AddScoped<IPermissionService, PermissionService>();
services.AddTransient<IProductService, ProductService>();
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<ISliderService, SliderService>();
services.AddScoped<IGroupService, GroupService>();
services.AddScoped<IDiscountService, DiscountService>();
services.AddScoped<ICommentService, CommentService>();
services.AddScoped<IFavoriteProductService, FavoriteProductService>();
services.AddScoped<ITaxService, TaxService>();
services.AddScoped<IBannerService, BannerService>();
services.AddScoped<IBigBannerService, BigBannerService>();
services.AddScoped<IPrivacyService, PrivacyService>();
services.AddScoped<ITermsService, TermsService>();
services.AddScoped<IFaqGroupService, FaqGroupService>();
services.AddScoped<IFaqService, FaqService>();
services.AddScoped<IContactUsConnectionService, ContactUsConnectionService>();
services.AddScoped<IContactUsInfoService, ContactUsInfoService>();
services.AddScoped<IAboutUsService, AboutUsService>();
services.AddScoped<IVisitorService, VisitorService>();
services.AddScoped<SaveVisitorsFilter>();
#endregion

#region Minifier For Html & Gzip
services.AddWebMarkupMin(opt =>
{
    opt.AllowMinificationInDevelopmentEnvironment = true;
    opt.AllowCompressionInDevelopmentEnvironment = true;
}).AddHtmlMinification(option =>
{
    option.MinificationSettings.RemoveHtmlComments = true;
    option.MinificationSettings.RemoveHtmlCommentsFromScriptsAndStyles = true;
    option.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
    option.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
    option.MinificationSettings.RemoveJsProtocolFromAttributes = true;
    option.MinificationSettings.RemoveJsTypeAttributes = true;
    option.MinificationSettings.RemoveOptionalEndTags = true;
    option.MinificationSettings.RemoveTagsWithoutContent = true;
    option.MinificationSettings.MinifyInlineJsCode = true;
    option.MinificationSettings.MinifyInlineCssCode = true;

}).AddHttpCompression();
#endregion

#region Solve Circle For JSON
//services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
#endregion

#region Configure Limit File For Mac & Linux
services.Configure<FormOptions>(opt => opt.MultipartBodyLengthLimit = 52428800);
#endregion

//#region Caching With SqlServer
//services.AddDistributedSqlServerCache(opt =>
//{
//    opt.SchemaName = "dbo";
//    opt.TableName = "CatchData";
//    opt.ConnectionString = Configuration.GetConnectionString("BehDokhtConnectionString");
//});
//#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseWebMarkupMin();

app.MapRazorPages();
app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Test}/{action=Index}/{id?}");
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute("Default", "{controller=Test}/{action=Index}/{id?}");
//});
app.Run();
