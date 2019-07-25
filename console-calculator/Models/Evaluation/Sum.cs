using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Evaluation
{
    public class Sum : IOperation
    {
        public int Priority { get; set; }
        public char Definition { get; set; }

        public Sum()
        {
            Priority = 2;
            Definition = '+';
        }

        public double Apply(double left, double right)
        {
            return left + right;
        }

        public bool IsLegal()
        {
            throw new NotImplementedException();
        }
    }
}