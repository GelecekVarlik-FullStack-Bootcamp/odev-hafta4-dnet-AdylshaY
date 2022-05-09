using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Base;

namespace WorkManagement.Entity.Dtos
{
    public class DtoLoginEmployee : DtoBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public int AuthorizationId { get; set; }
    }
}
