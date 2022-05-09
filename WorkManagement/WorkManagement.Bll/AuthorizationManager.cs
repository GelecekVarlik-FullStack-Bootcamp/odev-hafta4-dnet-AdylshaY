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
    public class AuthorizationManager : GenericManager<Authorization, DtoAuthorization>, IAuthorizationService
    {
        public AuthorizationManager(IServiceProvider service) : base(service)
        {
        }
    }
}
