using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Dynamic_structures.Structures
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;
        public Node<T> Previous;

        public Node(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;

        private int count;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public int Size()
        {
            return count;
        }

        public Node<T> getHead()
        {
            return head;
        }

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            count++;
        }

        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            count++;
        }

        public void Remove(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }

                    if (head == current)
                    {
                        head = current.Next;
                    }

                    if (tail == current)
                    {
                        tail = current.Previous;
                    }
                    count--;
                    return;
                }
                current = current.Next;
            }
        }

        //1
        public void Reverse()

        {
            Node<T> temp = null;
            Node<T> current = head;

            while (current != null)
            {
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;
                current = current.Previous;
            }

            if (temp != null)
            {
                head = temp.Previous;
            }
        }

        //2
        public void MoveLastToStart()
        {
            if (head == null || head.Next == null)
            {
                return;
            }

            Node<T> secondLast = null;
            Node<T> last = head;

            while (last.Next != null)
            {
                secondLast = last;
                last = last.Next;
            }

            secondLast.Next = null;

            last.Next = head;
            head.Previous = last;
            head = last;
        }

        //3
        public int CountDistinctElements()
        {
            HashSet<T> uniqueElements = new HashSet<T>();
            Node<T> current = head;

            while (current != null)
            {
                uniqueElements.Add(current.Data);
                current = current.Next;
            }

            return uniqueElements.Count;
        }

        //4
        public void RemoveSecondOccurrenceOfElement(T element)
        {
            Node<T> current = head;
            int occurrences = 0;

            while (current != null)
            {
                if (current.Data.Equals(element))
                {
                    occurrences++;
                    if (occurrences == 2)
                    {
                        if (current.Previous != null)
                        {
                            current.Previous.Next = current.Next;
                        }

                        if (current.Next != null)
                        {
                            current.Next.Previous = current.Previous;
                        }

                        if (head == current)
                        {
                            head = current.Next;
                        }

                        if (tail == current)
                        {
                            tail = current.Previous;
                        }

                        count--;
                        return;
                    }
                }
                current = current.Next;
            }
        }

        //5
        public void InsertListAfterFirstOccurrence(T data, DoublyLinkedList<T> list)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    Node<T> temp = current.Next;
                    current.Next = list.getHead();
                    list.getHead().Previous = current;
                    list.tail.Next = temp;
                    count += list.Size();
                    return;
                }
                current = current.Next;
            }
        }

        //6
        public void InsertInOrder(T element)
        {
            Node<T> newNode = new Node<T>(element);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else if (Comparer<T>.Default.Compare(element, head.Data) <= 0)
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            else if (Comparer<T>.Default.Compare(element, tail.Data) >= 0)
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current != null && Comparer<T>.Default.Compare(element, current.Data) > 0)
                {
                    current = current.Next;
                }

                newNode.Previous = current.Previous;
                newNode.Next = current;
                current.Previous.Next = newNode;
                current.Previous = newNode;
            }

            count++;
        }

        //7
        public void RemoveAllEntriesOfElement(T element)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(element))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }

                    if (head == current)
                    {
                        head = current.Next;
                    }

                    if (tail == current)
                    {
                        tail = current.Previous;
                    }
                    count--;
                }
                current = current.Next;
            }
        }

        //8
        public void InsertBeforeElement(T element, T newElement)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(element))
                {
                    Node<T> newNode = new Node<T>(newElement);
                    newNode.Next = current;
                    newNode.Previous = current.Previous;
                    if (current.Previous != null)
                    {
                        current.Previous.Next = newNode;
                    }
                    if (head == current)
                    {
                        head = newNode;
                    }
                    current.Previous = newNode;
                    count++;
                    break;
                }
                current = current.Next;
            }
        }

        //9
        public void AddList(DoublyLinkedList<T> list)
        {
            tail.Next = list.getHead();
            list.getHead().Previous = tail;
            tail = list.tail;
            count += list.Size();
        }

        //10
        public DoublyLinkedList<T> DevideByElement(T element)
        {
            DoublyLinkedList<T> newList = new DoublyLinkedList<T>();
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(element))
                {
                    if (current.Previous == null)
                    {
                        head = null;
                        tail = null;
                    }
                    else
                    {
                        current.Previous.Next = null;
                    }
                    tail = current.Previous;
                    while (current != null)
                    {
                        newList.AddLast(current.Data);
                        count--;
                        current = current.Next;
                    }
                    break;
                }
                current = current.Next;
            }
            return newList;
        }

        //11
        public void DoubleList()
        {
            Node<T> current = head;
            int i = 0;
            int initialCount = count;
            while (i < initialCount)
            {
                AddLast(current.Data);
                current = current.Next;
                i++;
            }
        }

        //12 
        public void SwapElements(T element1, T element2)
        {
            Node<T>? node1 = null;
            Node<T>? node2 = null;
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(element1))
                {
                    node1 = current;
                }
                else if (current.Data.Equals(element2))
                {
                    node2 = current;
                }
                current = current.Next;
            }
            if (node1 == null || node2 == null) { return; }
            SwapNodes(node1, node2);
        }

        private void SwapNodes(Node<T> node1, Node<T> node2)
        {
            if (node1.Previous != null)
            {
                node1.Previous.Next = node2;
            }
            else
            {
                head = node2;
            }
            if (node1.Next != null)
            {
                node1.Next.Previous = node2;
            }
            else
            {
                tail = node2;
            }
            if (node2.Previous != null)
            {
                node2.Previous.Next = node1;
            }
            else
            {
                head = node1;
            }
            if (node2.Next != null)
            {
                node2.Next.Previous = node1;
            }
            else
            {
                tail = node1;
            }
            Node<T> temp = node1.Previous;
            node1.Previous = node2.Previous;
            node2.Previous = temp;

            temp = node1.Next;
            node1.Next = node2.Next;
            node2.Next = temp;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
