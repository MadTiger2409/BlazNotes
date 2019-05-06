using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazNotes.Models
{
    public class Note
    {
        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }

        public Note() { }

        public Note(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
