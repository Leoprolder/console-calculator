using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Evaluation
{
    public class Subtraction : IOperation
    {
        public int Priority { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public char Definition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Subtraction()
        {
            Priority = 2;
            Definition = '-';
        }

        public double Apply(double left, double right)
        {
            return left - right;
        }

        public bool IsLegal()
        {
            throw new NotImplementedException();
        }
    }
}