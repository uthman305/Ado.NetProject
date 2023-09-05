using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model.Enum;

namespace AdoProject.Model.Entities
{
    public class User : BaseEntity
    {
        public string UserId { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string Role { get; set; }

    }
}