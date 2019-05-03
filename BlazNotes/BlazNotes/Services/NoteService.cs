using BlazNotes.Models;
using BlazNotes.Services.Interfaces;
using Blazor.Extensions.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazNotes.Services
{
    public class NoteService : INoteService
    {
        private readonly LocalStorage _localStorage;
        private readonly string key = "notes";

        public NoteService(LocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task CreateAsync(string title, string description)
        {
            int id = 1;
            var notes = new List<Note>();
            var notesArray = _localStorage.GetItem<List<Note>>(key).Result;

            if (notes.Count > 0)
                id += notes.Select(x => x.Id).Max();

            notes.Add(new Note(id, title, description));

            await _localStorage.SetItem<List<Note>>(key, notes);
        }

        public async Task DeleteAsync(int id)
        {
            var notes = await ReadAsync();
            notes.RemoveAll(x => x.Id == id);

            await _localStorage.SetItem<List<Note>>(key, notes);
        }

        public async Task<Note> ReadAsync(int id)
        {
            var notes = await ReadAsync();
            var note = notes.SingleOrDefault(x => x.Id == id);

            if (note == null)
                throw new Exception("There isn't a note with this id.");

            return note;
        }

        public async Task<List<Note>> ReadAsync()
        {
            var notes = await _localStorage.GetItem<List<Note>>(key);

            if (notes == null)
                throw new Exception("There aren't any notes in memory.");

            return notes;
        }

        public async Task UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
