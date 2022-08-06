using System;
using MediatR;
using PatternCQRS_Sample.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using PatternCQRS_Sample.Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PatternCQRS_Sample.App.DTOs;

namespace PatternCQRS_Sample.App
{
    public class GetCoursesQuery
    {
        public class GetCourseQueryRequest : IRequest<List<CourseDTO>> { }

        public class GetCourseQueryHandler : IRequestHandler<GetCourseQueryRequest, List<CourseDTO>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public GetCourseQueryHandler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CourseDTO>> Handle(GetCourseQueryRequest request, CancellationToken cancellationToken)
            {
                var courses = await _context.Courses.ToListAsync();
                var coursesDto = _mapper.Map<List<Course>, List<CourseDTO>>(courses);
                return coursesDto;
            }
        }
    }
}
