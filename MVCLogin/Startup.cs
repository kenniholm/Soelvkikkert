using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using MVCLogin.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using MVCLogin.Middleware;

namespace MVCLogin
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthorization(options =>
                options.AddPolicy("AdminAccess", policy => policy.RequireRole("Administrator")));

            services
                .AddDbContext<VitecContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("VitecContext")))
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("ApplicationDbContext")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddHttpClient();
            services.AddControllersWithViews();
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseNoRussian();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            CreateRoles(serviceProvider).Wait();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Administrator", "Employee" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }

                IdentityUser kasper = await userManager.FindByEmailAsync("kasper@hotmail.com");
                if (kasper == null)
                {
                    return;
                }
                await userManager.AddToRoleAsync(kasper, "Administrator");


                IdentityUser nikolaj = await userManager.FindByEmailAsync("nikolaj@hotmail.com");

                if (nikolaj == null)
                {
                    return;
                }

                await userManager.AddToRoleAsync(nikolaj, "Administrator");

                IdentityUser kenni = await userManager.FindByEmailAsync("kenni@hotmail.com");
                if (kenni == null)
                {
                    return;
                }

                await userManager.AddToRoleAsync(kenni, "Administrator");

                IdentityUser victor = await userManager.FindByEmailAsync("victor@hotmail.com");

                if (victor == null)
                {
                    return;
                }

                await userManager.AddToRoleAsync(victor, "Administrator");
            }

        }
    }
}
