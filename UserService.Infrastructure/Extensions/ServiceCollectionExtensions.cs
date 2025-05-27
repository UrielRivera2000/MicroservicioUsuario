using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Logging;


namespace UserService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLoggingAdapter(this IServiceCollection services)
        {
            services.AddScoped(typeof(ILoggerAdapter<>), typeof(Log4NetAdapter<>));
            return services;
        }
    }
}
