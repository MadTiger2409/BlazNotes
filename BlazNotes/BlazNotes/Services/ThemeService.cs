using BlazNotes.Services.Interfaces;
using Blazored.LocalStorage;
using System;
using System.Threading.Tasks;

namespace BlazNotes.Services
{
    public class ThemeService : IThemeService
    {
        private ILocalStorageService _localStorage;
        private readonly string key;

        public ThemeService(ILocalStorageService localStorageService)
        {
            _localStorage = localStorageService;
            key = "theme";
        }

        public async Task CreateAsync(string theme = "dark")
            => await _localStorage.SetItemAsync(key, theme);

        public async Task<string> ReadAsync()
        {
            var theme = await _localStorage.GetItemAsync<string>(key);

            if (string.IsNullOrEmpty(theme))
                return "light";

            return theme;
        }

        public async Task UpdateAsync(string theme)
        {
            var savedTheme = await _localStorage.GetItemAsync<string>(key);

            if (string.IsNullOrEmpty(savedTheme))
                await CreateAsync(theme);

            await _localStorage.SetItemAsync(key, theme);
        }
    }
}
