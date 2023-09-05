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
    

    public class CompanyRepository : ICompanyRepository
    {
        private readonly DBContext _context = new DBContext();
        public string Create(Company company)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($" insert into  company (Id, WalletId, Name, IsDeleted, DateCreated ) values ({company.Id}, {company.WalletId}, '{company.CompanyName}', '{company.IsDeleted}', '{company.DateCreated}' );", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return "company  Created Successfully!!!";
                }
                else
                {
                    return "company  not created";
                }
            }
        }

        public Company Get(string id)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from company where Id = @id;", con);
                command.Parameters.AddWithValue("id", id);
                var row = command.ExecuteReader();
                Company company = new Company();
                while (row.Read())
                {
                    company.Id = Convert.ToInt32(row[0]);
                    company.WalletId = Convert.ToInt32(row[1]);
                    company.CompanyName = Convert.ToString(row[2]);
                    company.IsDeleted = Convert.ToString(row[3]);
                    company.DateCreated = Convert.ToString(row[4]);
                }
                return company;

            }
        }
        public List<Company> GetAll()
        {
            try
            {
                using (var con = _context.Connection())
                {
                    con.Open();
                    var command = new MySqlCommand($"select * from company", con);
                    var row = command.ExecuteReader();
                    List<Company> companys = new List<Company>();
                    while (row.Read())
                    {
                        Company company = new Company();

                        company.Id = Convert.ToInt32(row[0]);
                        company.WalletId = Convert.ToInt32(row[1]);
                        company.CompanyName = Convert.ToString(row[2]);
                        company.IsDeleted = Convert.ToString(row[3]);
                        company.DateCreated = Convert.ToString(row[4]);
                        companys.Add(company);
                    }
                    return companys;
                }

            }
            catch (System.Exception)
            {

                return null;
            }
        }
    }
}