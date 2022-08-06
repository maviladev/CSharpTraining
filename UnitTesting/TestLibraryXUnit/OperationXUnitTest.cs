using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestLibrary
{
    public class OperationXUnitTest
    {
        [Fact]
        public void SumNumbers_InputTwoIntegers_GetCorrectValue()
        {
            // Arrange
            Operation op = new();
            int numberOne = 50;
            int numberTwo = 70;

            // Act
            int result = op.SumNumbers(numberOne, numberTwo);

            // Assert
            Assert.Equal(120, result);

        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(5, false)]
        [InlineData(7, false)]
        public void IsValueEven_InputOddInt_ReturnFalse(int oddNumber, bool expectedResult)
        {
            Operation op = new();

            var result = op.IsValueEven(oddNumber);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(20)]
        public void IsValueEven_InputEvenInt_ReturnTrue(int evenNumber)
        {
            Operation op = new();

            bool isEven = op.IsValueEven(evenNumber);
            
            Assert.True(isEven);
        }

        [Theory]
        [InlineData(2.2,1.2)] // 3.4
        [InlineData(2.23, 1.24)] // 3.47
        //[InlineData(2.23, 2.24)] // 4.47 runs out of margin 0.1
        public void SumDecimalNumbers_InputTwoDoubles_GetCorrectValue(double numberOne, double numberTwo) 
        {
            Operation op = new();

            double result = op.SumDoublesNumbers(numberOne, numberTwo);

            // 3.3      3.5

            Assert.Equal(3.4, result, 0);
        }

        [Fact]
        public void GetOddNumbersList_InputMinimumMaximum_ReturnOddNumbersList() 
        {
            Operation op = new ();
            List<int> oddNumbersExpectd = new() { 5, 7, 9 };
            List<int> result = op.GetOddNumbersList(5, 10);

            Assert.Equal(oddNumbersExpectd, result);
            Assert.Contains(5, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);

            Assert.DoesNotContain(100,result);

            Assert.Equal(result.OrderBy(u=>u), result); // Comparing order of the elements

        }
    }
}
