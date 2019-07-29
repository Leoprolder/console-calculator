using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace console_calculator.Models.Evaluation
{
    public class RPNParser
    {
        public RPNParser()
        {

        }

        public string ToRPN(string input) //Метод, конвертирующий выражение в обратную польскую запись
        {
            Stack<string> stack = new Stack<string>();
            string output = String.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (new Operation().IsOperation(symbol, out Operation.Apply apply)) //Если встретившийся символ является операцией
                {
                    Operation operation = new Operation(symbol);

                    if (operation.Definition == '(')
                    {
                        string bracketsContent = input.Substring(i + 1, FindClosingBracketIndex(input.Substring(i)) - 1);
                        int addition = bracketsContent.Length + 1;
                        output += ToRPN(bracketsContent);
                        i += addition;
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
                            for (int j = 0; j < stackArray.Length; j++) //Находим последнюю операцию
                            {
                                if (Char.TryParse(stackArray[j], out char res))
                                {
                                    if (new Operation().IsOperation(res, out Operation.Apply temp))
                                    {
                                        if (new Operation(res).Priority >= operation.Priority) //Если приоритет входной операции больше, записываем в стек
                                        {                                                      //Иначе - в выходную строку
                                            output += res + " ";
                                            stackArray[j] = "_"; //Пометим элемент на удаление
                                        }
                                    }
                                }
                            }
                            stack = DeleteMarkedElementsFromStack(stackArray); //Удаляем помеченные элементы
                            stack.Push(operation.Definition.ToString());
                        }
                    }
                }
                else //Если символ или группа символов - число
                {
                    string number = String.Empty;
                    number += input[i];
                    int j = i + 1;
                    while (j < input.Length) //Пробегаем цикл, пока не достингем конца
                    {
                        //Если символ и последующие за ним - цифры, то добавляем в output
                        if (Int32.TryParse(input[j].ToString(), out int res) || input[j] == '.' || input[j] == ',')
                        {
                            if ((number.IndexOf(',') > 0 || number.IndexOf('.') > 0) && (input[j] == '.' || input[j] == ',')) //Проверка на формат числа
                                throw new Exception("invalid number format");
                            number += input[j];

                            j++;
                        }
                        else
                            break;
                    }

                    output += number + " "; //Разделяющий пробел

                    if (j < input.Length) //Если не достигли конца выражения
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

        public double CalculateRPN(string input)
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
                        if (new Operation().IsOperation(op, out Operation.Apply apply))
                        {
                            //Берём два числа в стек, применяем операцию
                            double right = stack.Pop();
                            double left = stack.Pop();
                            stack.Push(apply(left, right));
                        }
                    }
                }
            }

            return stack.Pop();
        }

        private Stack<string> DeleteMarkedElementsFromStack(string[] array)
        {
            Stack<string> newStack = new Stack<string>();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] != "_")
                    newStack.Push(array[i]);
            }

            return newStack;
        }

        private int FindClosingBracketIndex(string input)
        {
            int i = 0;
            int o = 0;
            int c = 0;

            while (i < input.Length)
            {
                if (input[i] == '(')
                    o++;
                if (input[i] == ')')
                    c++;

                if (o > 0 && c > 0 && o == c)
                    return i;
                i++;
            }

            return -1;
        }
    }
}