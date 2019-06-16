using BlazNotes.Services;
using BlazNotes.Services.Interfaces;
using Blazored.LocalStorage;
using Blazored.Toast;
using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazNotes
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<IThemeService, ThemeService>();
            services.AddTransient<ILocalStorageService, LocalStorageService>();

            services.AddBlazoredToast(options =>
            {
                options.Timeout = 10;
                options.Position = ToastPosition.BottomRight;
            });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
