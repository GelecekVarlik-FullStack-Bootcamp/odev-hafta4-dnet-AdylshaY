using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Dtos;
using WorkManagement.Entity.IBase;
using WorkManagement.Entity.Models;

namespace WorkManagement.Interface
{
    public interface IEmployeeService : IGenericService<Employee, DtoEmployee>
    {
        IResponse<DtoEmployeeToken> Login(DtoLogin login);
        IResponse<DtoEmployee> ChangePassword(int id, DtoEmployee employee, bool saveChanges = true);
        

    }
}
