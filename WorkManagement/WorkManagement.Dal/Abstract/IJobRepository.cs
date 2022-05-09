using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Models;

namespace WorkManagement.Dal.Abstract
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        Job AddJob(Job item);
        List<Job> GetAvailableJobs();
        List<Job> GetAvailableJobsForDepartment(int DepartmentId);
        Job TakeJob(int EmployeeId, int JobId);
    }
}
