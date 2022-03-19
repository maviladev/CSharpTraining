using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddService
{
    public class OddServiceImplementation
    {
        public bool IsOdd(int number)
        {
            return number % 2 != 0;
        }
    }
}
