using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_structures
{
    public class StructureDisplayer
    {
        public List<Operation> commands;
        private IStructure structure;
        private int cursorPositionX = -8;
        private int cursorPositionY = 0;
        private int lineHeight = 0;
        private int count;
        public StructureDisplayer(List<Operation> commands, IStructure structure) 
        {
            this.commands = commands;
            this.structure = structure;
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
                    structure.Push(operation.Data);
                    PrintStructure("Push " + operation.Data);
                    break;
                case 2:
                    object pop = structure.Pop();
                    PrintStructure("Pop = " + pop);
                    break;
                case 3:
                    object top = structure.Top();
                    PrintStructure("Top = " + top);
                    break;
                case 4:
                    bool isEmpty = structure.IsEmpty();
                    PrintStructure("IsEmpty: " + isEmpty);
                    break;
                case 5:
                    PrintStructure("Print");
                    break;
            }
        }

        private void PrintStructure(string operationName)
        {
            string[] stackView = CreateView(structure).ToString().Split('\n');
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
            cursorPositionX += FindColumnWidth(structure) + 8;
            if (count == 5) //если уже отрисовалось пять стеков в строке
            {
                cursorPositionY += lineHeight;
                cursorPositionX = 0;
                count = 0;
            }
        }
        public static StringBuilder CreateView(IStructure structure)
        {
            StringBuilder builder = new StringBuilder();
            int columnWidth = FindColumnWidth(structure);
            int countLines = 0;
            builder.AppendLine("┌" + new string('─', columnWidth + 2) + "┐");
            foreach (object item in structure.List)
            {
                countLines++;
                builder.AppendLine("│ " + item.ToString().PadLeft(columnWidth) + " │");
                if (countLines == structure.Size()) { break; }
                builder.AppendLine("├" + new string('─', columnWidth + 2) + "┤");
            }
            builder.AppendLine("└" + new string('─', columnWidth + 2) + "┘");
            return builder;
        }
        public static int FindColumnWidth(IStructure structure)
        {
            int width = 0;
            foreach (object item in structure.List)
            {
                if (item.ToString().Length > width)
                {
                    width = item.ToString().Length;
                }
            }
            return width;
        }
    }
}
