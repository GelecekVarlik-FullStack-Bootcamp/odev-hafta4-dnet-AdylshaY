using System;
using System.Collections.Generic;
using WorkManagement.Entity.Base;

#nullable disable

namespace WorkManagement.Entity.Models
{
    public partial class Authorization : EntityBase
    {
        public Authorization()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
