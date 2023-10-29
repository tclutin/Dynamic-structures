using Dynamic_structures.Structures;
using System;
using System.Collections.Generic;
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
        private bool state;

        public PostfixCalculator(List<string> expression) 
        { 
            stack = new MyStack();
            this.expression = expression;
        }
        public void Invoke()
        {
            if(!CheckExpression())
            {
                return;
            }
            CalculatePostfix();
        }
        public double CalculatePostfix()
        {
            stack = new MyStack();
            for (int i = 0; i < expression.Count; i++)
            {
                if (double.TryParse(expression[i], out double element))
                {
                    stack.Push(element);
                    Console.WriteLine("Push " + element);
                    Console.WriteLine(stack.CreateStackView().ToString());
                }
                else if (IsOperator(expression[i]))
                {
                    DoOperation(expression[i]);
                    Console.WriteLine(expression[i]);
                    Console.WriteLine(stack.CreateStackView().ToString());
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
                    stack.Push(Math.Sin(op1));
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
        private bool CheckExpression()
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
    }
}
