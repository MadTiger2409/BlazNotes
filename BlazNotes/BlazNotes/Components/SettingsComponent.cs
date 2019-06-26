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

        protected bool isLight;

        protected override void OnInit()
        {
            isLight = Theme.Equals("light");
        }

        protected async Task ChangeClass()
        {
            isLight = !isLight;

            if (isLight == true)
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
