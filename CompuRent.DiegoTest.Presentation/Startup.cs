namespace CompuRent.DiegoTest.Presentation
{
    using CompuRent.DiegoTest.Services.BL;
    using CompuRent.DiegoTest.Services.BL.Facades;
    using CompuRent.DiegoTest.Services.DAL;
    using CompuRent.DiegoTest.Services.DAL.Repositories;
    using CompuRent.DiegoTest.Services.DAL.Repositories.Facades;
    using CompuRent.DiegoTest.Services.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;

    /// <summary>
    /// Startup Class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            ////Configure Session Cookie
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".CompuRent.Diego.Test.SessionCookie";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
            });

            ////Seed Database
            services.AddTransient<SeederDataBaseService>();
            ////Configure Http Context
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            ////Configure Injection Services
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISearchServiceBL, SearchServiceBL>();
            services.AddScoped<IAccountServiceBL, AccountServiceBL>();
            services.AddScoped<IShopingServiceBL, ShopingServiceBL>();
            
            ////Configure Context
            services.AddDbContext<MusicRadioIncDbContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("MusicRadioInc"), x => x.MigrationsAssembly("CompuRent.DiegoTest.Services"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
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

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
