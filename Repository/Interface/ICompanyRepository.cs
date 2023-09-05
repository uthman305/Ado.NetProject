using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Repository.Interface
{
    public interface ICompanyRepository
    {
        string Create(Company company);
        Company Get(string id);
        List<Company> GetAll();
    }
}