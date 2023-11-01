

using Dynamic_structures.Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;

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
                new Item("calc")
                {
                    SubMenu = new List<Item>
                    {
                        new Item("Get data from a filе"),
                        new Item("Еnter the commаnd"),
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
                        string output1 = "Operations\n[1] Push\n[2] Pop\n[3] Top\n[4] IsEmpty\n[5] Print\n";
                        Console.WriteLine(output1);
                        Console.Write("Example (3 4 1,56 1,7 1,cat 2 5 4): ");
                        string input1 = Console.ReadLine();
                        Console.Clear();
                        PerformOperation(input1, stack);
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
                        StructureDisplayer displayer = new StructureDisplayer(operationsOfqueue, new MyQueue());
                        displayer.InvokeQueue();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.ReadKey();
                    break;
                case "Еnter the command":
                    try
                    {
                        string output2 = "Operations\n[1] Enqueue\n[2] Dequence\n[3] GetFirst\n[4] IsEmpty\n[5] Print\n";
                        Console.WriteLine(output2);
                        Console.Write("Example (3 4 1,56 1,7 1,cat 2 5 4): ");
                        string input2 = Console.ReadLine();
                        Console.Clear();
                        PerformOperation(input2, queue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.ReadKey();
                    break;

                //calc
                case "Get data from a filе":
                    try
                    {
                        Console.WriteLine("[1] Postfix\n[2] Infix\n");
                        Console.Write("Enter the operation: ");
                        if (int.TryParse(Console.ReadLine(), out int value))
                        {
                            if (value < 1 || value > 2)
                            {
                                throw new Exception("[1, 2] is range of operation");
                            }

                            Console.Write("Enter the path to the file: ");
                            List<string> expression = Parser.ParseExpression(Console.ReadLine());
                            PostfixCalculator calculator = new PostfixCalculator();
                            Console.Clear();

                            if (value == 1)
                            {
                                calculator.Calculate(expression, false);
                            }
                            else
                            {
                                calculator.Calculate(expression, true);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.ReadKey();
                    break;
                case "Еnter the commаnd":
                    try
                    {
                        Console.WriteLine("[1] Postfix\n[2] Infix\n");
                        Console.Write("Enter the operation: ");
                        if (int.TryParse(Console.ReadLine(), out int value))
                        {
                            if (value < 1 || value > 2)
                            {
                                throw new Exception("[1, 2] is range of operation");
                            }

                            Console.Write("Enter a command: ");
                            List<string> expression = Parser.ParseExpressionStr(Console.ReadLine());
                            PostfixCalculator calculator = new PostfixCalculator();
                            
                            if (value == 1)
                            {
                                calculator.Calculate(expression, false);
                            }
                            else
                            {
                                calculator.Calculate(expression, true);
                            }
                        }
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

        public void PerformOperation(string line, MyStack stack)
        {
            List<Operation> oper = Parser.ParseStr(line);
            StructureDisplayer displayer = new StructureDisplayer(oper, stack);
            displayer.Invoke();
        }

        public void PerformOperation(string line, MyQueue queue)
        {
            List<Operation> oper = Parser.ParseStr(line);
            StructureDisplayer displayer = new StructureDisplayer(oper, queue);
            displayer.InvokeQueue();
        }

    }



}