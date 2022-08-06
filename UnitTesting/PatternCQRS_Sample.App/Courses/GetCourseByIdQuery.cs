using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PatternCQRS_Sample.App.DTOs;
using PatternCQRS_Sample.Domain;
using PatternCQRS_Sample.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatternCQRS_Sample.App.Courses
{
    public class GetCourseByIdQuery
    {
        public class GetCourseByIdQueryRequest : IRequest<CourseDTO> 
        {
            public Guid CourseId { get; set; }
        }

        public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQueryRequest, CourseDTO>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public GetCourseByIdQueryHandler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CourseDTO> Handle(GetCourseByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var course = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == request.CourseId);
                var courseDto = _mapper.Map<Course, CourseDTO>(course);
                return courseDto;
            }
        }
    }
}
