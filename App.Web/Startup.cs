using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.Web.Infrastructure;
using App.Web.Data;
using App.Services;
using App.Services.Implementation;
using AutoMapper;
using App.Web.Controllers;

//in this project from nuget install AutoMapper.Extensions.Microsoft.Dependency
namespace App.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetDefualtConnectionString()));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAutoMapper(
                typeof(IArticleService).Assembly,
                typeof(HomeController).Assembly
                ) ;


            services.AddTransient<IArticleService, ArticleService>();

        
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.useExceptionHandling(env);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.useEndPoints();

            app.SeedData();

        }
    }
}
