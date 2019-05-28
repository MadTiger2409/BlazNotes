using System.ComponentModel.DataAnnotations;

namespace BlazNotes.Commands
{
    public class CreateNoteCommand
    {
        [Required(ErrorMessage = "Title is required.", AllowEmptyStrings = false)]
        [MinLength(1, ErrorMessage = "Title must be at least 1 character long.")]
        [MaxLength(50, ErrorMessage = "Title can't be longer than 50 characters.")]
        [Editable(true)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.", AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "Description must be at least 3 characters long.")]
        [MaxLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        [Editable(true)]
        public string Description { get; set; }
    }
}