using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Base;

namespace WorkManagement.Entity.Dtos
{
    public class DtoEmployeeDepartment : DtoBase
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
    }
}
