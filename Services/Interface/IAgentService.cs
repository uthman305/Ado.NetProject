using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Services.Interface
{
    public interface IAgentService
    {
        Agent Create(string name, string email, string password, string phoneNumber,int gend, int pin);
    }
}