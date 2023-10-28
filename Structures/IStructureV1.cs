using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_structures.Structures
{
    public interface IStructureV1
    {
        DoublyLinkedList<object> List { get; }
        void Print();
        object Top();
        void Push(object value);
        object Pop();
        bool IsEmpty();
        int Size();
    }
}
