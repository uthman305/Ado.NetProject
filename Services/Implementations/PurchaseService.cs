using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;
using AdoProject.Repository.Implementations;
using AdoProject.Services.Interface;

namespace AdoProject.Services.Implementations
{

    public class PurchaseService : IPurchaseService
    {
        public static PurchaseRepository _purchaseRepository = new PurchaseRepository();
        public static WalletRepository _walletRepository = new WalletRepository();

        public Purchase Create(double amount, string accountNumber,string Selleracc, int pin)
        {

            var wallet = _walletRepository.Get(accountNumber);
            var swallet = _walletRepository.Get(Selleracc);
             if (amount < 0 )
            {
                System.Console.WriteLine("Amount must be greater than  0");
                return null;
            }
           if (wallet.Pin != pin)
           {
                 System.Console.WriteLine("pin is incorrect");
                return null;
           }
           if (amount > wallet.MoneyBalance )
            {
                System.Console.WriteLine("You don't have sufficient fund");
                return null;
            }
             if (amount > swallet.CardBalance )
            {
                System.Console.WriteLine("Seller doesnt have sufficient card");
                return null;
            }
             

            Purchase purchase = new Purchase
            {
                Amount = amount,
                WalletId = wallet.Id,
                UserId = wallet.UserId,
            };
            _purchaseRepository.Create(purchase);
            _walletRepository.UpdatePurchase(accountNumber,Selleracc,amount);
            return purchase;
        }
    }
}