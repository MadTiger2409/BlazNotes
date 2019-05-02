using BlazNotes.Models;
using BlazNotes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazNotes.Services
{
    public class NoteService : INoteService
    {
        public Task CreateAsync(string title, string description)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Note> ReadAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Note>> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
