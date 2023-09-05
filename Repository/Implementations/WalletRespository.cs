using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Data;
using AdoProject.Model.Entities;
using AdoProject.Repository.Interface;
using MySqlConnector;

namespace AdoProject.Repository.Implementations
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DBContext _context = new DBContext();

        public string Create(Wallet wallet)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"insert into wallet (Id, UserId, MoneyBalance, CardBalance, AccountNumber, Pin, IsDeleted, DateCreated ) values ({wallet.Id} , '{wallet.UserId}', {wallet.MoneyBalance}, {wallet.CardBalance},  '{wallet.AccountNumber}',{wallet.Pin},'{wallet.IsDeleted}', '{wallet.DateCreated}');", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return "wallet Created Successfully!!!";
                }
                else
                {
                    return "wallet not created";
                }
            }
        }
        public Wallet Get(string accountNumber)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from wallet where AccountNumber = @accountNumber;", con);
                command.Parameters.AddWithValue("accountNumber", accountNumber);
                var row = command.ExecuteReader();
                Wallet wallet = new Wallet();
                while (row.Read())
                {
                    wallet.Id = Convert.ToInt16(row[0]);
                    wallet.UserId = Convert.ToString(row[1]);
                    wallet.MoneyBalance = Convert.ToDouble(row[2]);
                    wallet.CardBalance = Convert.ToDouble(row[3]);
                    wallet.AccountNumber = Convert.ToString(row[4]);
                    wallet.Pin = Convert.ToInt16(row[5]);
                    wallet.IsDeleted = Convert.ToString(row[6]);
                    wallet.DateCreated = Convert.ToString(row[7]);
                }
                return wallet;

            }
        }
        public List<Wallet> GetAll()
        {
            try
            {
                using (var con = _context.Connection())
                {
                    con.Open();
                    var command = new MySqlCommand($"select * from wallet", con);
                    var row = command.ExecuteReader();
                    List<Wallet> wallets = new List<Wallet>();
                    while (row.Read())
                    {
                        Wallet wallet = new Wallet();

                        wallet.Id = Convert.ToInt16(row[0]);
                        wallet.UserId = Convert.ToString(row[1]);
                        wallet.MoneyBalance = Convert.ToDouble(row[2]);
                        wallet.CardBalance = Convert.ToDouble(row[3]);
                        wallet.AccountNumber = Convert.ToString(row[4]);
                        wallet.Pin = Convert.ToInt16(row[5]);
                        wallet.IsDeleted = Convert.ToString(row[6]);
                        wallet.DateCreated = Convert.ToString(row[7]);
                        wallets.Add(wallet);
                    }
                    return wallets;
                }
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public string UpdateMoneyBalance(string accountNumber, double balance)
        {
            using (var con = _context.Connection())
            {
                var presentBalance = Get(accountNumber).MoneyBalance;
                con.Open();
                var command = new MySqlCommand($"update Wallet set MoneyBalance = {presentBalance += balance} where AccountNumber = '{accountNumber}'", con);
                command.Parameters.AddWithValue("Id", accountNumber);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return "Balance updated Succesfully!!!";
                }
                else
                {
                    return "Balance not updated!!!";
                }
            }
        }

        public string UpdateCardBalance(string accountNumber, double balance)
        {
            using (var con = _context.Connection())
            {
                var presentBalance = Get(accountNumber).CardBalance;
                if (balance > 0)
                {
                    con.Open();
                    var command = new MySqlCommand($"update Wallet set CardBalance = {presentBalance += balance} where AccountNumber = '{accountNumber}'", con);
                    command.Parameters.AddWithValue("Id", accountNumber);
                    var row = command.ExecuteNonQuery();
                    if (row != -1)
                    {
                        return "Balance updated Succesfully!!!";
                    }
                    else
                    {
                        return "Balance not updated!!!";
                    }

                }
                return "";

            }
        }

        public string UpdatePurchase(string accountNumber, string selleracc, double balance)
        {
            using (var con = _context.Connection())
            {
                var buyerMoneyBalance = Get(accountNumber).MoneyBalance;
                var buyerCardBalance = Get(accountNumber).CardBalance;
                var sellerCardBalance = Get(selleracc).CardBalance;
                 var sellerMoneyBalance = Get(selleracc).MoneyBalance;
                var sellerid = Get(selleracc).Id;
                var buyerid = Get(accountNumber).Id;
                if (balance > 0 &&  sellerCardBalance >= balance && buyerMoneyBalance >= balance)
                {
                    con.Open();
                    var command = new MySqlCommand($"update Wallet set MoneyBalance = {buyerMoneyBalance -= balance},  CardBalance = {buyerCardBalance += balance}  where Id = {buyerid}", con);
                    command.Parameters.AddWithValue("Id", buyerid);
                    command.Parameters.AddWithValue("AccountNumber", accountNumber);
                    var row = command.ExecuteNonQuery();
                    if (row != -1)
                    {
                       
                        var commands = new MySqlCommand($"update Wallet set MoneyBalance = {sellerMoneyBalance += balance}, CardBalance = {sellerCardBalance -= balance}  where Id = {sellerid}", con);
                        commands.Parameters.AddWithValue("Id", sellerid);
                        commands.Parameters.AddWithValue("AccountNumber", selleracc);
                        var rows = commands.ExecuteNonQuery();
                         return "Balance updated Succesfully!!!";

                    }
                    else
                    {
                        return "Balance not updated!!!";
                    }
                }
                return " ";
            }
        }
    }
}