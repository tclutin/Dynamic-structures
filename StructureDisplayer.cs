using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamic_structures.Structures;

namespace Dynamic_structures
{
    public class StructureDisplayer
    {
        public List<Operation> commands;
        private MyStack stack = new MyStack();
        private int cursorPositionX = -8;
        private int cursorPositionY = 0;
        private int lineHeight = 0;
        private int count;
        public StructureDisplayer(List<Operation> commands) 
        {
            this.commands = commands;
        }

        public void Invoke()
        {
            foreach(Operation operation in commands)
            {
                SetCursor();
                DoOperation(operation);
            }
        }
        private void DoOperation(Operation operation)
        {
            switch(operation.Number) 
            {
                case 1:
                    stack.Push(operation.Data);
                    PrintStack("Push " + operation.Data);
                    break;
                case 2:
                    object pop = stack.Pop();
                    PrintStack("Pop = " + pop);
                    break;
                case 3:
                    object top = stack.Top();
                    PrintStack("Top = " + top);
                    break;
                case 4:
                    bool isEmpty = stack.IsEmpty();
                    PrintStack("IsEmpty: " + isEmpty);
                    break;
                case 5:
                    PrintStack("Print");
                    break;
            }
        }

        private void PrintStack(string operationName)
        {
            string[] stackView = stack.CreateStackView().ToString().Split('\n');
            Console.SetCursorPosition(cursorPositionX, cursorPositionY);
            Console.Write(operationName);
            for (int i = 0; i < stackView.Length; i++)
            {
                Console.SetCursorPosition(cursorPositionX, i + cursorPositionY + 1);
                Console.WriteLine(stackView[i]);
            }
            //манипуляция чтобы описание команды не запрыгивало на следуюший стек
            cursorPositionX += (operationName.Length > stackView[0].Length) ? operationName.Length - stackView[0].Length : 0;
            //здесь ищу самый длинный столбик чтобы потом перейти на следующую строку нормально
            lineHeight = Console.GetCursorPosition().Top > lineHeight ? Console.GetCursorPosition().Top : lineHeight;
            count++;
        }
        private void SetCursor() 
        {
            cursorPositionX += stack.FindColumnWidth() + 8;
            if (count == 5) //если уже отрисовалось пять стеков в строке
            {
                cursorPositionY += lineHeight;
                cursorPositionX = 0;
                count = 0;
            }
        }
    }
}
