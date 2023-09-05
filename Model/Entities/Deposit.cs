using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.Model.Entities
{
    public class Deposit : BaseEntity
    {
        public double Amount { get; set; }
        public string UserId { get; set; }
        public int WalletId {get; set;}
    }
}