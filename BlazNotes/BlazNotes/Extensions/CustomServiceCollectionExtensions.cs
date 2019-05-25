using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazNotes.Extensions
{
    public static class CustomServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazoredToastService(this IServiceCollection services)
        {
            return AddBlazoredToastService(services, new ToastOptions());
        }

        public static IServiceCollection AddBlazoredToastService(this IServiceCollection services, Action<ToastOptions> toastOptionsAction)
        {
            if (toastOptionsAction == null) throw new ArgumentNullException(nameof(toastOptionsAction));

            var toastOptions = new ToastOptions();
            toastOptionsAction(toastOptions);

            return AddBlazoredToastService(services, toastOptions);
        }

        public static IServiceCollection AddBlazoredToastService(this IServiceCollection services, ToastOptions toastOptions)
        {
            if (toastOptions == null) throw new ArgumentNullException(nameof(toastOptions));

            services.AddTransient<IToastService>(builder => new ToastService(toastOptions));

            return services;
        }
    }
}
