using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkSampleLibrary.Math
{
    public class Calculator
    {
         public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        public int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        public int Divide(int number, int divisor)
        {
            if (divisor == 0)
                throw new InvalidOperationException("Divisor can not be zero!");

            return number / divisor;
        }

        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }
    }
}