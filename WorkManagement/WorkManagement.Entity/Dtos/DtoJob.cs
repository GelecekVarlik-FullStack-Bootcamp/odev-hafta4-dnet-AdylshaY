using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Base;

namespace WorkManagement.Entity.Dtos
{
    public class DtoJob : DtoBase
    {
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
    }
}
