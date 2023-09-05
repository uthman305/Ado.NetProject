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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DBContext _context = new DBContext();

        public string Create(Customer customer)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($" insert into Customer (Id, UserId, WalletId, IsDeleted, DateCreated) values ({customer.Id},'{customer.UserId}', {customer.WalletId}, '{customer.IsDeleted}', '{customer.DateCreated}' );", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return "Customer Created Successfully!!!";
                }
                else
                {
                    return "Customer not created";
                }
            }
        }

        public Customer Get(string id)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from customer where Id = @id;", con);
                command.Parameters.AddWithValue("id", id);
                var row = command.ExecuteReader();
                Customer customer = new Customer();
                while (row.Read())
                {
                    customer.Id = Convert.ToInt32(row[0]);
                    customer.UserId = Convert.ToString(row[1]);
                    customer.WalletId = Convert.ToInt32(row[2]);
                    customer.IsDeleted = Convert.ToString(row[3]);
                    customer.DateCreated = Convert.ToString(row[4]);
                }
                return customer;

            }
        }
        public List<Customer> GetAll()
        {
            try
            {
                using (var con = _context.Connection())
                {
                    con.Open();
                    var command = new MySqlCommand($"select * from customer", con);
                    var row = command.ExecuteReader();
                    List<Customer> customers = new List<Customer>();
                    while (row.Read())
                    {
                        Customer customer = new Customer();

                        customer.Id = Convert.ToInt32(row[0]);
                        customer.UserId = Convert.ToString(row[1]);
                        customer.WalletId = Convert.ToInt32(row[2]);
                        customer.IsDeleted = Convert.ToString(row[3]);
                        customer.DateCreated = Convert.ToString(row[4]);

                        customers.Add(customer);
                    }
                    return customers;
                }
            }
            catch (System.Exception)
            {

                return null;
            }
        }

    }
}