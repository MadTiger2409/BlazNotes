using System.ComponentModel.DataAnnotations;

namespace BlazNotes.Commands
{
    public class CreateNoteCommand
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [Editable(true)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        [Editable(true)]
        public string Description { get; set; }
    }
}