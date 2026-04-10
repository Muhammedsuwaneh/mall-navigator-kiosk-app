using MallMapKiosk.Factory;
using MallMapKiosk.Factory.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallMapKiosk.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterService<T>(this IServiceCollection services) where T : class
        {
            services.AddTransient<T>();
            services.AddSingleton<Func<T>>(x => () => x.GetService<T>()!);
            services.AddSingleton<IAbstractFactory<T>, AbstractFactory<T>>();
        }
    }
}
