using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Dal.Abstract;
using WorkManagement.Entity.Dtos;
using WorkManagement.Entity.Models;

namespace WorkManagement.Dal.Concrete.EntityFramework.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context)
        {
        }

        public Employee ChangePassword(int id, Employee employee, bool saveChanges = true)
        {
            Employee person = context.Set<Employee>().SingleOrDefault(x => x.Id == id);
            if (person is not null)
            {
                // Diger alanlari degistirmeye calissa bile degisteremez, sadece sifre degistirilebiliyor.
                employee.Name = person.Name;
                employee.Email = person.Email;
                employee.AuthorizationId = person.AuthorizationId;
                employee.PhoneNumber = person.PhoneNumber;
                employee.Surname = person.Surname;
                employee.DepartmentId = person.DepartmentId;
                employee.JobId = person.JobId;

                if (employee.Password != null && employee.Password.Length > 10 && employee.Password != person.Password)
                {
                    person.Password = employee.Password;
                }
                else
                {
                    throw new Exception("Change your password.");
                }
            }
            else
            {
                throw new Exception("User not found.");
            }
            return employee;
        }

        

        public Employee Login(Employee login)
        {
            var employee = dbSet.Where(x => x.Email == login.Email && x.Password == login.Password).SingleOrDefault();
            return employee;
        }
    }
}
