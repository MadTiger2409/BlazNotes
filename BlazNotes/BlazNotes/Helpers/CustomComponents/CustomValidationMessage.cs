﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.RenderTree;

namespace BlazNotes.Helpers.CustomComponents
{
    public class CustomValidationMessage<T> : ComponentBase, IDisposable
    {
        private EditContext _previousEditContext;
        private Expression<Func<T>> _previousFieldAccessor;
        private readonly EventHandler<ValidationStateChangedEventArgs> _validationStateChangedHandler;
        private FieldIdentifier _fieldIdentifier;

        [CascadingParameter] EditContext CurrentEditContext { get; set; }

        /// <summary>
        /// Specifies the CSS class for this component.
        /// </summary
        [Parameter] public string Class { get; set; }

        /// <summary>
        /// Specifies the field for which validation messages should be displayed.
        /// </summary
        [Parameter] public Expression<Func<T>> For { get; private set; }

        /// <summary>`
        /// Constructs an instance of <see cref="ValidationMessage{T}"/>.
        /// </summary>
        public CustomValidationMessage()
        {
            _validationStateChangedHandler = (sender, eventArgs) => StateHasChanged();
        }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException($"{GetType()} requires a cascading parameter " +
                    $"of type {nameof(EditContext)}. For example, you can use {GetType()} inside " +
                    $"an {nameof(EditForm)}.");
            }

            if (For == null) // Not possible except if you manually specify T
            {
                throw new InvalidOperationException($"{GetType()} requires a value for the " +
                    $"{nameof(For)} parameter.");
            }

            else if (For != _previousFieldAccessor)
            {
                _fieldIdentifier = FieldIdentifier.Create(For);
                _previousFieldAccessor = For;
            }

            if (CurrentEditContext != _previousEditContext)
            {
                DetachValidationStateChangedListener();
                CurrentEditContext.OnValidationStateChanged += _validationStateChangedHandler;
                _previousEditContext = CurrentEditContext;
            }
        }

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            foreach (var message in CurrentEditContext.GetValidationMessages(_fieldIdentifier))
            {
                builder.OpenElement(0, "div");
                builder.AddAttribute(1, "class", Class);
                builder.AddContent(2, message);
                builder.CloseElement();
            }
        }

        private void HandleValidationStateChanged(object sender, ValidationStateChangedEventArgs eventArgs)
        {
            StateHasChanged();
        }

        void IDisposable.Dispose()
        {
            DetachValidationStateChangedListener();
        }

        private void DetachValidationStateChangedListener()
        {
            if (_previousEditContext != null)
            {
                _previousEditContext.OnValidationStateChanged -= _validationStateChangedHandler;
            }
        }
    }
}
