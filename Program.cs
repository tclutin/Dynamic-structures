using Dynamic_structures.Structures;
using System.Collections;
using System.Collections.Generic;

namespace Dynamic_structures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Operation> operations = new List<Operation>();
            operations.Add(new Operation(1, 3));
            operations.Add(new Operation(1, "cat"));
            operations.Add(new Operation(1, 11827));
            operations.Add(new Operation(2));
            operations.Add(new Operation(3));
            operations.Add(new Operation(4));
            operations.Add(new Operation(5));
            StructureDisplayer displayer = new StructureDisplayer(operations);
            displayer.Invoke();
        }
    }
}