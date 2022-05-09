using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Dal.Abstract;
using WorkManagement.Entity.Models;

namespace WorkManagement.Dal.Concrete.EntityFramework.Repository
{
    public class EmployeeDepartmentRepository : GenericRepository<EmployeeDepartment>, IEmployeeDepartmentRepository
    {
        public EmployeeDepartmentRepository(DbContext context) : base(context)
        {
        }
    }
}
