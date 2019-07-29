using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Evaluation
{
    public class Operation
    {
        public int Priority { get; set; }
        public char Definition { get; set; }
        public Apply Applier { get; set; }

        public Operation()
        {

        }

        public Operation(char definition)
        {
            SetOperation(definition);
        }

        public delegate double Apply(double left, double right);

        private Apply SetOperation(char definition)
        {
            Apply apply;
            
            switch (definition)
            {
                case '+':
                    apply = (l, r) => l + r;
                    Priority = 2;
                    break;
                case '-':
                    apply = (l, r) => l - r;
                    Priority = 2;
                    break;
                case '*':
                    apply = (l, r) => l * r;
                    Priority = 3;
                    break;
                case '/':
                    apply = (l, r) => l / r;
                    Priority = 3;
                    break;
                case '(':
                    apply = (l, r) => 0;
                    Priority = 0;
                    break;
                case ')':
                    apply = (l, r) => 0;
                    Priority = 1;
                    break;
                default:
                    throw new Exception();
            }

            Definition = definition;
            Applier = apply;
            return apply;
        }

        public bool IsOperation(char c, out Apply apply)
        {
            try
            {
                apply = SetOperation(c);
                return true;
            }
            catch
            {
                apply = null;
                return false;
            }
        }
    }
}