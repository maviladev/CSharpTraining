using System;
using System.Collections.Generic;

namespace TestLibrary
{
    public class Operation
    {
        public List<int> OddNumbers = new ();
        public int SumNumbers(int number1, int number2) 
        {
            return number1 + number2;
        }

        public bool IsValueEven(int number) 
        {
            return number % 2 == 0;
        }


        public double SumDoublesNumbers(double decimalOne, double decimalTwo) 
        {
            return decimalOne + decimalTwo;
        }

        public List<int> GetOddNumbersList(int minimum, int maximum) 
        {
            OddNumbers.Clear();
            for (int i = minimum; i <= maximum; i++)
            {
                if (i % 2 != 0)
                    OddNumbers.Add(i);
            }

            return OddNumbers;
        }
    }
}
