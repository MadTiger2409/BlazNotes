using BlazNotes.Commands;
using BlazNotes.Services.Interfaces;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazNotes.Components
{
    public class AddNoteComponent : BaseComponent
    {
        protected CreateNoteCommand command = new CreateNoteCommand();

        protected async Task AddNoteAsync()
        {
            try
            {
                await noteService.CreateAsync(command.Title, command.Description);
                toastService.ShowSuccess("Note added!", "Success");
            }
            catch (Exception)
            {
                toastService.ShowError("Something went wrong!", "Failed");
            }
        }

        protected async Task ResetFormAsync()
        {
            await Task.FromResult(command = new CreateNoteCommand());
        }
    }
}
