using BlazNotes.Commands;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazNotes.Components
{
    public class EditNoteComponent : BaseComponent
    {
        [Parameter]
        protected int Id { get; set; }

        protected string title;
        protected string description;
        protected UpdateNoteCommand command;

        protected override async Task OnInitAsync()
        {
            command = new UpdateNoteCommand(await noteService.ReadAsync(Id));
            await SetRestoreVariables();
        }

        protected async Task UpdateNoteAsync()
        {
            try
            {
                await noteService.UpdateAsync(Id, command.Title, command.Description);
                toastService.ShowSuccess("Note updated!", "Success");
            }
            catch (Exception)
            {

                toastService.ShowError("Something went wrong!", "Failed");
            }
        }

        protected async Task SetRestoreVariables()
        {
            await Task.FromResult(title = command.Title);
            await Task.FromResult(description = command.Description);
        }

        protected async Task RestoreContentAsync()
        {
            await Task.FromResult(command = new UpdateNoteCommand());
            command.Title = title;
            command.Description = description;
        }
    }
}
