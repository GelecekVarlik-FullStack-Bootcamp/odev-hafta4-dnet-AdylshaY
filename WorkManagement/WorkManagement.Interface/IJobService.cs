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
    public interface IJobService : IGenericService<Job, DtoJob>
    {
        IResponse<DtoJob> AddJob(DtoJob entity, bool saveChanges = true);
        IResponse<DtoJob> TakeJob(int EmployeeId, int JobId, bool saveChanges = true);
        IResponse<List<DtoJob>> GetAvailableJobs();
        IResponse<List<DtoJob>> GetAvailableJobsForDepartment(int DepartmentId);
    }
}
