using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Dal.Abstract;
using WorkManagement.Dal.Concrete.EntityFramework.Repository;
using WorkManagement.Entity.Base;
using WorkManagement.Entity.Dtos;
using WorkManagement.Entity.IBase;
using WorkManagement.Entity.Models;
using WorkManagement.Interface;

namespace WorkManagement.Bll
{
    public class JobManager : GenericManager<Job, DtoJob>, IJobService
    {
        private readonly IJobRepository jobRepository;
        private DbSet<Employee> dbSetEmployee;
        private DbSet<Job> dbSetJob;

        public JobManager(IServiceProvider service, DbContext context) : base(service)
        {
            jobRepository = service.GetService<IJobRepository>();
            dbSetEmployee = context.Set<Employee>();
            dbSetJob = context.Set<Job>();
        }

        public IResponse<DtoJob> AddJob(DtoJob entity, bool saveChanges = true)
        {
            #region Is katmani kurallari

            int jobOffererId = entity.JobOfferer;
            Employee employee = dbSetEmployee.Find(jobOffererId);
            if (employee == null)
            {
                return new Response<DtoJob>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Job Offerer is not found.",
                    Data = null
                };
            }

            #endregion

            try
            {
                var result = jobRepository.AddJob(ObjectMapper.Mapper.Map<Job>(entity));
                if (saveChanges)
                {
                    Save();
                }
                return new Response<DtoJob>()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<Job, DtoJob>(result)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoJob>()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error: {ex.Message}",
                    Data = null
                };
            }
        }
        public IResponse<List<DtoJob>> GetAvailableJobs()
        {
            try
            {
                var list = jobRepository.GetAvailableJobs();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoJob>(x)).ToList();

                return new Response<List<DtoJob>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
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
        public IResponse<List<DtoJob>> GetAvailableJobsForDepartment(int DepartmentId)
        {
            try
            {
                var list = jobRepository.GetAvailableJobsForDepartment(DepartmentId);
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoJob>(x)).ToList();

                return new Response<List<DtoJob>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
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

        public IResponse<DtoJob> TakeJob(int EmployeeId, int JobId, bool saveChanges = true)
        {
            Job job = dbSetJob.SingleOrDefault(x => x.Id == JobId);
            Employee person = dbSetEmployee.SingleOrDefault(x => x.Id == EmployeeId);
            try
            {
                if (job is null || person is null)
                {
                    return new Response<DtoJob>
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = "Job Id or Employee Id is wrong.",
                        Data = null
                    };
                }

                var result = jobRepository.TakeJob(EmployeeId, JobId);

                if (saveChanges)
                {
                    Save();
                }

                return new Response<DtoJob>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<Job, DtoJob>(result)
                };
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
