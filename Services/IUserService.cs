using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetById(string id);
        Task<int> Update(UserModel model);
        Task<int> Delete(string id);
        Task<int> Create(UserModel model);
    }
}
