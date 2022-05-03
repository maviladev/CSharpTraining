using System;
using NUnit.Framework;

namespace UnitTestingLibrary
{
    [TestFixture]
    public class OperationNUnitTest
    {
        public OperationNUnitTest()
        {

        }

        [Test]
        public void SumNumbers_InputTwoIntegers_GetRightValue()
        {
            //Arrange
            //Area to initialize variables, components, objects
            Operation op = new();

            int firstNumber = 50;
            int secondNumber = 69;

            //Act
            // Execution of the procedure
            int result = op.SumNumbers(firstNumber, secondNumber);

            //Assert
            Assert.AreEqual(119, result);
        }

        [Test]
        public void IsEvenNumber_InputOddInteger_ReturnFalse()
        {
            //Arrange
            Operation op = new();
            int inputNumber = 7;

            //Act
            bool isEven = op.IsEvenNumber(inputNumber);


            //Assert
            Assert.IsFalse(isEven);
            Assert.That(isEven, Is.EqualTo(false));

        }

        [Test]
        public void IsEvenNumber_InputEvenInteger_ReturnTrue()
        {
            //Arrange
            Operation op = new();
            int inputNumber = 4;

            //Act
            bool isEven = op.IsEvenNumber(inputNumber);

            //Assert
            Assert.IsTrue(isEven);
            Assert.That(isEven, Is.EqualTo(true));

        }

        [Test]
        [TestCase(4)]   // For each test case will be an execution of the method
        [TestCase(6)]   // In case we need more params, just include it like this
        [TestCase(20)]  // [TestCase(2,5)]
        public void IsEvenNumber_InputEvenInteger_ReturnTrue(int evenNumber)
        {
            //Arrange
            Operation op = new();

            //Act
            bool isEven = op.IsEvenNumber(evenNumber);

            //Assert
            Assert.IsTrue(isEven);
            Assert.That(isEven, Is.EqualTo(true));

        }
    }
}
