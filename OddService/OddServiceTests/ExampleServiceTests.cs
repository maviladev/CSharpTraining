using Xunit;
using OddService;

namespace OddServiceTests
{
    public class ExampleServiceTests
    {
        [Fact]
        public void IncreaseCounters_BetweenFiveAndSeven_SecondIncreased()
        {
            var service = new ExampleServiceImplementation();
            service.IncreaseCounters(6);

            Assert.Equal(0, service.First);
            Assert.Equal(1, service.Second);
            Assert.Equal(0, service.Third);
        }

        [Fact]
        public void IncreaseCounters_BetweenThreeAndFive_FirstIncreased()
        {
            var service = new ExampleServiceImplementation();
            service.IncreaseCounters(4);

            Assert.Equal(1, service.First);
            Assert.Equal(0, service.Second);
            Assert.Equal(0, service.Third);
        }

        [Fact]
        public void IncreaseCounters_LargerThanSeven_ThirdIncreased()
        {
            var service = new ExampleServiceImplementation();
            service.IncreaseCounters(8);

            Assert.Equal(0, service.First);
            Assert.Equal(0, service.Second);
            Assert.Equal(1, service.Third);
        }

        [Fact]
        public void IncreaseCounters_SmallerThanThreen_NoCountersIncreased()
        {
            var service = new ExampleServiceImplementation();
            service.IncreaseCounters(1);

            Assert.Equal(0, service.First);
            Assert.Equal(0, service.Second);
            Assert.Equal(0, service.Third);
        }
    }
}
