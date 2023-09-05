using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Repository.Interface
{
    public interface IUserRepository
    {
        string Create(User user);
        User Get(string email);
        List<User> GetAll();
        // string Login(string password, string email);
    }
}