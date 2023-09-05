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
    public class DepositRepository : IDepositRepository
    {
        private readonly DBContext _context = new DBContext();
        public string Create(Deposit deposit)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($" insert into  deposit (Id, Amount, UserId, WalletId, IsDeleted, DateCreated) values ({deposit.Id}, {deposit.Amount}, '{deposit.UserId}', {deposit.WalletId}, '{deposit.IsDeleted}', '{deposit.DateCreated}' );", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return "deposit  Created Successfully!!!";
                }
                else
                {
                    return "deposit  not created";
                }
            }
        }

        public Deposit Get(string id)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from deposit where Id = @id;", con);
                command.Parameters.AddWithValue("id", id);
                var row = command.ExecuteReader();
                Deposit deposit = new Deposit();
                while (row.Read())
                {
                    deposit.Id = Convert.ToInt32(row[0]);
                    deposit.Amount = Convert.ToInt32(row[1]);
                    deposit.UserId = Convert.ToString(row[2]);
                    deposit.WalletId = Convert.ToInt32(row[3]);
                    deposit.IsDeleted = Convert.ToString(row[4]);
                    deposit.DateCreated = Convert.ToString(row[5]);
                }
                return deposit;

            }
        }
        public List<Deposit> GetAll()
        {
            try
            {
                using (var con = _context.Connection())
                {
                    con.Open();
                    var command = new MySqlCommand($"select * from deposit", con);
                    var row = command.ExecuteReader();
                    List<Deposit> deposits = new List<Deposit>();
                    while (row.Read())
                    {
                        Deposit deposit = new Deposit();

                        deposit.Id = Convert.ToInt32(row[0]);
                        deposit.Amount = Convert.ToInt32(row[1]);
                        deposit.UserId = Convert.ToString(row[2]);
                        deposit.WalletId = Convert.ToInt32(row[3]);
                        deposit.IsDeleted = Convert.ToString(row[4]);
                        deposit.DateCreated = Convert.ToString(row[5]);
                        deposits.Add(deposit);
                    }
                    return deposits;
                }

            }
            catch (System.Exception)
            {

                return null;
            }
        }
    }
}