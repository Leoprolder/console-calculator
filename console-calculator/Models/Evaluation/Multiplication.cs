﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Evaluation
{
    public class Multiplication : IOperation
    {
        public int Priority { get; set; }
        public char Definition { get; set; }

        public Multiplication()
        {
            Priority = 3;
            Definition = '*';
        }

        public double Apply(double left, double right)
        {
            return left * right;
        }

        public bool IsLegal()
        {
            throw new NotImplementedException();
        }
    }
}