using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Dtos;
using WorkManagement.Entity.Models;

namespace WorkManagement.Entity.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Authorization, DtoAuthorization>().ReverseMap();
            CreateMap<Department, DtoDepartment>().ReverseMap();
            CreateMap<Employee, DtoEmployee>().ReverseMap();
            CreateMap<Job, DtoJob>().ReverseMap();
            CreateMap<Topic, DtoTopic>().ReverseMap(); 
            CreateMap<Employee, DtoLoginEmployee>().ReverseMap();
            CreateMap<DtoLogin, Employee>().ReverseMap();
        }
    }
}
