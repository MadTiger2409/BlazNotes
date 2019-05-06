using BlazNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazNotes.Services.Interfaces
{
    public interface INoteService
    {
        Task CreateAsync(string title, string description);
        Task<Note> ReadAsync(int id);
        Task<Note[]> ReadAsync();
        Task UpdateAsync(int id);
        Task DeleteAsync(int id);
    }
}
