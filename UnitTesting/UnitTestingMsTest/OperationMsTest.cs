using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingLibrary;

namespace UnitTestingMsTest
{
    [TestClass]
    public class OperationMsTest
    {
        
        public OperationMsTest()
        {

        }

        [TestMethod]
        public void SumNumbers_InputTwoNumbers_GetRightValue()
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
    }
}
