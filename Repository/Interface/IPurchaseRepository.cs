using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Repository.Interface
{
    public interface IPurchaseRepository
    {
        string Create(Purchase purchase);
        Purchase Get(string id);
        List<Purchase> GetAll();
    }
}