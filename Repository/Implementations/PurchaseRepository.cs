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
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DBContext _context = new DBContext();
        public string Create(Purchase purchase)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($" insert into  purchase (Id, Amount, UserId, WalletId, IsDeleted, DateCreated) values ({purchase.Id}, {purchase.Amount}, '{purchase.UserId}', {purchase.WalletId},       '{purchase.IsDeleted}', '{purchase.DateCreated}' );", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return "purchase  Created Successfully!!!";
                }
                else
                {
                    return "purchase  not created";
                }
            }
        }

        public Purchase Get(string id)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from purchase where Id = @id;", con);
                command.Parameters.AddWithValue("id", id);
                var row = command.ExecuteReader();
                Purchase purchase = new Purchase();
                while (row.Read())
                {
                    purchase.Id = Convert.ToInt32(row[0]);
                    purchase.Amount = Convert.ToInt32(row[1]);
                    purchase.UserId = Convert.ToString(row[2]);
                    purchase.WalletId = Convert.ToInt32(row[3]);
                    purchase.IsDeleted = Convert.ToString(row[4]);
                    purchase.DateCreated = Convert.ToString(row[5]);
                }
                return purchase;

            }
        }
        public List<Purchase> GetAll()
        {
            try
            {
                using (var con = _context.Connection())
                {
                    con.Open();
                    var command = new MySqlCommand($"select * from purchase", con);
                    var row = command.ExecuteReader();
                    List<Purchase> purchases = new List<Purchase>();
                    while (row.Read())
                    {
                        Purchase purchase = new Purchase();

                        purchase.Id = Convert.ToInt32(row[0]);
                        purchase.Amount = Convert.ToInt32(row[1]);
                        purchase.UserId = Convert.ToString(row[2]);
                        purchase.WalletId = Convert.ToInt32(row[3]);
                        purchase.IsDeleted = Convert.ToString(row[4]);
                        purchase.DateCreated = Convert.ToString(row[5]);
                        purchases.Add(purchase);
                    }
                    return purchases;
                }

            }
            catch (System.Exception)
            {

                return null;
            }
        }
    }
}