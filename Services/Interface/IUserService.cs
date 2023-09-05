using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Services.Interface
{
    public interface IUserService
    {
        User Get(string email);
        List<User> GetAll();
        User Login(string password, string email);
    }
}