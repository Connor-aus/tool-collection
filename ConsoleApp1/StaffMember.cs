using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StaffMember
    {
        public string Username { get; }
        private readonly string password;
        private Menu staffMenu;
        public ToolCollection toolCollection;

        public StaffMember(string username, string pswd)
        {
            Username = username;
            password = pswd;
            staffMenu = new StaffMenu(this);
        }

        public void AddTool()
        {
            Console.WriteLine("executed");
        }

        public void RemoveTool()
        {
            Console.WriteLine("executed");

        }

        public void RegisterMember()
        {
            Console.WriteLine("executed");

        }

        public void RemoveMember()
        {
            Console.WriteLine("executed");

        }

        public void DisplayMembersBorrowingTool()
        {

            Console.WriteLine("executed");
        }

        public void FindMemberPhoneNumber()
        {
            Console.WriteLine("executed");
        }
    }
}
