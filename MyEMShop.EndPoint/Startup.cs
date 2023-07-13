
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyEMShop.Application.Interfaces;
using MyEMShop.Application.Services;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyEMShop.EndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
                options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                }));
            });

            services.AddRazorPages();

            #region Configure Limit File For Mac & Linux
            services.Configure<FormOptions>(opt => opt.MultipartBodyLengthLimit = 52428800);
            #endregion

            #region Caching With SqlServer
            services.AddDistributedSqlServerCache(opt =>
            {
                opt.SchemaName = "dbo";
                opt.TableName = "CatchData";
                opt.ConnectionString = Configuration.GetConnectionString("BehDokhtConnectionString");
            });
            #endregion

            #region Context
            services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(Configuration.GetConnectionString("BehDokhtConnectionString")));
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
            #endregion

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                //----------------------------------------------------------------------------
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                //----------------------------------------------------------------------------
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
