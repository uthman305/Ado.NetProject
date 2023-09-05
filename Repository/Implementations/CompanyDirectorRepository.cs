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
    public class CompanyDirectorRepository : ICompanyDirectorRepository
    {
        private readonly DBContext _context = new DBContext();
        public string Create(CompanyDirector companyDirector)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($" insert into  companyDirector (Id, UserId, CompanyId, WalletId,  IsDeleted, DateCreated ) values ({companyDirector.Id},'{companyDirector.UserId}', {companyDirector.CompanyId}, {companyDirector.WalletId}, '{companyDirector.IsDeleted}', '{companyDirector.DateCreated}');", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return "company Director Created Successfully!!!";
                }
                else
                {
                    return "company Director not created";
                }
            }
        }

        public CompanyDirector Get(string id)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from companyDirector where Id = @id;", con);
                command.Parameters.AddWithValue("id", id);
                var row = command.ExecuteReader();
                CompanyDirector companyDirector = new CompanyDirector();
                while (row.Read())
                {
                    companyDirector.Id = Convert.ToInt32(row[0]);
                    companyDirector.UserId = Convert.ToString(row[1]);
                    companyDirector.CompanyId = Convert.ToInt32(row[2]);
                    companyDirector.WalletId = Convert.ToInt32(row[3]);
                    companyDirector.IsDeleted = Convert.ToString(row[4]);
                    companyDirector.DateCreated = Convert.ToString(row[5]);
                }
                return companyDirector;

            }
        }
        public List<CompanyDirector> GetAll()
        {
            try
            {
                using (var con = _context.Connection())
                {
                    con.Open();
                    var command = new MySqlCommand($"select * from companyDirector", con);
                    var row = command.ExecuteReader();
                    List<CompanyDirector> companyDirectors = new List<CompanyDirector>();
                    while (row.Read())
                    {
                        CompanyDirector companyDirector = new CompanyDirector();

                        companyDirector.Id = Convert.ToInt32(row[0]);
                        companyDirector.UserId = Convert.ToString(row[1]);
                        companyDirector.CompanyId = Convert.ToInt32(row[2]);
                        companyDirector.WalletId = Convert.ToInt32(row[3]);
                        companyDirector.IsDeleted = Convert.ToString(row[4]);
                        companyDirector.DateCreated = Convert.ToString(row[5]);
                        companyDirectors.Add(companyDirector);
                    }
                    return companyDirectors;
                }

            }
            catch (System.Exception)
            {

                return null;
            }
        }



    }
}