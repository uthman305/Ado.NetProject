using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;
using AdoProject.Repository.Implementations;
using AdoProject.Repository.Interface;
using AdoProject.Services.Interface;

namespace AdoProject.Services.Implementations
{
    public class WalletService : IWalletService
    {
        public static IWalletRepository _walletRepository = new WalletRepository();
        public string Create(Wallet wallet)
        {
            throw new NotImplementedException();
        }

        public Wallet Get(string accountNumber)
        {
              var get = _walletRepository.Get(accountNumber);
               if(get != null)
               {
                    return get;
               }
               return null;
        }

        public List<Wallet> GetAll()
        {
            var wallet = _walletRepository.GetAll();
            if (wallet != null)
            {
                return wallet;
            }
            return null;
        }

        public string UpdateCardBalance(string accountNumber, double balance)
        {
            var updateCard = _walletRepository.UpdateCardBalance(accountNumber,balance);
            if (updateCard != null)
            {
                return updateCard;
            }
            return null;
        }

        public string UpdateMoneyBalance(string accountNumber, double balance)
        {
            var updateMoney = _walletRepository.UpdateMoneyBalance(accountNumber,balance);
            if (updateMoney != null)
            {
                return updateMoney;
            }
            return null;
        }

        public string UpdatePurchase(string accountNumber, string buyeracc, double balance)
        {
           var updatePurchase = _walletRepository.UpdatePurchase(accountNumber, buyeracc,balance);
           if (updatePurchase != null)
           {
            return updatePurchase;
           }
           return null;
        }

        public string GetBalance(string accountNumber,int pin)
        {
            var balance  = _walletRepository.Get(accountNumber);
            if (balance == null)
            {
                Console.WriteLine("incorrect details");
                return null;
            }
           var accountbalance =  $"Your Money balance is {balance.MoneyBalance} and your card balance is {balance.CardBalance}";
           return accountbalance;
        }
    }
}