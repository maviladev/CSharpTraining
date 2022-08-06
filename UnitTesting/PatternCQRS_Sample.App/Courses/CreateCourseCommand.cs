using FluentValidation;
using MediatR;
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
    public class CreateCourseCommand
    {
        public class CreateCourseCommandRequest : IRequest 
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? PublishDate { get; set; }
            public decimal Price { get; set; }
        }


        public class CreateCourseCommandRequestValidation : AbstractValidator<CreateCourseCommandRequest>
        {
            public CreateCourseCommandRequestValidation()
            {
                RuleFor(x => x.Description);
                RuleFor(x => x.Title);
            }
        }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommandRequest>
        {
            private readonly AppDbContext _context;
            public CreateCourseCommandHandler(AppDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(CreateCourseCommandRequest request, CancellationToken cancellationToken)
            {
                var course = new Course() 
                {
                    Title = request.Title,
                    Description = request.Description,
                    PublishDate = request.PublishDate,
                    CreationDate = DateTime.Now,
                    Price = request.Price
                };

                _context.Add(course);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                    return Unit.Value;

                throw new Exception("It can't be created");

            }
        }
    }
}
