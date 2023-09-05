using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.Model.Entities
{
    public class Wallet : BaseEntity
    {

        public string UserId { get; set; }
        public double MoneyBalance { get; set; }
        public double CardBalance { get; set; }
        public string AccountNumber { get; set; }
        public int Pin { get; set; }
    }
}