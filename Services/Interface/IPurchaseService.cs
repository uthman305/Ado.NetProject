using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Services.Interface
{
    public interface IPurchaseService
    {
        Purchase Create(double amount, string accountNumber,string Selleracc, int pin);
    }
}