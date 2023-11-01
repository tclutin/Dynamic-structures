using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_structures
{
    public static class Parser
    {
        public static List<Operation> Parse(string path)
        {
            List<Operation> operations = new List<Operation>();

            using(StreamReader reader = new StreamReader(path))
                {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] commands = line.Split();
                    foreach (string command in commands)
                    {
                        string[] parts = command.Split(',');
                        int operation = int.Parse(parts[0]);
                        if (operation < 1 || operation > 5)
                        {
                            throw new Exception("[1, 5] is range of operations");
                        }


                        if (command.Contains(","))
                        {
                            object value = parts[1];
                            operations.Add(new Operation(operation, value));
                        }
                        else
                        {
                            int oper = int.Parse(command);
                            operations.Add(new Operation(operation));
                        }
                    }
                }
            }
            return operations;
        }

        public static List<Operation> ParseStr(string line)
        {
            List<Operation> operations = new List<Operation>();
            string[] commands = line.Split();
            foreach (string command in commands)
            {
                string[] parts = command.Split(',');
                int operation = int.Parse(parts[0]);
                if (operation < 1 || operation > 5)
                {
                    throw new Exception("[1, 5] is range of operations");
                }

                if (command.Contains(","))
                {
                    object value = parts[1];
                    operations.Add(new Operation(operation, value));
                }
                else
                {
                    int oper = int.Parse(command);
                    operations.Add(new Operation(operation));
                }
            }
            return operations;
        }

        public static List<string> ParseExpression(string path)
        {
            StreamReader reader = new StreamReader(path);
            string? stringFromFile = reader.ReadLine();
            string[] commands = stringFromFile.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return commands.ToList();
        }

        public static List<string> ParseExpressionStr(string line)
        {
            return line.Split(" ").ToList();
        }
    }
    public class Operation
    {
        public int Number { get; }
        public object Data { get; }

        public Operation(int number, object data = null)
        {
            Number = number;
            Data = data;
        }

        public bool IsBalanced(string expression)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> bracketMap = new Dictionary<char, char>
            {
                {')', '('},
                {']', '['},
                {'}', '{'}
            };

            foreach (char character in expression)
            {
                if (bracketMap.ContainsValue(character))
                {
                    stack.Push(character);
                }
                else if (bracketMap.ContainsKey(character))
                {
                    if (stack.Count == 0 || stack.Pop() != bracketMap[character])
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }

}
