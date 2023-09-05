using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Entities;

namespace AdoProject.Repository.Interface
{
    public interface IAgentRepository
    {
        string Create(Agent agent);
        Agent Get(string id);
        List<Agent> GetAll();
    }
}