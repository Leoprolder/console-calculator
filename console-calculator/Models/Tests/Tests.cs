using console_calculator.Models.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Tests
{
    public class Tests
    {
        public static string Run()
        {
            string result = String.Empty;

            result += test2plus2equal4() ? "Test 2+2=4 passed\n" : "Test 2+2=4 FAILED\n";
            result += testWrongSymbols() ? "Test wrong symbols passed\n" : "Test wrong symbols FAILED\n";
            result += test2plus2mult2equal6() ? "Test 2+2*2=6 passed\n" : "Test 2+2*2=6 FAILED\n";
            result += testBrackets() ? "Test brackets passed \n" : "Test brackets passed \n";
            result += testConvertationToRPN() ? "Test convertation to RPN passed\n" : "Test convertation to RPN FAILED\n";
            result += testRPNCalculation() ? "Test RPN calculation passed\n" : "Test RPN calculation FAILED\n";
            result += testMinusWork() ? "Test minus work passed\n" : "Test minus work FAILED\n";

            return result;
        }

        static bool test2plus2equal4()
        {
            try
            {
                Expression expression = new Expression("2+2");
                if (expression.Calculate() == 4)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        static bool testWrongSymbols()
        {
            try
            {
                Expression expression = new Expression("2a + 1b");
                expression.Calculate();
                return false;
            }
            catch
            {
                return true;
            }
        }

        static bool test2plus2mult2equal6()
        {
            try
            {
                Expression expression = new Expression("2+2*2");
                if (expression.Calculate() == 6)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        static bool testBrackets()
        {
            try
            {
                Expression expression = new Expression("(2+2)*2");
                if (expression.Calculate() == 8)
                    return true;
                else
                    return false;
            }
            catch
            {

                throw;
            }
        }

        static bool testConvertationToRPN()
        {
            try
            {
                RPNParser parser = new RPNParser();
                string result = parser.ToRPNRecursive("7*9+2.1*9+5*(8*7-9/3)");
                if (result == "7 9 * 2,1 9 * + 5 8 7 * 9 3 / - * + ")
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        static bool testRPNCalculation()
        {
            try
            {
                RPNParser parser = new RPNParser();
                double result = parser.CalculateRPN("7 9 * 2,1 9 * + 5 8 7 * 9 3 / - * + ");
                if (result == 346.9)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        static bool testMinusWork()
        {
            try
            {
                Expression expression = new Expression("2 + (-2)");
                if (expression.Calculate() == 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}