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
    public class DepartmentManager : GenericManager<Department, DtoDepartment>, IDepartmentService
    {
        public DepartmentManager(IServiceProvider service) : base(service)
        {
        }
    }
}
