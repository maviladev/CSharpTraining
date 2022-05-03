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
    }
}
