using System;

namespace UnitTestingLibrary
{
    public class Operation
    {
        public int SumNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public bool IsEvenNumber(int number)
        {
            return number % 2 == 0;
        }

        public double SumNumberDoubleType(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}
