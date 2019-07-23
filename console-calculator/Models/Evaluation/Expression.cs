using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Evaluation
{
    public class Expression
    {
        public string TextExpression { get; set; }
        public Dictionary<String, String> Log { get; set; }

        public Expression(string input)
        {
            TextExpression = input;
        }

        public Expression()
        {
            Log = new Dictionary<string, string>();
            TextExpression = "";
        }
    }
}