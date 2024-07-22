using AutoMapper;
using School.Modules.Student.BO.Models;
using School.Modules.Student.Infraestructure.Entity;

namespace School.Modules.Student.Infraestructure.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<StudentModel, StudentEntity>().ReverseMap();
        }
    }
}
