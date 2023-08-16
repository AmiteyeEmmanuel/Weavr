using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using WeavrApi.Data; // Replace with the correct namespace for your data context
using WeavrApi.Services;
using YourNamespace.Controllers;
using YourNamespace.Models;
using YourNamespace.Services;

namespace WeavrApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<AccountService, AccountService>();
            services.AddScoped<IWEAVRService, WEAVRService>();
            // Add other services

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    internal class AccountService
    {
        internal Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public static explicit operator AccountService(AccountController.IAccountService v)
        {
            throw new NotImplementedException();
        }
    }
}
