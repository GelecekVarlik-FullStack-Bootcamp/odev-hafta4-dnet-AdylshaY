using System;
using System.Collections.Generic;
using WorkManagement.Entity.Base;

#nullable disable

namespace WorkManagement.Entity.Models
{
    public partial class Employee : EntityBase
    {
        public Employee()
        {
            JobJobOffererNavigations = new HashSet<Job>();
            JobJobTakerNavigations = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public int AuthorizationId { get; set; }
        public string Password { get; set; }
        public int? JobId { get; set; }

        public virtual Authorization Authorization { get; set; }
        public virtual Job Job { get; set; }
        public virtual ICollection<Job> JobJobOffererNavigations { get; set; }
        public virtual ICollection<Job> JobJobTakerNavigations { get; set; }
    }
}
