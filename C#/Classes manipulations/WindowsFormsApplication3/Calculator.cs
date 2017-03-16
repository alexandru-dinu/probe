using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    class Calculator
    {
        int nr1, nr2;

        public Calculator()
        {
            nr1 = 0;
            nr2 = 0;
        }

        public int Sum(int nr1, int nr2)
        {
            int sum = nr1 + nr2;
            return sum;
        }

        public int Sub(int nr1, int nr2)
        {
            int sub = nr1 - nr2;
            return sub;
        }
    }
}
