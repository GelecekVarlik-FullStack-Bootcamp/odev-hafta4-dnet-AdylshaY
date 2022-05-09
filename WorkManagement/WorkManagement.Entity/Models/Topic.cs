using System;
using System.Collections.Generic;
using WorkManagement.Entity.Base;

#nullable disable

namespace WorkManagement.Entity.Models
{
    public partial class Topic : EntityBase
    {
        public Topic()
        {
            Jobs = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
