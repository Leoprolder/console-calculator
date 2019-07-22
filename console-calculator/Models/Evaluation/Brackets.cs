using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Evaluation
{
    public class Brackets : IOperation
    {
        public int Priority { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double Apply(double left, double right)
        {
            Priority = Priority + 1;
            return Priority;
        }

        public bool IsLegal()
        {
            throw new NotImplementedException();
        }
    }
}