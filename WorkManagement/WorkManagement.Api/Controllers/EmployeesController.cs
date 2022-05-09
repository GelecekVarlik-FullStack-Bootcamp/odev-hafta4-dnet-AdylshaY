using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WorkManagement.Api.Base;
using WorkManagement.Entity.Base;
using WorkManagement.Entity.Dtos;
using WorkManagement.Entity.IBase;
using WorkManagement.Entity.Models;
using WorkManagement.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace WorkManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ApiBaseController<IEmployeeService, Employee, DtoEmployee>
    {
        private readonly IEmployeeService employeesService;
        public EmployeesController(IEmployeeService employeesService) : base(employeesService)
        {
            this.employeesService = employeesService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IResponse<DtoEmployeeToken> Login(DtoLogin login)
        {
            try
            {
                return employeesService.Login(login);
            }
            catch (Exception ex)
            {
                return new Response<DtoEmployeeToken>
                {
                    Message = "Error: " + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        //[HttpPost("addEmployee")]
        //[Authorize(Policy = "RequireManagerRole")]
        //public IResponse<DtoEmployee> Add(DtoEmployee entity)
        //{
        //    try
        //    {
        //        return employeesService.Add(entity);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response<DtoEmployee>
        //        {
        //            StatusCode = StatusCodes.Status500InternalServerError,
        //            Message = $"Error: {ex.Message}",
        //            Data = null
        //        };
        //    }
        //}

        [HttpPut("changePassword")]
        [Authorize(Policy = "RequireAdminRole")]
        public IResponse<DtoEmployee> ChangePassword(int id, DtoEmployee entity)
        {
            try
            {
                return employeesService.ChangePassword(id ,entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoEmployee>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error: {ex.Message}",
                    Data = null
                };
            }
        }

    }
}
