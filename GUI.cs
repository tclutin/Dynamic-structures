

using Dynamic_structures.Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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

        private Tests tests = new Tests();

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
                        new Item("Получить данные с файла"),
                        new Item("Ввести команды"),
                        new Item("Назад")
                    }
                },
                new Item("queue")
                {
                    SubMenu = new List<Item>
                    {
                        new Item("Получить данные с файлa"),
                        new Item("Ввести комaнды"),
                        new Item("Назад")
                    }
                },
                new Item("calc")
                {
                    SubMenu = new List<Item>
                    {
                        new Item("Получить дaнные с файла"),
                        new Item("Ввести кoманды"),
                        new Item("Назад")
                    }
                },
                new Item("doubly list")
                {
                    SubMenu = new List<Item>
                    {
                        new Item("1. Перевернуть список"),
                        new Item("2. Поменять местами последний и первый элемент"),
                        new Item("3. Вывести количество уникальных элементов"),
                        new Item("4. Удаление неуникальных элементов"),
                        new Item("5. Соединение списка после n-ого элемента"),
                        new Item("6. Вставить элемент в упорядоченную коллекцию"),
                        new Item("7. Удаление всех вхождений элемента"),
                        new Item("8. Вставка элемента newElement перед элементом element"),
                        new Item("9. Соединение списков"),
                        new Item("10. Разбиение списка по первому вхождению элемента"),
                        new Item("11. Удвоение списка"),
                        new Item("12. Поменять два элемента местами"),
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
            string logo = "  _   _      _ _\r\n | | | | ___| | | ___\r\n | |_| |/ _ \\ | |/ _ \\\r\n |  _  |  __/ | | (_) |\r\n |_| |_|\\___|_|_|\\___/";
            Console.WriteLine(logo);
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();
        }

        public void DrawMenu(List<Item> options)
        {
            PrintLogo();
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
                case "Получить данные с файла":
                    try
                    {
                        Console.Write("Enter the path to the file: ");
                        List<Operation> operationsOfStack = Parser.Parse(Console.ReadLine());
                        Console.Clear();
                        foreach (Operation operation in operationsOfStack)
                        {
                            if (operation.Number == 1)
                            {
                                Console.Write(operation.Number + "," + operation.Data + " ");
                                continue;
                            }
                            Console.Write(operation.Number + " ");
                        }
                        Console.WriteLine();
                        StructureDisplayer displayer = new StructureDisplayer(operationsOfStack, new MyStack());
                        displayer.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.ReadKey();
                    break;
                case "Ввести команды":
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
                case "Получить данные с файлa":
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
                case "Ввести комaнды":
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
                case "Получить дaнные с файла":
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
                case "Ввести кoманды":
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

                //list
                case "1. Перевернуть список":
                    tests.Test1Func();
                    Console.ReadKey();
                    break;
                case "2. Поменять местами последний и первый элемент":
                    tests.Test2Func();
                    Console.ReadKey();
                    break;
                case "3. Вывести количество уникальных элементов":
                    tests.Test3Func();
                    Console.ReadKey();
                    break;
                case "4. Удаление неуникальных элементов":
                    tests.Test4Func();
                    Console.ReadKey();
                    break;
                case "5. Соединение списка после n-ого элемента":
                    tests.Test5Func();
                    Console.ReadKey();
                    break;
                case "6. Вставить элемент в упорядоченную коллекцию":
                    tests.Test6Func();
                    Console.ReadKey();
                    break;
                case "7. Удаление всех вхождений элемента":
                    tests.Test7Func();
                    Console.ReadKey();
                    break;
                case "8. Вставка элемента newElement перед элементом element":
                    tests.Test8Func();
                    Console.ReadKey();
                    break;
                case "9. Соединение списков":
                    tests.Test9Func();
                    Console.ReadKey();
                    break;
                case "10. Разбиение списка по первому вхождению элемента":
                    tests.Test10Func();
                    Console.ReadKey();
                    break;
                case "11. Удвоение списка":
                    tests.Test11Func();
                    Console.ReadKey();
                    break;
                case "12. Поменять два элемента местами":
                    tests.Test12Func();
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