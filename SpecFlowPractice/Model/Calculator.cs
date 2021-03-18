using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPractice.Model
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }

        public int Subtract()
        {
            return FirstNumber - SecondNumber;
        }

        public int Multiply()
        {
            return FirstNumber * SecondNumber;
        }

        public int Divide()
        {
            return FirstNumber / SecondNumber;
        }
    }
}
