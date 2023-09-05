using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;
using AdoProject.Model.Enum;
using AdoProject.Repository.Implementations;
using AdoProject.Repository.Interface;
using AdoProject.Services.Interface;

namespace AdoProject.Services.Implementations
{
    public class UserService : IUserService
    {
        public static IUserRepository _userRepository = new UserRepository();
        public User Get(string email)
        {
             var get = _userRepository.Get(email);
               if(get != null)
               {
                    return get;
               }
               return null;
        }

        public List<User> GetAll()
        {
            var users = _userRepository.GetAll();
               if(users != null)
               {
                    return users;
               }
               return null;
          }
        

        public User Login(string email, string password)
        {
            var user = _userRepository.Get(email);
           
               if(email == user.Email && password == user.Password)
               {
                    return user;
               }
               return null;
        }
    }
}
        
