﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Evaluation
{
    public class Bracket : IOperation
    {
        public int Priority { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public char Definition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Bracket(char definition)
        {
            switch(definition)
            {
                case '(':
                    Priority = 0;
                    Definition = '(';
                    break;
                case ')':
                    Priority = 1;
                    Definition = ')';
                    break;
                default:
                    break;
            }
        }

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