using Dynamic_structures.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_structures
{
    public class Tests
    {
        //7
        public void Test7Func()
        {
            DoublyLinkedList<object> list = CreateObjectList();
            Console.Write("Введите элемент: ");
            object elem = Console.ReadLine();
            list.RemoveAllEntriesOfElement(elem);
            Console.WriteLine("Список после удаления:");
            StructureDisplayer.PrintLinkedList(list);
        }

        //8
        public void Test8Func()
        {
            DoublyLinkedList<object> list = CreateObjectList();
            Console.Write("Введите новый элемент: ");
            object newElem = Console.ReadLine();
            Console.Write("Введите элемент, перед которым вставить новый элемент: ");
            object elem = Console.ReadLine();
            list.InsertBeforeElement(elem, newElem);
            Console.WriteLine("Получилось:");
            StructureDisplayer.PrintLinkedList(list);
        }

        //9
        public void Test9Func()
        {
            DoublyLinkedList<object> list1 = CreateIntList();
            DoublyLinkedList<object> list2 = CreateIntList();
            list1.AddList(list2);
            Console.WriteLine("Склеиваем списки:");
            StructureDisplayer.PrintLinkedList(list1);
        }

        //10
        public void Test10Func()
        {
            int elem = 0;
            DoublyLinkedList<object> list = CreateIntList();
            Console.Write("Введите элемент: ");
            if (!int.TryParse(Console.ReadLine(), out elem))
            {
                Console.WriteLine("В следующий раз введите число!");
                return;
            }
            DoublyLinkedList<object> list2 = list.DevideByElement(elem);
            Console.WriteLine("Первый список:");
            StructureDisplayer.PrintLinkedList(list);
            Console.WriteLine("Второй список:");
            StructureDisplayer.PrintLinkedList(list2);
        }

        //11
        public void Test11Func()
        {
            DoublyLinkedList<object> list = CreateObjectList();
            Console.WriteLine("Удваиваем список");
            list.DoubleList();
            StructureDisplayer.PrintLinkedList(list);
        }

        //12
        public void Test12Func()
        {
            DoublyLinkedList<object> list = CreateObjectList();
            Console.Write("Введите первый элемент: ");
            object elem1 = Console.ReadLine();
            Console.Write("Введите второй элемент: ");
            object elem2 = Console.ReadLine();
            list.SwapElements(elem1, elem2);
            Console.WriteLine("Меняем элементы местами...");
            StructureDisplayer.PrintLinkedList(list);
        }

        private DoublyLinkedList<object> CreateObjectList()
        {
            DoublyLinkedList<object> list = new DoublyLinkedList<object>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast("test");
            list.AddLast(1);
            list.AddLast(true);
            Console.WriteLine("Список:");
            StructureDisplayer.PrintLinkedList(list);
            return list;
        }

        private DoublyLinkedList<object> CreateIntList()
        {
            Random random= new Random();
            DoublyLinkedList<object> list = new DoublyLinkedList<object>();
            list.AddLast(random.Next(100));
            list.AddLast(random.Next(100));
            list.AddLast(random.Next(100));
            list.AddLast(random.Next(100));
            list.AddLast(random.Next(100));
            Console.WriteLine("Список:");
            StructureDisplayer.PrintLinkedList(list);
            return list;
        }
    }
}
