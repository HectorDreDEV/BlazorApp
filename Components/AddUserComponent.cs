using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Components
{
    public partial class AddUserComponent
    {
        public bool CanShow { get; set; } = false;
        public UserModel User { get; set; } = new UserModel();
        [Inject]
        public IUserService UserService { get; set; }
        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }
        protected async override Task OnInitializedAsync()
        {
            
        }
        public void ShowDialog()
        {
            CanShow = true;
            StateHasChanged();
        }
        public void CloseDialog()
        {
            CanShow = false;
            StateHasChanged();
        }
        protected async Task AddUser()
        {
            await UserService.Create(User);
            CanShow = false;
            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
