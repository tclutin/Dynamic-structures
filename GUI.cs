

using Dynamic_structures.Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Dynamic_structures
{
    public class Item
    {
        public string Name { get; set; }
        public List<Item> SubMenu { get; set; }

        public Item(string name)
        {
            Name = name;
            SubMenu = new List<Item>();
        }
    }

    public class GUI
    {
        private int selectedOption;

        private List<Item> options;

        private MyStack stack;

        public GUI()
        {
            stack = new MyStack();

            selectedOption = 0;

            options = new List<Item>
            {
                new Item("stack")
                {
                    SubMenu = new List<Item>
                    {
                        new Item("Get data from a file"),
                        new Item("Enter the command manually"),
                        new Item("Back")
                    }
                },
                new Item("queue")
                {
                    SubMenu = new List<Item>
                    {
                        new Item("Добавить элемент в очередь"),
                        new Item("Извлечь элемент из очереди"),
                        new Item("Back")
                    }
                },
                new Item("Exit")
            };

        }


        public void Start()
        {
            List<Item> currentMenu = options;

            while (true)
            {
                Console.Clear();
                DrawMenu(currentMenu);

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && selectedOption > 0)
                {
                    selectedOption--;
                }
                else if (key.Key == ConsoleKey.DownArrow && selectedOption < currentMenu.Count - 1)
                {
                    selectedOption++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (selectedOption == currentMenu.Count - 1)
                    {
                        if (currentMenu == options)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            currentMenu = options;
                            selectedOption = 0;
                        }
                    }
                    else
                    {
                        Item selectedItem = currentMenu[selectedOption];
                        if (selectedItem.SubMenu != null && selectedItem.SubMenu.Count > 0)
                        {
                            currentMenu = selectedItem.SubMenu;
                            selectedOption = 0;
                        }
                        else
                        {
                            RunSelectedFunction(selectedItem.Name);
                        }
                    }
                }
            }
        }

        public void DrawMenu(List<Item> options)
        {
            for (int i = 0; i < options.Count; i++)
            {

                if (i == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine("-> " + options[i].Name); 
                Console.ResetColor();
            }
        }
       

        public void RunSelectedFunction(string itemName)
        {
            Console.Clear();
            
            switch (itemName)
            {
                case "Get data from a file":
                    Console.Write("Enter the path to the file: ");
                    List<Operation> operations = Parser.Parse(Console.ReadLine());
                    Console.Clear();

                    StructureDisplayer displayer = new StructureDisplayer(operations, new MyStack());
                    displayer.Invoke();
                    Console.ReadKey();
                    break;
                case "Enter the command manually":
                    
                    string output = "[1] Push\n[2] Pop\n[3] Top\n[4] IsEmpty\n[5] Print\n";
                    Console.WriteLine(output);

                    Console.Write("Enter a nubmer of commands: ");
                    if (!int.TryParse(Console.ReadLine(), out int value))
                    {
                        KPrint("Invalid Data");
                        break;
                    }
                    PerformStackOperation(value, stack);
                    break;

                case "2":
                    KPrint("Invalid option");
                    break;
            }
        }

        public void PerformStackOperation(int operation, MyStack stack)
        {
            switch (operation)
            {
                case 1:
                    Console.Write("Enter an element: ");
                    object value = Console.ReadLine();
                    if (value == "")
                    {
                        KPrint("Invalid Data");
                        break;
                    }

                    object element = value;

                    stack.Push(element);
                    KPrint($"'{element}' was pushed");
                    break;
                case 2:
                    KPrint($"Pop: {stack.Pop()}");
                    break;
                case 3:
                    KPrint($"Top: {stack.Top()}");
                    break;
                case 4:
                    KPrint($"IsEmpty: {stack.IsEmpty()}");
                    break;
                case 5:
                    stack.Print();
                    Console.ReadKey();
                    break;
                default:
                    KPrint("Invalid option");
                    break;
            }
        }

        public void KPrint(string? value)
        {
            Console.WriteLine(value);
            Console.ReadKey();
        }

    }
}