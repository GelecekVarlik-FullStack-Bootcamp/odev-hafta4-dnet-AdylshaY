using System;
using System.Collections.Generic;
using WorkManagement.Entity.Base;

#nullable disable

namespace WorkManagement.Entity.Models
{
    public partial class Department : EntityBase
    {
        public Department()
        {
            Jobs = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
