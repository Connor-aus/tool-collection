using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class UserMember
    {
        public string[] Name { get; }
        private readonly string password;
        public int ContactNumber { get; }
        public int TotalToolsBorrowed { get; set; }
        public int MaxBorrowedCapacity { get; set; }
        public BorrowToken[] CurrentBorrowedTools { get; set; }
        public Menu userMenu;

        // constructor
        public UserMember(string[] name, string pswd, int contact)
        {
            Name = name;
            password = pswd;
            ContactNumber = contact;
            TotalToolsBorrowed = 0;
            MaxBorrowedCapacity = 5;
            CurrentBorrowedTools = new BorrowToken[MaxBorrowedCapacity]; // array used due to small borrowing capacity

            userMenu = new UserMenu(this);
        }


        public void DisplayToolsOfType()
        {
            Console.Clear();

            Console.WriteLine("==========Display Tools==========");
            Console.WriteLine("     Enter tool details (0 to exit)");

            Console.WriteLine("\nPlease select a category:\n");

            for (int i = 0; i < ToolCollection.Tools.ToolLibrary.Length; i++)
                Console.WriteLine($"\t{i + 1}. {ToolCollection.Tools.ToolLibrary[i][0][0].Category ?? "empty"}");

            Console.WriteLine($"\t0. Exit");

            string input = Console.ReadLine();

            if (input == "0")
                return;

            int.TryParse(input, out int category);

            while (category < 1 || category > ToolCollection.Tools.ToolLibrary.Length)
            {
                input = InvalidInput();

                if (input == "0")
                    return;

                int.TryParse(input, out category);
            }

            string toolCategory = ToolCollection.Tools.ToolLibrary[category - 1][0][0].Category;

            // enter tool type
            Console.WriteLine("\nPlease select a type:\n");
            for (int i = 0; i < ToolCollection.Tools.ToolLibrary[category - 1].Length; i++)
                Console.WriteLine($"\t{i + 1}. {ToolCollection.Tools.ToolLibrary[category - 1][i][0].Type ?? "empty"}");

            Console.WriteLine($"\t0. Exit");

            input = Console.ReadLine();

            if (input == "0")
                return;

            int.TryParse(input, out int type);

            while (type < 1 || type > ToolCollection.Tools.ToolLibrary[category - 1].Length)
            {
                input = InvalidInput();

                if (input == "0")
                    return;

                int.TryParse(input, out type);
            }

            string toolType = ToolCollection.Tools.ToolLibrary[category - 1][type - 1][0].Type;


            Console.WriteLine($"\nList of tools within: {toolCategory} - {toolType}:\n");
            for (int i = 0; i < ToolCollection.Tools.ToolLibrary[category - 1][type - 1].Length && ToolCollection.Tools.ToolLibrary[category - 1][type - 1][i] != null; i++)
                Console.WriteLine($"\t{i + 1}. {ToolCollection.Tools.ToolLibrary[category - 1][type - 1][i].Name ?? "empty"}");

            Console.ReadKey();
        }


        public void BorrowTool()
        {
            Console.Clear();

            Console.WriteLine("==========Display Tools==========");
            Console.WriteLine("     Enter tool details (0 to exit)");

            if (TotalToolsBorrowed >= MaxBorrowedCapacity)
            {
                Console.WriteLine("\nYou have reached your maximum borrowing capacity. \nReturn a tool to borrow more.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nEnter the name of the Tool you would like to borrow");
            Console.Write("\t: ");

            string toolName = Console.ReadLine();

            while (toolName != "0")
            {
                var tool = ToolCollection.Tools.SearchTool(toolName);

                if (tool != null)
                {
                    if (tool != null && tool.Avalable <= 0)
                    {
                        Console.Write("\n\tAll of these tools are currently on loan.");
                        Console.ReadKey();
                        return;
                    }

                    // search for already borrowed tool
                    // array not sorted as size is small
                    for (int i = 0; i < CurrentBorrowedTools.Length; i++)
                    {
                        if (CurrentBorrowedTools[i]?.Name == tool.Name)
                        {
                            CurrentBorrowedTools[i].Count++;
                            break;
                        }

                        if (CurrentBorrowedTools[i] == null)
                        {
                            CurrentBorrowedTools[i] = new BorrowToken(tool.Name);
                            tool.AddBorrower(this);
                            break;
                        }
                    }

                    TotalToolsBorrowed++;
                    ToolCollection.Tools.AddToHistory(tool.Name);

                    Console.Write("\n\tSuccess ");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.Write("\nTool not found. Please try again : ");
                    toolName = Console.ReadLine();
                }
            }
        }


        public void ReturnTool()
        {
            // TODO: 
        }


        public void ListBorrowedTools()
        {
            Console.Clear();
            Console.WriteLine("==========Borrowed Tools==========\n");

            if (TotalToolsBorrowed <= 0)
            {
                Console.Write("\tNot currently borrowing any tools. ");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < CurrentBorrowedTools.Length; i++)
            {
                if (CurrentBorrowedTools[i] != null)
                    Console.WriteLine($"Tool: {CurrentBorrowedTools[i].Name}    Count: x{CurrentBorrowedTools[i].Count}");
            }

            Console.ReadKey();
        }

        // displays more than three tools if multiple tools have been
        // borrowed an equal number of times for the final position
        public void DisplayTopThreeTools()
        {
            Console.Clear();
            Console.WriteLine("==========Top Three Borrowed Tools==========\n");

            if (ToolCollection.Tools.ToolBorrowHistory[0] == null)
            {
                Console.Write("\tNo tools have been borrowed. ");
                Console.ReadKey();
                return;
            }

            int index = 1;
            bool differentValue = false;

            for (int i = 0; i < ToolCollection.Tools.ToolBorrowHistory.Length; i++)
            {
                if ((i > 3 && differentValue) || ToolCollection.Tools.ToolBorrowHistory[i] == null || ToolCollection.Tools.ToolBorrowHistory[i].Count == 0)
                {
                    break;
                }

                Console.WriteLine($"{index}. {ToolCollection.Tools.ToolBorrowHistory[i].Name} borrowed {ToolCollection.Tools.ToolBorrowHistory[i].Count} times.");

                if (i < 3 && ToolCollection.Tools.ToolBorrowHistory[i].Count == ToolCollection.Tools.ToolBorrowHistory[i + 1]?.Count)
                    differentValue = false;
                else
                {
                    differentValue = true;
                    index = i + 2;
                }
            }

            Console.ReadKey();
        }


        public bool CheckPassword(string password)
        {
            if (password == this.password)
                return true;
            return false;
        }


        public string InvalidInput()
        {
            Console.Write("\n\t Invalid input. Try again: ");
            return Console.ReadLine();
        }
    }
}
