

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

        private MyQueue queue;

        public GUI()
        {
            queue = new MyQueue();

            stack = new MyStack();

            selectedOption = 0;

            options = new List<Item>
            {
                new Item("stack")
                {
                    SubMenu = new List<Item>
                    {
                        new Item("Get data from a file"),
                        new Item("Enter the command"),
                        new Item("Back")
                    }
                },
                new Item("queue")
                {
                    SubMenu = new List<Item>
                    {
                        new Item("Gеt data from a file"),
                        new Item("Еnter the command"),
                        new Item("Back")
                    }
                },
                new Item("calc"),

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
        
        public void PrintLogo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string logo = "  ____   _        ____   _   _   _  \r\n / ___| | |      / ___| | | | | | | \r\n| |  _  | |     | |  _  | | | | | | \r\n| |_| | | |___  | |_| | | |_| | | | \r\n \\____| |_____|  \\____|  \\___/  |_| \n\n";
            Console.WriteLine(logo);
            Console.ResetColor();
        }

        public void DrawMenu(List<Item> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("-> ");
                Console.ResetColor();
                if (i == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }


                Console.WriteLine(options[i].Name); 
                Console.ResetColor();
            }
        }
       
        public void RunSelectedFunction(string itemName)
        {
            Console.Clear();
            
            switch (itemName)
            {
                //stack
                case "Get data from a file":
                    try
                    {
                        Console.Write("Enter the path to the file: ");
                        List<Operation> operationsOfStack = Parser.Parse(Console.ReadLine());
                        Console.Clear();
                        StructureDisplayer displayer = new StructureDisplayer(operationsOfStack, new MyStack());
                        displayer.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.ReadKey();
                    break;
                case "Enter the command":
                    try
                    {
                        string output = "Operations\n[1] Push\n[2] Pop\n[3] Top\n[4] IsEmpty\n[5] Print\n";
                        Console.WriteLine(output);
                        Console.Write("Example (3 4 1,56 1,7 1,cat 2 5 4): ");
                        string input = Console.ReadLine();
                        Console.Clear();
                        PerformStackOperation(input, stack);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.ReadKey();
                    break;

                //queue
                case "Gеt data from a file":
                    try
                    {
                        Console.Write("Enter the path to the file: ");
                        List<Operation> operationsOfqueue = Parser.Parse(Console.ReadLine());
                        Console.Clear();


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }

        public void PerformStackOperation(string line, MyStack stack)
        {
            List<Operation> oper = Parser.ParseStr(line);
            StructureDisplayer displayer = new StructureDisplayer(oper, stack);
            displayer.Invoke();
        }


        public void KPrint(string? value)
        {
            Console.WriteLine(value);
            Console.ReadKey();
        }

    }
}