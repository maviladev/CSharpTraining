using AutoFixture;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatternCQRS_Sample.App.Helper;
using PatternCQRS_Sample.Domain;
using PatternCQRS_Sample.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PatternCQRS_Sample.App
{
    [TestFixture]
    public class GetCourseQueryNUnitTest
    {
        private GetCoursesQuery.GetCourseQueryHandler handlerAllCourses;

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

            // Instantiate object of type GetCoursesQuery and set params
            handlerAllCourses = new GetCoursesQuery.GetCourseQueryHandler(appDbContextFake, mapper);

        }

        [Test]
        public async Task GetCourseQueryHandler_RetrieveCourses_ReturnsTrue() 
        {
            
            // Instantiate object of type GetCoursesQuery and set params
            GetCoursesQuery.GetCourseQueryRequest request = new();
            var results = await handlerAllCourses.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(results);
        }
    }
}
