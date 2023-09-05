using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.Model.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; } 
        public string IsDeleted { get; set; } = false.ToString();
        public string DateCreated { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
    }
}