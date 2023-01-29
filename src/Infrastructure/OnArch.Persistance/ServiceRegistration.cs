using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnArch.Application.Abstraction.Repository;
using OnArch.Persistance.Context;
using OnArch.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnArch.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceRegistration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("memoryDb"));

            serviceCollection.AddTransient<IProductRepository, ProductRepository>();

            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}



//public static void AddPersistanceRegistration(this IServiceCollection serviceCollection, IConfiguration configuration)
//{
//    serviceCollection.AddDbContext<ApplicationDbContext>(opt =>
//    {
//        opt.UseSqlServer(configuration.GetConnectionString("cnnstr"));
//    });

//    serviceCollection.AddTransient<IProductRepository, ProductRepository>();
//}