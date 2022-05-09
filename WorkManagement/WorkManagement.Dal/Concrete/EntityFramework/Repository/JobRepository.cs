using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Dal.Abstract;
using WorkManagement.Entity.Models;

namespace WorkManagement.Dal.Concrete.EntityFramework.Repository
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(DbContext context) : base(context)
        {
        }

        public Job AddJob(Job item)
        {
            context.Entry(item).State = EntityState.Added;
            dbSet.Add(item);
            return item;
        }

        public List<Job> GetAvailableJobs()
        {
            List<Job> jobs = context.Set<Job>().Where(x => x.JobTaker == null).ToList();
            return jobs;
        }

        public List<Job> GetAvailableJobsForDepartment(int DepartmentId)
        {
            List<Job> jobs = context.Set<Job>().Where(x => x.JobTaker == null && x.DepartmentId == DepartmentId).ToList();
            return jobs;
        }

        public Job TakeJob(int EmployeeId, int JobId)
        {
            Job job = context.Set<Job>().SingleOrDefault(x => x.Id == JobId);
            Employee person = context.Set<Employee>().SingleOrDefault(x => x.Id == EmployeeId);

            job.JobTaker = EmployeeId;
            person.JobId = JobId;
            return job;

        }
    }
}
