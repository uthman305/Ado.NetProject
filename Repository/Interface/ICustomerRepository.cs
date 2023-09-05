using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Repository.Interface
{
    public interface ICustomerRepository
    {
        string Create(Customer customer);
        Customer Get(string id);
        List<Customer> GetAll();
    }
}