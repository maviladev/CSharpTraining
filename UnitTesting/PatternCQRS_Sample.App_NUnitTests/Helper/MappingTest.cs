using AutoMapper;
using PatternCQRS_Sample.App.DTOs;
using PatternCQRS_Sample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternCQRS_Sample.App.Helper
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Course, CourseDTO>();
        }
    }
}
