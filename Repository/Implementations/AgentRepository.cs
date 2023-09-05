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
    public class AgentRepository : IAgentRepository
    {
        private readonly DBContext _context = new DBContext();

        public string Create(Agent agent)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($" insert into Agent (Id , UserId, WalletId, IsDeleted, DateCreated) values ({agent.Id},'{agent.UserId}', {agent.WalletId}, '{agent.IsDeleted}', '{agent.DateCreated}' );", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return "Agent Created Successfully!!!";
                }
                else
                {
                    return "Agent not created";
                }
            }
        }

        public Agent Get(string id)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from agent where Id = @id;", con);
                command.Parameters.AddWithValue("id", id);
                var row = command.ExecuteReader();
                Agent agent = new Agent();
                while (row.Read())
                {
                    agent.Id = Convert.ToInt32(row[0]);
                    agent.UserId = Convert.ToString(row[1]);
                    agent.WalletId = Convert.ToInt32(row[2]);
                    agent.IsDeleted = Convert.ToString(row[3]);
                    agent.DateCreated = Convert.ToString(row[4]);
                }
                return agent;

            }
        }
        public List<Agent> GetAll()
        {
            try
            {
                using (var con = _context.Connection())
                {
                    con.Open();
                    var command = new MySqlCommand($"select * from agent", con);
                    var row = command.ExecuteReader();
                    List<Agent> agents = new List<Agent>();
                    while (row.Read())
                    {
                        Agent agent = new Agent();

                        agent.Id = Convert.ToInt32(row[0]);
                        agent.UserId = Convert.ToString(row[1]);
                        agent.WalletId = Convert.ToInt32(row[2]);
                        agent.IsDeleted = Convert.ToString(row[3]);
                        agent.DateCreated = Convert.ToString(row[4]);

                        agents.Add(agent);
                    }
                    return agents;
                }
            }
            catch (System.Exception)
            {

                return null;
            }
        }
    }
}