using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkManagement.Api.Base;
using WorkManagement.Entity.Dtos;
using WorkManagement.Entity.Models;
using WorkManagement.Interface;

namespace WorkManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ApiBaseController<IDepartmentService, Department, DtoDepartment>
    {
        private readonly IDepartmentService departmentService;
        public DepartmentsController(IDepartmentService departmentService) : base(departmentService)
        {
            this.departmentService = departmentService;
        }
    }
}
