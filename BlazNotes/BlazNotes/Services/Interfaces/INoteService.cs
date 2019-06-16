using BlazNotes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazNotes.Services.Interfaces
{
    public interface INoteService
    {
        Task CreateAsync(string title, string description);
        Task<Note> ReadAsync(int id);
        Task<List<Note>> ReadAsync();
        Task UpdateAsync(int id, string title, string description);
        Task DeleteAsync(int id);
    }
}
