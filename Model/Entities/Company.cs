using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.Model.Entities
{
    public class Company : BaseEntity
    {
        public int WalletId { get; set; }
        public string CompanyName { get; set; }
    }
}