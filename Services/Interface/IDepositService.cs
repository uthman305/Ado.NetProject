using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Services.Interface
{
    public interface IDepositService
    {
         Deposit Create(double amount, string accountNumber, int pin);
    }
}