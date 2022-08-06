using AutoFixture;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatternCQRS_Sample.App.Helper;
using PatternCQRS_Sample.Domain;
using PatternCQRS_Sample.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternCQRS_Sample.App.Courses
{
    public class CreateCourseCommandNUnitTests
    {
        private CreateCourseCommand.CreateCourseCommandHandler handlerCreateCourse;

        [SetUp]
        public void Setup()
        {

            // Emulate context

            var fixture = new Fixture();
            var courseRecords = fixture.CreateMany<Course>().ToList();

            courseRecords.Add(fixture.Build<Course>()
                .With(tr => tr.CourseId, Guid.Empty)
                .Create()
            );

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: $"AppDbContext-{Guid.NewGuid()}")
                .Options;

            var appDbContextFake = new AppDbContext(options);
            appDbContextFake.Courses.AddRange(courseRecords);

            // Emulate mapping profile for DTO

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            // Instantiate object of type CreateCourseCommand and set params
            handlerCreateCourse = new CreateCourseCommand.CreateCourseCommandHandler(appDbContextFake);

        }

        [Test]
        public async Task CreateCourseCommand_InputCourse_ReturnsInt()
        {

            // Instantiate object of type CreateCourseCommand and set params
            CreateCourseCommand.CreateCourseCommandRequest request = new();
            request.PublishDate = DateTime.UtcNow.AddDays(50);
            request.Title = "Basi Unit Tesing";
            request.Description = "Unit Testing for beginners";
            request.Price = 100;

            var results = await handlerCreateCourse.Handle(request, new System.Threading.CancellationToken());
            // Evaluate EF response
            Assert.That(results, Is.EqualTo(Unit.Value));
        }
    }
}
