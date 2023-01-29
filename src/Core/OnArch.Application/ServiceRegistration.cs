using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnArch.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection serviceCollection)
        {
            var ass = Assembly.GetExecutingAssembly();
            serviceCollection.AddAutoMapper(ass);
            serviceCollection.AddMediatR(ass);
        }
    }
}
