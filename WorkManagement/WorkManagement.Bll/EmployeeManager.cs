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
using WorkManagement.Entity.Base;
using WorkManagement.Entity.Dtos;
using WorkManagement.Entity.IBase;
using WorkManagement.Entity.Models;
using WorkManagement.Interface;

namespace WorkManagement.Bll
{
    public class EmployeeManager : GenericManager<Employee, DtoEmployee>, IEmployeeService
    {
        private IConfiguration configuration;
        public readonly IEmployeeRepository employeeRepository;

        public EmployeeManager(IServiceProvider service, IConfiguration configuration, DbContext context) : base(service)
        {
            employeeRepository = service.GetService<IEmployeeRepository>();
            this.configuration = configuration;
        }

        public IResponse<DtoEmployeeToken> Login(DtoLogin login)
        {
            var user = employeeRepository.Login(ObjectMapper.Mapper.Map<Employee>(login));
            if (user != null)
            {
                // token uretmek gerekiyor
                var dtoUser = ObjectMapper.Mapper.Map<DtoLoginEmployee>(user);

                var token = new TokenManager(configuration).CreateAccessToken(dtoUser);

                var userToken = new DtoEmployeeToken()
                {
                    DtoLoginUser = dtoUser,
                    AccessToken = token
                };

                return new Response<DtoEmployeeToken>()
                {
                    Message = "Token uretildi",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };
            }
            else
            {
                return new Response<DtoEmployeeToken>
                {
                    Message = "Kullanici adi veya parola yanlis",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }
        }

        public IResponse<DtoEmployee> ChangePassword(int id, DtoEmployee employee, bool saveChanges = true)
        {

            #region Is katmani kurallari
            #endregion

            try
            {
                var model = ObjectMapper.Mapper.Map<Employee>(employee);
                var result = employeeRepository.ChangePassword(id, model);

                if (saveChanges)
                {
                    Save();
                }

                return new Response<DtoEmployee>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<Employee, DtoEmployee>(result)
                };
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
