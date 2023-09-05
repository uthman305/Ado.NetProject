using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Data;
using AdoProject.Model.Entities;
using AdoProject.Model.Enum;
using AdoProject.Repository.Interface;
using MySqlConnector;

namespace AdoProject.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _context = new DBContext();

        public string Create(User user)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"insert into user (Id, UserId, Name, Email, Password,  PhoneNumber, Gender, Role, IsDeleted, DateCreated ) values ({user.Id}, '{user.UserId}' , '{user.Name}', '{user.Email}', '{user.Password}',  '{user.PhoneNumber}',{(int)user.Gender},'{user.Role}', '{user.IsDeleted}', '{user.DateCreated}');", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return "User Created Successfully!!!";
                }
                else
                {
                    return "User not created";
                }
            }
        }
        public User Get(string email)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from user where Email = @email;", con);
                command.Parameters.AddWithValue("@email", email);
                var row = command.ExecuteReader();
                User user = new User();
                while (row.Read())
                {
                    user.Id = Convert.ToInt16(row[0]);
                    user.UserId = Convert.ToString(row[1]);
                    user.Name = Convert.ToString(row[2]);
                    user.Email = Convert.ToString(row[3]);
                    user.Password = Convert.ToString(row[4]);
                    user.PhoneNumber = Convert.ToString(row[5]);
                    user.Gender = (Gender)Enum.Parse(typeof(Gender), (row[6].ToString()));
                    user.Role = Convert.ToString(row[7]);
                    user.IsDeleted = Convert.ToString(row[8]);
                    user.DateCreated = Convert.ToString(row[9]);
                }
                return user;

            }
        }
        public List<User> GetAll()
        {
            try
            {
                using (var con = _context.Connection())
                {
                    con.Open();
                    var command = new MySqlCommand($"select * from user", con);
                    var row = command.ExecuteReader();
                    List<User> users = new List<User>();
                    while (row.Read())
                    {
                        User user = new User();

                        user.Id = Convert.ToInt16(row[0]);
                        user.UserId = Convert.ToString(row[1]);
                        user.Name = Convert.ToString(row[2]);
                        user.Name = Convert.ToString(row[3]);
                        user.Password = Convert.ToString(row[4]);
                        user.PhoneNumber = Convert.ToString(row[5]);
                        user.Gender = (Gender)Enum.Parse(typeof(Gender), (row[6].ToString()));
                        user.Role = Convert.ToString(row[7]);
                        user.IsDeleted = Convert.ToString(row[8]);
                        user.DateCreated = Convert.ToString(row[9]);

                        users.Add(user);
                    }
                    return users;
                }
            }
            catch (System.Exception)
            {

                return null;
            }
        }
        //  public string Login(string password, string email)
        //   {
        //        using (var con = _context.Connection())
        //        {
        //             con.Open();
        //             var command = new MySqlCommand($"select count(*) from user where Password = {password} and Email = {email}", con);
        //             command.Parameters.AddWithValue("Password", password);
        //             command.Parameters.AddWithValue("Email", email);
        //             long exists = (long)(command.ExecuteScalar());
        //             if(exists > 0)
        //             {
        //                  return "Login succesful";
        //             }
        //             else
        //             {
        //                  return "Loin not succesfull";
        //             }
                    

        //        }
        //   }
    }
}