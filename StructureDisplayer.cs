using Dynamic_structures.Structures;
using System.Text;

namespace Dynamic_structures
{
    public class StructureDisplayer
    {
        public List<Operation> commands;
        private MyStack stack;
        private MyQueue queue;
        private int cursorPositionX = -8;
        private int cursorPositionY = 0;
        private int lineHeight = 0;
        private int count;
        public StructureDisplayer(List<Operation> commands, MyStack structure) 
        {
            this.commands = commands;
            this.stack = structure;
        }
        public StructureDisplayer(List<Operation> commands, MyQueue queue)
        {
            this.commands = commands;
            this.queue = queue;
        }
        public StructureDisplayer(MyStack stack)
        {
            this.stack = stack;
            cursorPositionY = 3;
        }

        public void InvokeStack()
        {
            int iteration = 0;
            while(commands.Count > 0 && iteration < commands.Count) 
            {
                SetCursor();
                DoOperation(commands[iteration]);
                iteration++;
            }
        }
        public void InvokeCalculator(string operationName)
        {
            SetCursor();
            PrintStack(operationName);
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
                    if(pop == null) 
                    {
                        Stop("The stack is empty, cannot Pop");
                        return; 
                    }
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
        private void Stop(string message)
        {
            Console.SetCursorPosition(cursorPositionX, cursorPositionY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
            commands.Clear();
        }

        private void PrintStack(string operationName)
        {
            string[] stackView = CreateStackView().ToString().Split('\n');
            Console.SetCursorPosition(cursorPositionX, cursorPositionY);
            Console.Write(operationName);
            for (int i = 0; i < stackView.Length; i++)
            {
                Console.SetCursorPosition(cursorPositionX, i + cursorPositionY + 1);
                Console.WriteLine(stackView[i]);
            }
            cursorPositionX += (operationName.Length > stackView[0].Length) ? operationName.Length - stackView[0].Length : 0;
            lineHeight = Console.GetCursorPosition().Top > lineHeight ? Console.GetCursorPosition().Top : lineHeight;
            count++;
        }
        private void PrintQueue(string operationName)
        {

        }
        private void SetCursor() 
        {
            cursorPositionX += FindColumnWidth() + 8;
            if (count == 5)
            {
                cursorPositionY = lineHeight;
                cursorPositionX = 0;
                count = 0;
            }
        }
        public StringBuilder CreateStackView()
        {
            StringBuilder builder = new StringBuilder();
            int columnWidth = FindColumnWidth();
            int countLines = 0;
            builder.AppendLine("┌" + new string('─', columnWidth + 2) + "┐");
            foreach (object item in stack.List)
            {
                countLines++;
                builder.AppendLine("│ " + item.ToString().PadLeft(columnWidth) + " │");
                if (countLines == stack.Size()) { break; }
                builder.AppendLine("├" + new string('─', columnWidth + 2) + "┤");
            }
            builder.AppendLine("└" + new string('─', columnWidth + 2) + "┘");
            return builder;
        }

        //private StringBuilder CreateQueueView()
        //{
        //    StringBuilder builder = new StringBuilder();

        //}

        public int FindColumnWidth()
        {
            int width = 0;
            foreach (object item in stack.List)
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
