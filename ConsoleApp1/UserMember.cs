using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class UserMember
    {
        public string[] Name { get; }
        private readonly string password;
        public string ContactNumber { get; }
        public int TotalToolsBorrowed { get; set; }
        public int MaxBorrowedCapacity { get; set; }
        private Tool[] CurrentBorrowedTools { get; set; }
        public Menu userMenu;

        // cosntructor
        public UserMember(string[] name, string pswd, string contact)
        {
            Name = name;
            password = pswd;
            ContactNumber = contact;
            TotalToolsBorrowed = 0;
            MaxBorrowedCapacity = 5;
            CurrentBorrowedTools = new Tool[MaxBorrowedCapacity]; // user of array due to small borrowing capacity

            userMenu = new UserMenu(this);
        }

        public void DisplayToolsOfType()
        {
            // TODO: 
        }

        public void BorrowTool()
        {
            if (TotalToolsBorrowed >= MaxBorrowedCapacity)
            {
                Console.WriteLine("You have reached your maximum borrowing capacity. \nReturn a tool to borrow more.");
                return;
            }
            
            Console.WriteLine("Enter the name of the Tool you would like to borrow");
            Console.Write("\t: ");

            string toolName = Console.ReadLine();

            var tool = ToolCollection.Tools.SearchTool(toolName);

            if (tool != null)
            {
                // as the array size is small it is not worth checking if the object already exists
                // allows for simple totalling when borrowing multiple of same tool
                for (int i = 0; i < CurrentBorrowedTools.Length; i++)
                {
                    if (CurrentBorrowedTools[i] == null)
                    {
                        Console.WriteLine(CurrentBorrowedTools[i]); // remove
                        CurrentBorrowedTools[i] = tool;
                        break;
                    }
                    Console.WriteLine(CurrentBorrowedTools[i]); // remove
                }

                tool.AddBorrower(this);
            }

            Console.ReadLine();
        }

        public void ReturnTool()
        {
            // TODO: 
        }

        public void ListBorrowedTools()
        {
            // TODO: creat NEW tool so when it is removed it is not 
        }

        public void DisplayTopThreeTools()
        {
            // TODO: display more if there is a tie
            // use selection sort
        }

        public bool CheckPassword(string password)
        {
            if (password == this.password)
                return true;
            return false;
        }
    }
}
