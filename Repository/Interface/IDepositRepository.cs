using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Repository.Interface
{
    public interface IDepositRepository
    {
         string Create(Deposit deposit);
        Deposit Get(string id);
        List<Deposit> GetAll();
    }
}