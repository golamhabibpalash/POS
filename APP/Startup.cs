using BLL.IManagers;
using BLL.Managers;
using DAL.IRepositories;
using DAL.Repositories;
using DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westwind.AspNetCore.LiveReload;

namespace APP
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
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddHealthChecks();

            services.AddDbContext<POSDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("POSConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<POSDbContext>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllersWithViews();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();

            services.AddTransient<IBrandManager, BrandManager>();
            services.AddTransient<IBrandRepository, BrandRepository>();

            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductColorManager, ProductColorManager>();
            services.AddTransient<IProductColorRepository, ProductColorRepository>();

            //services.AddTransient<IProductFeatureManager, ProductFeatureManager>();
            //services.AddTransient<IProductFeatureRepository, ProductFeatureRepository>();

            //services.AddTransient<IProductFeatureDetailManager, ProductFeatureDetailManager>();
            //services.AddTransient<IProductFeatureDetailRepository, ProductFeatureDetailRepository>();

            services.AddTransient<IProductSizeManager, ProductSizeManager>();
            services.AddTransient<IProductSizeRepository, ProductSizeRepository>();

            services.AddTransient<IProductTypeManager, ProductTypeManager>();
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();

            services.AddTransient<IPurchaseManager, PurchaseManager>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();

            services.AddTransient<IPurchaseDetailManager, PurchaseDetailManager>();
            services.AddTransient<IPurchaseDetailRepository, PurchaseDetailRepository>();

            //services.AddTransient<IPurchaseTypeManager, PurchaseTypeManager>();
            //services.AddTransient<IPurchaseTypeRepository, PurchaseTypeRepository>();

            services.AddTransient<ISaleManager, SaleManager>();
            services.AddTransient<ISaleRepository, SaleRepository>();

            //services.AddTransient<ISaleDetailManager, SaleManager>();
            //services.AddTransient<ISaleDetailRepository, SaleRepository>();

            //services.AddTransient<ISaleTypeManager, SaleTypeManager>();
            //services.AddTransient<ISaleTypeRepository, SaleTypeRepository>();

            services.AddTransient<ISupplierManager, SupplierManager>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();

            services.AddTransient<ISupplierTypeManager, SupplierTypeManager>();
            services.AddTransient<ISupplierTypeRepository, SupplierTypeRepository>();

            services.AddTransient<IUnitOfMeasureManager, UnitOfMeasureManager>();
            services.AddTransient<IUnitOfMeasureRepository, UnitOfMeasureRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Code for Live Reload
            //app.UseLiveReload();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
