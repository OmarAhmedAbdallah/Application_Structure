using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace App.Web.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMvc(this IServiceCollection services)
        {

            //need to be search
            services.AddControllersWithViews(Options => Options
            .Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            ); 
            services.AddRazorPages();
            return services;
        }
    }
}
