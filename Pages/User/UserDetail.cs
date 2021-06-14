using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages.User
{
    public partial class UserDetail
    {
        [Parameter]
        public string UserId { get; set; }
        public UserDetailModel User { get; set; } = new UserDetailModel();
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(UserId) && int.Parse(UserId) > 0)
            {
                var userResponse = await UserService.GetById(UserId);
                User.Id = userResponse.Id;
                User.FirstName = userResponse.FirstName;
                User.LastName = userResponse.LastName;
            }
        }

        protected void Save()
        {
            var model = new UserModel()
            {
                Id = User.Id,
                FirstName = User.FirstName,
                LastName = User.LastName
            };

            if (!string.IsNullOrEmpty(UserId) && int.Parse(UserId) > 0)
            {
                UserService.Update(model);
            }
            else
            {
                UserService.Create(model);
            }

            NavigationManager.NavigateTo("/users");
        }
    }
}
