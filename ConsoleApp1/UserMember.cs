using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class UserMember
    {
        public string[] Name { get; }
        private readonly string password;
        public string ContactNumber { get; }

        private Menu userMenu;

        public UserMember(string[] name, string pswd, string contact)
        {
            Name = name;
            password = pswd;
            ContactNumber = contact;

            userMenu = new UserMenu(this);
        }

        public void DisplayToolsOfType()
        {
            Console.WriteLine("executed");
        }

        public void BorrowTool()
        {
            Console.WriteLine("executed");

        }

        public void ReturnTool()
        {
            Console.WriteLine("executed");

        }

        public void ListBorrowedTools()
        {
            Console.WriteLine("executed");

        }

        public void DisplayTopThreeTools()
        {

            Console.WriteLine("executed");
        }
    }
}
