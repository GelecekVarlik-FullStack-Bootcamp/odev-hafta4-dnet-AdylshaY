using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Dtos;
using WorkManagement.Entity.Models;

namespace WorkManagement.Dal.Abstract
{
    public interface IEmployeeRepository
    {
        Employee Login(Employee login);
        Employee ChangePassword(int id, Employee employee, bool saveChanges = true);
        

    }
}
