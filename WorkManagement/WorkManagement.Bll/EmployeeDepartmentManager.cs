using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Dtos;
using WorkManagement.Entity.Models;
using WorkManagement.Interface;

namespace WorkManagement.Bll
{
    public class EmployeeDepartmentManager : GenericManager<EmployeeDepartment, DtoEmployeeDepartment>, IEmployeeDepartmentService
    {
        public EmployeeDepartmentManager(IServiceProvider service) : base(service)
        {
        }
    }
}
