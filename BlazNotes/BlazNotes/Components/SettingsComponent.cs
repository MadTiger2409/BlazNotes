using BlazNotes.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazNotes.Components
{
    public class SettingsComponent : BaseComponent
    {
        [Inject]
        protected AppState appState { get; set; }
        protected bool IsLight { get; set; }

        protected override async Task OnInitAsync()
        {
            await Task.FromResult(IsLight = Theme == "light");
        }

        protected async Task ChangeClass()
        {
            IsLight = !IsLight;

            if (IsLight == true)
            {
                await appState.SetThemeAsync("light");
            }
            else
            {
                await appState.SetThemeAsync("dark");
            }
        }
    }
}
