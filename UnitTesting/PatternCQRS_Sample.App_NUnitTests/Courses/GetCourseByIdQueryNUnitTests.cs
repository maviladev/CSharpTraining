using AutoFixture;
using AutoMapper;
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
    public class GetCourseByIdQueryNUnitTests
    {
        private GetCourseByIdQuery.GetCourseByIdQueryHandler handlerCourseByID;
        private Guid courseID;

        [SetUp]
        public void Setup()
        {

            // Emulate context
            courseID = new Guid("2ce24c4d-df93-4620-ba47-c8065633775f");

            var fixture = new Fixture();
            var courseRecords = fixture.CreateMany<Course>().ToList();

            courseRecords.Add(fixture.Build<Course>()
                .With(tr => tr.CourseId,courseID)
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

            // Instantiate object of type GetCoursesQuery and set params
            handlerCourseByID = new GetCourseByIdQuery.GetCourseByIdQueryHandler(appDbContextFake, mapper);

        }

        [Test]
        public async Task GetCourseByIdQueryHandler_RetrieveCourse_ReturnsNotNull()
        {
            // Instantiate object of type GetCoursesQuery and set params
            GetCourseByIdQuery.GetCourseByIdQueryRequest request = new();
            request.CourseId = courseID;
            var result = await handlerCourseByID.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(result);
        }
    }
}
