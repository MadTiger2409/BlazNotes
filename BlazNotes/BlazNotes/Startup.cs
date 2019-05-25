using BlazNotes.Extensions;
using BlazNotes.Services;
using BlazNotes.Services.Interfaces;
using Blazored.LocalStorage;
using Blazored.Toast;
using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazNotes
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<ILocalStorageService, LocalStorageService>();

            services.AddBlazoredToastService(options =>
            {
                options.Timeout = 10;
                options.Position = ToastPosition.TopRight;
            });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
