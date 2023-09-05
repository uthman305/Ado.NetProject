using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Repository.Interface
{
    public interface ICompanyDirectorRepository
    {
        string Create(CompanyDirector companyDirector);
        CompanyDirector Get(string id);
        List<CompanyDirector> GetAll();
    }
}