using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;
using AdoProject.Repository.Implementations;
using AdoProject.Services.Interface;

namespace AdoProject.Services.Implementations
{

    public class DepositService : IDepositService
    {
        public static DepositRepository _depositRepository = new DepositRepository();
        public static WalletRepository _walletRepository = new WalletRepository();

        public Deposit Create(double amount, string accountNumber, int pin)
        {
             var wallet = _walletRepository.Get(accountNumber);
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
            Deposit deposit = new Deposit
            {
                Amount = amount,
                WalletId = wallet.Id,
                UserId = wallet.UserId,
            };
            _depositRepository.Create(deposit);
            // _walletRepository.UpdateMoneyBalance(accountNumber,amount);
            return deposit;

        }
    }
}