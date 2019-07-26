using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Evaluation
{
    public class Expression
    {
        private string TextExpression { get; set; }
        public Dictionary<String, String> Log { get; set; }

        public Expression(string input)
        {
            Log = new Dictionary<string, string>();
            TextExpression = input;
        }

        public Expression()
        {
            Log = new Dictionary<string, string>();
            TextExpression = "";
        }

        public bool IsLegal()
        {
            char[] allowedSymbols = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '+', '-', '*', '/', '(', ')', '.', ',' };
            foreach (var symbol in TextExpression)
            {
                if (!allowedSymbols.Contains(symbol))
                    return false;
            }
            return true;
        }

        public double Calculate()
        {
            TextExpression = TextExpression.Replace(" ", ""); //Убираем пробелы

            if (!IsLegal()) //Проверяем, выражение ли это
                throw new Exception();

            string a = ToRPN(this);

            
            double b = CalculateRPN(a);
            //Обратная польская запись поможеть
            //http://www.lib.unn.ru/students/src/struct.pdf

            return b;
        }

        private string ToRPN(Expression input) //Метод, конвертирующий выражение в обратную польскую запись
        {
            Stack<string> stack = new Stack<string>();
            string output = String.Empty;
            bool isToStack = false;

            for (int i = 0; i < input.TextExpression.Length; i++)
            {
                char symbol = input.TextExpression[i];

                if (OperationQualifier.IsOperation(symbol)) //Если встретившийся символ является операцией
                {
                    IOperation operation = OperationQualifier.GetOperation(symbol);

                    if (operation is Bracket) //Если встретили скобку
                    {
                        if (operation.Definition == '(') //Если открывающая скобка, то помещаем числа в стек
                        {
                            stack.Push(operation.Definition.ToString());
                            isToStack = true;
                        }
                        else //Если закрывающая скобка, то переписываем числа до открывающей скобки в строку
                        {
                            while (stack.Peek() != "(")
                            {
                                output += stack.Pop() + " ";
                            }
                            stack.Pop(); //удаляем открывающую скобку
                            isToStack = false;
                        }
                    }
                    else
                    {
                        if (stack.Count == 0)
                        {
                            stack.Push(operation.Definition.ToString());
                        }
                        else
                        {
                            string[] stackArray = stack.ToArray();
                            for (int j = stackArray.Length - 1; j >= 0; j--) //Находим последнюю операцию
                            {
                                if(Char.TryParse(stackArray[j], out char res))
                                {
                                    if (OperationQualifier.IsOperation(res))
                                    {
                                        if (OperationQualifier.GetOperation(res).Priority >= operation.Priority) //Если приоритет входной операции больше, записываем в стек
                                        {                                                                        //Иначе - в выходную строку
                                            output += res + " ";
                                            stack = DeleteElementFromStack<string>(stack, j);
                                        }
                                    }
                                }
                            }
                            stack.Push(operation.Definition.ToString());
                        }
                    }
                }
                else //Если символ или группа символов - число
                {
                    string number = String.Empty;
                    number += input.TextExpression[i];
                    int j = i + 1;
                    while (j < input.TextExpression.Length) //Пробегаем цикл, пока не достингем конца
                    {
                        //Если символ и последующие за ним - цифры, то добавляем в output
                        if (Int32.TryParse(input.TextExpression[j].ToString(), out int res) || input.TextExpression[j] == '.' || input.TextExpression[j] == ',')
                        {
                            if ((number.IndexOf(',') > 0 || number.IndexOf('.') > 0) && (input.TextExpression[j] == '.' || input.TextExpression[j] == ',')) //Проверка на формат числа
                                throw new Exception();
                            number += input.TextExpression[j];

                            j++;
                        }
                        else
                            break;
                    }

                    if (isToStack)
                        stack.Push(number);
                    else
                        output += number + " "; //Разделяющий пробел

                    if (j < input.TextExpression.Length) //Если не достигли конца выражения
                        i += j - i - 1; //то переходим на символ за числом
                    else
                        break;
                }
            }

            output = output.Replace('.', ',');

            while (stack.Count > 0)
                output += stack.Pop() + " ";

            return output; //Возвращаем выражение без последнего пробела
        }

        private double CalculateRPN(string input)
        {
            string[] inputArray = input.Split(' ');
            Stack<double> stack = new Stack<double>();

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (Double.TryParse(inputArray[i], out double res))
                {
                    stack.Push(res);
                }
                else
                {
                    if (Char.TryParse(inputArray[i], out char op))
                    {
                        if (OperationQualifier.IsOperation(op))
                        {
                            //Берём два числа в стек, применяем операцию
                            double right = stack.Pop();
                            double left = stack.Pop();
                            stack.Push(OperationQualifier.GetOperation(op).Apply(left, right));
                        }
                    }
                }
            }      

            return stack.Pop();
        }

        private Stack<T> DeleteElementFromStack<T>(Stack<T> stack, int k)
        {
            T[] array = stack.ToArray();
            Stack<T> newStack = new Stack<T>();
            k = array.Length - k - 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (i != k)
                    newStack.Push(array[i]);
            }

            return newStack;
        }
    }
}