using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatternCQRS_Sample.App;
using PatternCQRS_Sample.App.Courses;
using PatternCQRS_Sample.App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatterCQRS_Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<CourseDTO>>> Get()
        {
            return await _mediator.Send(new GetCoursesQuery.GetCourseQueryRequest());
        }

        //public async Task<ActionResult<CourseDTO>> Get(Guid id)
        //{
        //    return (ActionResult<CourseDTO>)await _mediator.Send(new GetCourseByIdQuery.GetCourseByIdQueryRequest().CourseId = id);
        //}
        [HttpPost]
        public async Task<ActionResult<Unit>> Post(CreateCourseCommand.CreateCourseCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
