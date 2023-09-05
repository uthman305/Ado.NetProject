using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.Model.Entities
{
    public class Agent : BaseEntity
    {
        public string UserId { get; set; }
        public int WalletId { get; set; }
    }
}