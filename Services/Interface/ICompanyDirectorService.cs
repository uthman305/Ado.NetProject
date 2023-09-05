using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Services.Interface
{
    public interface ICompanyDirectorService
    {
        CompanyDirector Create(string name, string email, string password, string phoneNumber,int gend, int pin,string companyName);
    }
}