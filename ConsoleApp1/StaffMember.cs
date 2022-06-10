using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StaffMember
    {
        public string Username { get; }
        private readonly string password;
        public Menu staffMenu;


        public StaffMember(string username, string pswd)
        {
            Username = username;
            password = pswd;
            staffMenu = new StaffMenu(this);
        }


        public void AddTool()
        {
            Console.Clear();

            string toolName;
            string toolCategory;
            string toolType;
            string input;

            Console.WriteLine("==========Add Tool==========");
            Console.WriteLine("     Enter tool details (0 to exit)");

            Console.Write("\n   Please enter a tool name  : ");
            toolName = Console.ReadLine();

            while (toolName == "")
                toolName = InvalidInput();

            if (toolName == "0")
                return;

            var tool = ToolCollection.Tools.SearchTool(toolName);

            if (tool != null)
            {
                // tool already exists
                // increases total
                tool.Total++;

                Console.WriteLine("\n\tThis tool already exist in the Library.");
                Console.WriteLine($"\tAdding another {toolName} to the library. ");
                Console.Write($"\tThere is now a total of {tool.Total} {toolName} in the library. ");
                Console.ReadKey();

                return;
            }
            else
            {
                // tool is new
                // enter tool category
                Console.WriteLine($"\n\t{toolName} does not currently exist in the library.");
                Console.WriteLine("\tPlease answer the following questions so it can be added.");
                Console.WriteLine("\nPlease select a category for this tool:\n");

                for (int i = 0; i < ToolCollection.Tools.ToolLibrary.Length; i++)
                    Console.WriteLine($"\t{i + 1}. {ToolCollection.Tools.ToolLibrary[i][0][0].Category ?? "empty"}");

                Console.WriteLine($"\t0. Exit");

                input = Console.ReadLine();

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

                toolCategory = ToolCollection.Tools.ToolLibrary[category - 1][0][0].Category;


                // enter tool type
                Console.WriteLine("\nPlease select a type for this tool:\n");
                for (int i = 0; i < ToolCollection.Tools.ToolLibrary[category - 1].Length; i++)
                    Console.WriteLine($"\t{i + 1}. {ToolCollection.Tools.ToolLibrary[category - 1][i][0].Type ?? "empty"}");

                Console.WriteLine($"\t99. Create a new tool type.");
                Console.WriteLine($"\t0. Exit");

                input = Console.ReadLine();

                if (input == "0")
                    return;

                int.TryParse(input, out int type);

                while (type < 1 || (type > ToolCollection.Tools.ToolLibrary[category - 1].Length && type != 99))
                {
                    input = InvalidInput();

                    if (input == "0")
                        return;

                    int.TryParse(input, out type);
                }

                if (type == 99)
                {
                    // create new tool type, add to array and add new tool

                    Console.Write("\n   Please enter name of new tool type  : ");
                    toolType = Console.ReadLine();

                    while (toolType == "" || toolType == "0")
                        toolType = InvalidInput();

                    if (toolType == "0")
                        return;

                    // increase length of type array in chosen category to allow for new tool type
                    var types = new Tool[ToolCollection.Tools.ToolLibrary[category - 1].Length + 1][];

                    for (int i = 0; i < ToolCollection.Tools.ToolLibrary[category - 1].Length; i++)
                        types[i] = ToolCollection.Tools.ToolLibrary[category - 1][i] ?? null;

                    types[types.Length - 1] = new Tool[10];

                    //assumed 5 tools are added at the beginning
                    types[types.Length - 1][0] = new Tool(toolCategory, toolType, toolName, 5);

                    ToolCollection.Tools.ToolLibrary[category - 1] = types;

                    Console.WriteLine("\n\tSuccess. The following tool has been added:");
                    Console.WriteLine($"\t\tName      : {toolName}");
                    Console.WriteLine($"\t\tCetegory  : {toolCategory}");
                    Console.WriteLine($"\t\tType      : {toolType} ");
                    Console.Write($"\t\tQuantity  : {ToolCollection.Tools.ToolLibrary[category - 1][0][0].Total} ");
                    Console.ReadKey();

                    return;
                }
                else
                {
                    //add tool to exisitng tool category

                    toolType = ToolCollection.Tools.ToolLibrary[category - 1][type - 1][0].Type;

                    // assumed the array is not full
                    int index = 0;

                    while (ToolCollection.Tools.ToolLibrary[category - 1][type - 1][index] != null)
                        index++;

                    //assumed 5 tools are added at the beginning
                    ToolCollection.Tools.ToolLibrary[category - 1][type - 1][index] = new Tool(toolCategory, toolType, toolName, 5);

                    Console.WriteLine("\n\tSuccess. The following tool has been added:");
                    Console.WriteLine($"\t\tName      : {toolName}");
                    Console.WriteLine($"\t\tCetegory  : {toolCategory}");
                    Console.Write($"\t\tType      : {toolType} ");
                    Console.ReadKey();
                }
            }
        }


        public void RemoveTool()
        {
            Console.Clear();

            string toolName;

            Console.WriteLine("==========Remove Tool==========");
            Console.WriteLine("     Enter tool details (0 to exit)");

            Console.Write("\n   Please enter a tool name  : ");
            toolName = Console.ReadLine();

            while (toolName == "")
                toolName = InvalidInput();

            while (toolName != "0")
            {
                var tool = ToolCollection.Tools.SearchTool(toolName);

                if (tool != null)
                {
                    if (tool.Total <= 0)
                        Console.Write($"\tCannot remove {toolName} as there none in the library. ");
                    else if (tool.Available <= 0)
                        Console.Write($"\tCannot remove {toolName} as they are all on loan. ");
                    else if (tool.Total == 1)
                    {
                        // remove tool from tool library
                        ToolCollection.Tools.RemoveTool(tool);
                        Console.WriteLine($"\tThe final copy of {toolName} has been removed.");
                        Console.Write($"\t{toolName} has been removed from the library. ");
                    }
                    else
                    {
                        tool.Total--;
                        Console.Write($"\tThere is now a total of {tool.Total} {toolName} in the library. ");
                    }

                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.Write("\nTool not found. Please try again : ");
                    toolName = Console.ReadLine();

                    while (toolName == "")
                        toolName = InvalidInput();
                }
            }
        }


        public void RegisterMember()
        {
            Console.Clear();

            string[] userDetails;
            string firstName = "";
            string lastName = "";
            int contactNumber;
            string password = "";

            Console.WriteLine("==========Register Member==========");

            Console.Write("\n   Please enter member first name  : ");
            firstName = Console.ReadLine();

            while (firstName == "")
                firstName = InvalidInput();

            Console.Write("\n   Please enter member last name   : ");
            lastName = Console.ReadLine();

            while (lastName == "")
                lastName = InvalidInput();

            Console.Write("\n   Please enter member contact number  : ");
            bool validInpud = int.TryParse(Console.ReadLine(), out contactNumber);

            while (!validInpud)
                validInpud = int.TryParse(InvalidInput(), out contactNumber);

            userDetails = new string[] { firstName, lastName };

            // a member with the same first and last name combination is considered to be unique
            var found = MemberCollection.Members.Search(userDetails);

            if (found != -1)
            {
                bool validResponse = false;

                Console.WriteLine("\n\tThis user already exists. Please select an option");
                Console.WriteLine("\t1. Try again");
                Console.WriteLine("\t0. Return");
                Console.Write("\t\t: ");

                while (!validResponse)
                {
                    var response = Console.ReadLine();

                    if (response == "1")
                    {
                        RegisterMember();
                        return;
                    }
                    else if (response == "0")
                    {
                        return;
                    }

                    Console.Write("\n\t\tInvalid respones, try again: ");
                }
            }
            else
            {
                Console.Write("\n   Please enter member password  : ");
                password = Console.ReadLine();

                while (password == "")
                    password = InvalidInput();

                MemberCollection.Members.Insert(new UserMember(userDetails, password, contactNumber));

                Console.Write("\n\tSuccess ");
                Console.ReadKey();
            }
        }


        public void RemoveMember()
        {
            Console.Clear();

            string[] userDetails;
            string firstName = "";
            string lastName = "";

            Console.WriteLine("==========Remove Member==========");

            Console.Write("\n   Please enter member first name  : ");
            firstName = Console.ReadLine();

            while (firstName == "")
                firstName = InvalidInput();

            Console.Write("\n   Please enter member last name   : ");
            lastName = Console.ReadLine();

            while (lastName == "")
                lastName = InvalidInput();

            userDetails = new string[] { firstName, lastName };

            // a member with the same first and last name combination is considered to be unique
            var found = MemberCollection.Members.Search(userDetails);

            if (found == -1)
            {
                bool validResponse = false;

                Console.WriteLine("\n\tUser not found. Please select an option");
                Console.WriteLine("\t1. Try again");
                Console.WriteLine("\t0. Return");
                Console.Write("\t\t: ");

                while (!validResponse)
                {
                    var response = Console.ReadLine();

                    if (response == "1")
                    {
                        RemoveMember();
                        return;
                    }
                    else if (response == "0")
                    {
                        return;
                    }

                    Console.Write("\n\t\tInvalid respones, try again: ");
                }
            }
            else
            {
                var member = (UserMember)MemberCollection.Members.MemberArray[found].Value;

                if (member.TotalToolsBorrowed > 0)
                {
                    Console.Write($"\n{firstName} currently has tools on loan and cannot be removed. ");
                    Console.ReadKey();
                    return;
                }

                MemberCollection.Members.Delete(userDetails);

                Console.Write("\n\tSuccess ");
                Console.ReadKey();
            }
        }


        public void DisplayMembersBorrowingTool()
        {
            Console.Clear();

            Console.WriteLine("==========Display Member Currently Borrowing a Tool==========");

            Console.Write("\n   Please enter tool name  : ");
            string input = Console.ReadLine();

            while (input == "")
                input = InvalidInput();

            var tool = ToolCollection.Tools.SearchTool(input);

            if (tool != null)
            {
                tool.DisplayCurrentBorrowing();
                Console.ReadKey();
            }
            else
            {
                bool validResponse = false;

                Console.WriteLine("\nTool not found. Please select an option");
                Console.WriteLine("\t1. Try again");
                Console.WriteLine("\t0. Return");
                Console.Write("\t\t: ");

                while (!validResponse)
                {
                    var response = Console.ReadLine();

                    if (response == "1")
                    {
                        DisplayMembersBorrowingTool();
                        return;
                    }
                    else if (response == "0")
                    {
                        return;
                    }

                    Console.Write("\n\t\tInvalid respones, try again: ");
                }
            }
        }


        public void FindMemberPhoneNumber()
        {
            Console.Clear();

            string[] userDetails;
            string firstName;
            string lastName;

            Console.WriteLine("==========Find Member Contact Details==========");

            Console.Write("\n   Please enter member first name  : ");
            firstName = Console.ReadLine();

            Console.Write("\n   Please enter member last name   : ");
            lastName = Console.ReadLine();

            userDetails = new string[] { firstName, lastName };

            var found = MemberCollection.Members.Search(userDetails);

            if (found != -1)
            {
                UserMember member = (UserMember)MemberCollection.Members.MemberArray[found].Value;
                Console.WriteLine($"\n\tMember contact number    : {member.ContactNumber}");
                Console.ReadKey();
            }
            else
            {
                bool validResponse = false;

                Console.WriteLine("\n\tUser not found. Please select an option");
                Console.WriteLine("\t1. Try again");
                Console.WriteLine("\t0. Return");
                Console.Write("\t\t: ");

                while (!validResponse)
                {
                    var response = Console.ReadLine();

                    if (response == "1")
                    {
                        FindMemberPhoneNumber();
                        return;
                    }
                    else if (response == "0")
                    {
                        return;
                    }

                    Console.Write("\n\t\tInvalid respones, try again: ");
                }
            }
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
