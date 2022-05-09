using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Dtos;
using WorkManagement.Entity.Models;

namespace WorkManagement.Interface
{
    public interface IAuthorizationService : IGenericService<Authorization, DtoAuthorization>
    {
    }
}
