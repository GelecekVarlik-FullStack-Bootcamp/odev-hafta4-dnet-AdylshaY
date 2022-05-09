using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManagement.Entity.Dtos
{
    public class DtoEmployeeToken
    {
        public DtoLoginEmployee DtoLoginUser { get; set; }
        public object AccessToken { get; set; }
    }
}
