using BlazNotes.Services.Interfaces;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazNotes.Components
{
    public class BaseComponent : ComponentBase
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        [Inject]
        protected IToastService toastService { get; set; }

        [Inject]
        protected INoteService noteService { get; set; }

        [CascadingParameter(Name = "Theme")]
        protected string Theme { get; set; }
    }
}
