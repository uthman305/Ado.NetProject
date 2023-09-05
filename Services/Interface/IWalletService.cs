using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Services.Interface
{
    public interface IWalletService
    {
        string Create(Wallet wallet);
        Wallet Get(string accountNumber);
        List<Wallet> GetAll();
        string UpdateCardBalance(string accountNumber, double balance);
        string UpdateMoneyBalance(string accountNumber, double balance);
        string UpdatePurchase(string accountNumber, string buyeracc, double balance);
        string GetBalance(string accountNumber,int pin);
    }
}