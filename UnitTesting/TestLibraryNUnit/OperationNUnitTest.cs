using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    [TestFixture]
    public class OperationNUnitTest
    {
        [Test]
        public void SumNumbers_InputTwoIntegers_GetCorrectValue()
        {
            // Arrange
            Operation op = new();
            int numberOne = 50;
            int numberTwo = 70;

            // Act
            int result = op.SumNumbers(numberOne, numberTwo);

            // Assert
            Assert.AreEqual(120, result);

        }

        [Test]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(7, ExpectedResult = false)]
        public bool IsValueEven_InputOddInt_ReturnFalse(int oddNumber)
        {
            Operation op = new();

            return op.IsValueEven(oddNumber);

            //Assert.IsFalse(isEven);
            // Assert.That(isEven, Is.EqualTo(false)); Another way

        }

        [Test]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(20)]
        // Multiple params
        // [TestCase(2,4)]
        // public void IsValueEven_InputEvenInt_ReturnTrue(int evenNumber, int anotherEvenNumber)
        public void IsValueEven_InputEvenInt_ReturnTrue(int evenNumber)
        {
            Operation op = new();

            bool isEven = op.IsValueEven(evenNumber);

            Assert.IsTrue(isEven);
            // Assert.That(isEven, Is.EqualTo(true)); Another way
        }

        [Test]
        [TestCase(2.2,1.2)] // 3.4
        [TestCase(2.23, 1.24)] // 3.47
        //[TestCase(2.23, 2.24)] // 4.47 runs out of margin 0.1
        public void SumDecimalNumbers_InputTwoDoubles_GetCorrectValue(double numberOne, double numberTwo) 
        {
            Operation op = new();

            double result = op.SumDoublesNumbers(numberOne, numberTwo);

            // 3.3      3.5

            Assert.AreEqual(3.4, result, 0.1);
        }

        [Test]
        public void GetOddNumbersList_InputMinimumMaximum_ReturnOddNumbersList() 
        {
            Operation op = new ();
            List<int> oddNumbersExpectd = new() { 5, 7, 9 };
            List<int> result = op.GetOddNumbersList(5, 10);

            Assert.That(result, Is.EquivalentTo(oddNumbersExpectd));

            Assert.AreEqual(oddNumbersExpectd, result);
            Assert.That(result, Does.Contain(5));
            Assert.Contains(5, result);

            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(3));
            Assert.That(result, Is.Ordered); // Default asc, Is.Ordered.Descending
            Assert.That(result, Is.Unique); // It has duplicated values?

        }
    }
}
