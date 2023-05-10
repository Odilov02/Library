using Application.Abstaction;
using Infrastructure.DataAcses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("default")));
            service.AddScoped<IAplicationDbContext, AppDbContext>();
            return service;
        }
    }
}