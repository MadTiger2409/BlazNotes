using System.Threading.Tasks;

namespace BlazNotes.Services.Interfaces
{
    public interface IThemeService
    {
        Task CreateAsync(string theme = "light");
        Task<string> ReadAsync();
        Task UpdateAsync(string theme);
    }
}
