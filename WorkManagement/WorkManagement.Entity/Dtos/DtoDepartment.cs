using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Base;

namespace WorkManagement.Entity.Dtos
{
    public class DtoDepartment : DtoBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
