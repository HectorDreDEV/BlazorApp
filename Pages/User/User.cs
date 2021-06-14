using BlazorApp.Components;
using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages.User
{
    public partial class User
    {
        public List<UserModel> Users { get; set; } = new List<UserModel>();
        [Inject]
        public IUserService UserService { get; set; }
        protected AddUserComponent AddUserComponent { get; set; }
        protected async override Task OnInitializedAsync() 
        { 
            Users = await UserService.GetUsers();
        }
        protected void AddUser()
        {
            AddUserComponent.ShowDialog();
        }
        protected async Task Reload()
        {
            Users = await UserService.GetUsers();
            StateHasChanged();
        }
    }
}
