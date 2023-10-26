using Dynamic_structures.Structures;

namespace Dynamic_structures
{
    public interface IStructure
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
