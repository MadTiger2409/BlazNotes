using BlazNotes.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace BlazNotes.Helpers
{
    public class AppState
    {
        private IThemeService _themeService;

        public Action OnChange;

        public AppState(IThemeService themeService)
        {
            _themeService = themeService;
        }

        public async Task SetThemeAsync(string theme)
        {
            await _themeService.UpdateAsync(theme);
            NotifyStateChanged();
        }

        public async Task<string> GetThemeAsync() => await _themeService.ReadAsync();

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
