using KalaMarket.Core.GoogleRecaptcha;
using KalaMarket.Core.Service;
using KalaMarket.Core.Service.IService;
using KalaMarket.DataLayer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Kalamarket.Core.ExtentionMethod.RenderEmail;

namespace KalaMarket
{
    public class Startup
    {
        public const string Schema = "KalaMarket";
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            #region Database
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDbContext<KalaMarketContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("KalaMarket"));
            });
            #endregion

            #region Auth
            services.AddAuthentication(Schema)
                .AddCookie(Schema, option =>
                {
                    option.LoginPath = "/Account/Login";
                    option.LogoutPath = "/Account/Logout";
                    option.AccessDeniedPath = "/Account/Login";
                    option.ExpireTimeSpan = TimeSpan.FromDays(30);
                });
            #endregion

            #region IoC
            services.AddTransient<ISliderService, SliderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IGuaranteeService, GuaranteeService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IViewRenderService, RenderViewToString>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ISiteSettingService, SiteSettingService>();
            services.AddTransient<IGoogleRecaptcha, GoogleRecaptcha>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseStatusCodePagesWithRedirects("/Home/Error");
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Area", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
