using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_structures
{
    public static class Parser
    {
        public static List<Operation> Parse(string path)
        {
            List<Operation> operations = new List<Operation>();

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] commands = line.Split();
                        foreach (string command in commands)
                        {
                            if (command.Contains(","))
                            {
                                string[] parts = command.Split(',');
                                int operation = int.Parse(parts[0]);
                                object value = parts[1];
                                operations.Add(new Operation(operation, value));
                            }
                            else
                            {
                                int operation = int.Parse(command);
                                operations.Add(new Operation(operation));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            return operations;
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
    }

}
