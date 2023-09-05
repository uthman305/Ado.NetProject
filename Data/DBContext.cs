using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace AdoProject.Data
{
    public class DBContext
    {
        public string connectionString = "Server = localhost; user = root; database = airtimeapp; password = Uthman!10";
        public MySqlConnection Connection()
        {
            return new MySqlConnection(connectionString);
        }
        public void UserTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("CREATE TABLE IF NOT EXISTS user (Id INT AUTO_INCREMENT PRIMARY KEY, UserId VARCHAR(25), Name VARCHAR(20), Email VARCHAR(20), Password VARCHAR(20), PhoneNumber VARCHAR(16), Gender TINYINT, Role VARCHAR(20), IsDeleted VARCHAR(25), DateCreated VARCHAR(150))", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    Console.WriteLine("Table Created Successfully!!!");
                }
                else
                {
                    Console.WriteLine("Table not created");
                }
            }
        }

        public void AgentTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("CREATE TABLE IF NOT EXISTS agent (Id INT AUTO_INCREMENT PRIMARY KEY, UserId VARCHAR(20), WalletId INT, IsDeleted VARCHAR(25), DateCreated VARCHAR(150))", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    Console.WriteLine("Table Created Successfully!!!");
                }
                else
                {
                    Console.WriteLine("Table not created");
                }
            }
        }

        public void WalletTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("CREATE TABLE IF NOT EXISTS wallet (Id INT AUTO_INCREMENT PRIMARY KEY, UserId VARCHAR(20), MoneyBalance DOUBLE, CardBalance DOUBLE, AccountNumber VARCHAR(10), Pin INT, IsDeleted VARCHAR(25), DateCreated VARCHAR(150))", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    Console.WriteLine("Table Created Successfully!!!");
                }
                else
                {
                    Console.WriteLine("Table not created");
                }
            }
        }

        public void CustomerTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("CREATE TABLE IF NOT EXISTS customer (Id INT AUTO_INCREMENT PRIMARY KEY, UserId VARCHAR(20), WalletId INT, IsDeleted VARCHAR(25), DateCreated VARCHAR(150))", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    Console.WriteLine("Table Created Successfully!!!");
                }
                else
                {
                    Console.WriteLine("Table not created");
                }
            }
        }

        public void CompanyTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("CREATE TABLE IF NOT EXISTS company (Id INT AUTO_INCREMENT PRIMARY KEY, WalletId INT, Name VARCHAR(30), IsDeleted VARCHAR(25), DateCreated VARCHAR(150))", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    Console.WriteLine("Table Created Successfully!!!");
                }
                else
                {
                    Console.WriteLine("Table not created");
                }
            }
        }

        public void CompanyDirectorTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("CREATE TABLE IF NOT EXISTS companyDirector (Id INT AUTO_INCREMENT PRIMARY KEY, UserId VARCHAR(20), CompanyId INT, WalletId INT, IsDeleted VARCHAR(25), DateCreated VARCHAR(150))", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    Console.WriteLine("Table Created Successfully!!!");
                }
                else
                {
                    Console.WriteLine("Table not created");
                }
            }
        }

        public void DepositTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("CREATE TABLE IF NOT EXISTS deposit (Id INT AUTO_INCREMENT PRIMARY KEY, Amount DOUBLE, UserId VARCHAR(20), WalletId INT, IsDeleted VARCHAR(25), DateCreated VARCHAR(150))", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    Console.WriteLine("Table Created Successfully!!!");
                }
                else
                {
                    Console.WriteLine("Table not created");
                }
            }
        }

        public void PurchaseTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("CREATE TABLE IF NOT EXISTS purchase (Id INT AUTO_INCREMENT PRIMARY KEY, Amount DOUBLE, UserId VARCHAR(20), WalletId INT, IsDeleted VARCHAR(25), DateCreated VARCHAR(150))", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    Console.WriteLine("Table Created Successfully!!!");
                }
                else
                {
                    Console.WriteLine("Table not created");
                }
            }
        }
        // public void UserTable()
        // {
        //     using (var con = Connection())
        //     {
        //         con.Open();
        //         var command = new MySqlCommand("CREATE TABLE IF NOT EXISTS user (Id INT AUTO_INCREMENT, UserId VARCHAR(25), Name VARCHAR(20), Email VARCHAR(20), Password VARCHAR(20), PhoneNumber VARCHAR(16), Gender TINYINT, Role VARCHAR(20), IsDeleted TINYINT, DateCreated VARCHAR(150))", con);
        //         var row = command.ExecuteNonQuery();
        //         if (row != -1)
        //         {
        //             Console.WriteLine("Table Created Successfully!!!");
        //         }
        //         else
        //         {
        //             Console.WriteLine("Table not created");
        //         }
        //     }
        // }

        // public void AgentTable()
        // {
        //     using (var con = Connection())
        //     {
        //         con.Open();
        //         var command = new MySqlCommand("create table if not exists agent (Id int AUTO_INCREMENT, UserId varchar(20), WalletId int,  IsDeleted tinyint, DateCreated varchar(150) )", con);
        //         var row = command.ExecuteNonQuery();
        //         if (row != -1)
        //         {
        //             Console.WriteLine("Table Created Successfully!!!");
        //         }

        //         else
        //         {
        //             Console.WriteLine("Table not created");
        //         }
        //     }
        // }
        // public void WalletTable()
        // {
        //     using (var con = Connection())
        //     {
        //         con.Open();
        //         var command = new MySqlCommand("create table if not exists wallet (Id int AUTO_INCREMENT, UserId varchar(20),MoneyBalance double, CardBalance double, AccountNumber varchar(10), Pin int, IsDeleted tinyint, DateCreated varchar(150))", con);
        //         var row = command.ExecuteNonQuery();
        //         if (row != -1)
        //         {
        //             Console.WriteLine("Table Created Successfully!!!");
        //         }

        //         else
        //         {
        //             Console.WriteLine("Table not created");
        //         }
        //     }
        // }
        // public void CustomerTable()
        // {
        //     using (var con = Connection())
        //     {
        //         con.Open();
        //         var command = new MySqlCommand("create table if not exists customer (Id int AUTO_INCREMENT, UserId varchar(20), WalletId int, IsDeleted tinyint, DateCreated varchar(150))", con);
        //         var row = command.ExecuteNonQuery();
        //         if (row != -1)
        //         {
        //             Console.WriteLine("Table Created Successfully!!!");
        //         }

        //         else
        //         {
        //             Console.WriteLine("Table not created");
        //         }
        //     }
        // }

        // public void CompanyTable()
        // {
        //     using (var con = Connection())
        //     {
        //         con.Open();
        //         var command = new MySqlCommand("create table if not exists company (Id int AUTO_INCREMENT, WalletId int, Name varchar(30) IsDeleted tinyint, DateCreated varchar(150))", con);
        //         var row = command.ExecuteNonQuery();
        //         if (row != -1)
        //         {
        //             Console.WriteLine("Table Created Successfully!!!");
        //         }

        //         else
        //         {
        //             Console.WriteLine("Table not created");
        //         }
        //     }
        // }
        // public void CompanyDirectorTable()
        // {
        //     using (var con = Connection())
        //     {
        //         con.Open();
        //         var command = new MySqlCommand("create table if not exists companyDirector (Id int AUTO_INCREMENT, UserId varchar(20), CompanyId int, WalletId int, IsDeleted tinyint, DateCreated varchar(150))", con);
        //         var row = command.ExecuteNonQuery();
        //         if (row != -1)
        //         {
        //             Console.WriteLine("Table Created Successfully!!!");
        //         }

        //         else
        //         {
        //             Console.WriteLine("Table not created");
        //         }
        //     }
        // }
        // public void DepositTable()
        // {
        //     using (var con = Connection())
        //     {
        //         con.Open();
        //         var command = new MySqlCommand("create table if not exists deposit (Id int AUTO_INCREMENT, Amount double, UserId varchar(20), WalletId int, IsDeleted tinyint, DateCreated varchar(150))", con);
        //         var row = command.ExecuteNonQuery();
        //         if (row != -1)
        //         {
        //             Console.WriteLine("Table Created Successfully!!!");
        //         }

        //         else
        //         {
        //             Console.WriteLine("Table not created");
        //         }
        //     }
        // }
        // public void PurchaseTable()
        // {
        //     using (var con = Connection())
        //     {
        //         con.Open();
        //         var command = new MySqlCommand("create table if not exists purchase (Id int AUTO_INCREMENT, Amount double, UserId varchar(20), WalletId int, IsDeleted tinyint, DateCreated varchar(150))", con);
        //         var row = command.ExecuteNonQuery();
        //         if (row != -1)
        //         {
        //             Console.WriteLine("Table Created Successfully!!!");
        //         }

        //         else
        //         {
        //             Console.WriteLine("Table not created");
        //         }
        //     }
        // }
        // public void RoleTable()
        // {
        //     using (var con = Connection())
        //     {
        //         con.Open();
        //         var command = new MySqlCommand("create table if not exists role (Id int, Name varchar(25), IsDeleted tinyint, DateCreated varchar(150))", con);
        //         var row = command.ExecuteNonQuery();
        //         if (row != -1)
        //         {
        //             Console.WriteLine("Table Created Successfully!!!");
        //         }

        //         else
        //         {
        //             Console.WriteLine("Table not created");
        //         }
        //     }

        // }
    }
}

