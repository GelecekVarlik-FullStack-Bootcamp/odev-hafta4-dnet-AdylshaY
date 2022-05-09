using System;
using System.Collections.Generic;
using WorkManagement.Entity.Base;

#nullable disable

namespace WorkManagement.Entity.Models
{
    public partial class Job : EntityBase
    {
        public Job()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public string Priority { get; set; }
        public int TopicsId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Detail { get; set; }
        public int JobOfferer { get; set; }
        public int? JobTaker { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee JobOffererNavigation { get; set; }
        public virtual Employee JobTakerNavigation { get; set; }
        public virtual Topic Topics { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
