using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WorkManagement.Api.Base;
using WorkManagement.Entity.Base;
using WorkManagement.Entity.Dtos;
using WorkManagement.Entity.IBase;
using WorkManagement.Entity.Models;
using WorkManagement.Interface;

namespace WorkManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ApiBaseController<IJobService, Job, DtoJob>
    {
        private readonly IJobService jobService;
        public JobsController(IJobService jobService) : base(jobService)
        {
            this.jobService = jobService;
        }

        [HttpPost("addJob")]
        [Authorize(Policy = "RequireManagerRole")]
        public IResponse<DtoJob> Add(DtoJob entity)
        {
            try
            {
                return jobService.AddJob(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoJob>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error: {ex.Message}",
                    Data = null
                };
            }
        }

        [HttpGet("getAvailableJobs")]
        [Authorize(Policy = "RequireEmployeeRole")]
        public IResponse<List<DtoJob>> GetAvailableJobs()
        {
            try
            {
                return jobService.GetAvailableJobs();
            }
            catch (Exception ex)
            {
                return new Response<List<DtoJob>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error: {ex.Message}",
                    Data = null
                };
            }
        }

        [HttpGet("getAvailableJobsForDepartment")]
        [Authorize(Policy = "RequireEmployeeRole")]
        public IResponse<List<DtoJob>> GetAvailableJobsForDepartment(int DepartmentId)
        {
            try
            {
                return jobService.GetAvailableJobsForDepartment(DepartmentId);
            }
            catch (Exception ex)
            {
                return new Response<List<DtoJob>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error: {ex.Message}",
                    Data = null
                };
            }
        }

        [HttpPut("takeJob")]
        [Authorize(Policy = "RequireEmployeeRole")]
        public IResponse<DtoJob> TakeJob(int EmployeeId, int JobId)
        {
            try
            {
                return jobService.TakeJob(EmployeeId, JobId);
            }
            catch (Exception ex)
            {
                return new Response<DtoJob>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error: {ex.Message}",
                    Data = null
                };
            }
        }
    }
}
