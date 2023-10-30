using Dynamic_structures.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dynamic_structures
{
    public class PostfixCalculator
    {
        private static string[] operations = {"+", "-", "*", "/", "^", "ln", "cos", "sin", "sqrt" };
        private List<string> expression;
        private MyStack stack;
        private StructureDisplayer displayer;

        public void Calculate(List<string> expression, bool isInfix)
        {
            stack = new MyStack();
            this.expression = expression;
            if (isInfix && !CheckInfixExpression())
            {
                return;
            }
            if (!CheckPostfixExpression())
            {
                return;
            }
            Console.Write("Выражение в постфиксной форме: ");
            PrintInfix();
            CalculatePostfix();
        }
        public double CalculatePostfix()
        {
            stack = new MyStack();
            displayer = new StructureDisplayer(stack);
            for (int i = 0; i < expression.Count; i++)
            {
                if (double.TryParse(expression[i], out double element))
                {
                    stack.Push(element);
                    Print("Push " + element);
                }
                else if (IsOperator(expression[i]))
                {
                    DoOperation(expression[i]);
                    Print(expression[i]);
                }
            }
            return (double)stack.Pop();
        }

        private void DoOperation(string operation)
        {
            double op1;
            double op2;
            switch (operation)
            {
                case "+":
                    op1 = (double)stack.Pop();
                    op2 = (double)stack.Pop();
                    stack.Push(op1 + op2);
                    break;
                case "-":
                    op1 = (double)stack.Pop();
                    op2 = (double)stack.Pop(); ;
                    stack.Push(op2 - op1);
                    break;
                case "*":
                    op1 = (double)stack.Pop();
                    op2 = (double)stack.Pop();
                    stack.Push(op1 * op2);
                    break;
                case "/":
                    op1 = (double)stack.Pop();
                    op2 = (double)stack.Pop();
                    stack.Push(op2 / op1);
                    break;
                case "^":
                    op1 = (double)stack.Pop();
                    op2 = (double)stack.Pop();
                    stack.Push(Math.Pow(op2, op1));
                    break;
                case "ln":
                    op1 = (double)stack.Pop();
                    stack.Push(Math.Log(op1));
                    break;
                case "sin":
                    op1 = (double)stack.Pop();
                    stack.Push(Math.Sin(op1 * 0.017));
                    break;
                case "cos":
                    op1 = (double)stack.Pop();
                    stack.Push(Math.Cos(op1));
                    break;
                case "sqrt":
                    op1 = (double)stack.Pop();
                    stack.Push(Math.Sqrt(op1));
                    break;
                default:
                    throw new Exception();
            }
        }
        public void CalculateInfix()
        {
            List<string> list = new List<string>();
            stack = new MyStack();

            for(int i = 0; i < expression.Count; i++)
            {
                if (double.TryParse(expression[i], out double element))
                {
                    list.Add(element.ToString());
                }
                else if (expression[i] == "(" || expression[i] == ")")
                {
                    CheckBrackets(list, expression[i]);
                }
                else if (IsOperator(expression[i]))
                {
                    while (!stack.IsEmpty() && GetPriority(expression[i]) <= GetPriority(stack.Top().ToString()))
                    {
                        list.Add(stack.Pop().ToString());
                    }
                    stack.Push(expression[i]);
                }
                else throw new Exception();
            }
            while (!stack.IsEmpty())
            {
                list.Add(stack.Pop().ToString());
            }
            expression = list;
        }
        private int GetPriority(string s)
        {
            switch (s)
            {
                case "(": return 0;
                case ")": return 1;
                case "+": return 2;
                case "-": return 3;
                case "*": return 4;
                case "/": return 4;
                case "^": return 5;
                case "cos": return 6;
                case "sin": return 6;
                case "ln": return 6;
                case "sqrt": return 6;
                default: return 0;
            }
        }
        private void CheckBrackets(List<string> list, string op)
        {
            if (op == "(")
            {
                stack.Push(op);
            }
            else if (op == ")")
            {
                string x = stack.Pop().ToString();
                while(x != "(")
                {
                    list.Add(x);
                    x = stack.Pop().ToString();
                }
            }
        }

        private void Print(string operationName)
        {
            displayer.InvokeCalculator(operationName);
        }

        private bool CheckInfixExpression()
        {
            try
            {
                CalculateInfix();
            }
            catch
            {
                Console.WriteLine("Некорректное выражение");
                return false;
            }
            return true;
        }

        private bool CheckPostfixExpression()
        {
            if (expression == null) return false;
            for (int i = 0; i < expression.Count; i++)
            {
                if (double.TryParse(expression[i], out double element))
                {
                    stack.Push(element);
                }
                else if (IsOperator(expression[i]))
                {
                    try
                    {
                        DoOperation(expression[i]);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Некоррекное выражение");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректное выражение");
                    return false;
                }
            }
            return true;
        }
        private bool IsOperator(string element)
        {
            if(operations.Contains(element))
            {
                return true;
            }
            return false;
        }
        private void PrintInfix()
        {
            foreach(string element in expression)
            {
                Console.Write(element+ " ");
            }
            Console.WriteLine();
        }
    }
}
