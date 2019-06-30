using BlazNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazNotes.Components
{
    public class AllNotesComponent : BaseComponent
    {
        protected List<Note> notes = new List<Note>();

        protected override async Task OnInitAsync()
        {
            notes = await noteService.ReadAsync();
        }

        protected async Task DeleteAsync(int id)
        {
            try
            {
                await noteService.DeleteAsync(id);
                notes = await noteService.ReadAsync();
                base.StateHasChanged();
                toastService.ShowSuccess("Note deleted!", "Success");
            }
            catch (Exception)
            {
                toastService.ShowError("Something went wrong!", "Failed");
            }
        }
    }
}
