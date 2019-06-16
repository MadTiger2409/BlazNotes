using BlazNotes.Models;
using BlazNotes.Services.Interfaces;
using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazNotes.Services
{
    public class NoteService : INoteService
    {
        private ILocalStorageService _localStorage;
        private readonly string key;

        public NoteService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            key = "notes";
        }

        public async Task CreateAsync(string title, string description)
        {
            int id = 1;
            var notes = await _localStorage.GetItemAsync<List<Note>>(key);

            if (notes == null)
                notes = new List<Note>();

            if (notes.Count > 0)
                id += notes.Select(x => x.Id).Max();

            notes.Add(new Note(id, title, description));

            await _localStorage.SetItemAsync(key, notes);
        }

        public async Task DeleteAsync(int id)
        {
            var notes = await ReadAsync();
            notes.RemoveAll(x => x.Id == id);

            await _localStorage.SetItemAsync(key, notes);
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
            var notes = await _localStorage.GetItemAsync<List<Note>>(key);

            if (notes == null)
                throw new Exception("There aren't any notes in memory.");

            return notes;
        }

        public async Task UpdateAsync(int id, string title, string description)
        {
            var notes = await ReadAsync();

            var note = notes.FirstOrDefault(x => x.Id == id);
            note.Update(title, description);

            await _localStorage.SetItemAsync(key, notes);
        }
    }
}
