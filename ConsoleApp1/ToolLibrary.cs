using System;

namespace ConsoleApp1
{
    class ToolLibrary
    {
        static void Main(string[] args)
        {
            MemberCollection memberCollection = new MemberCollection();
            ToolCollection toolCollection = new ToolCollection();

            // populate dummy user members and a staff member data
            PopulateUsers();

            // populate tool data
            PopulateTools();
            

            Console.WriteLine("Welcome to the Tool Library System\n");

            Menu mainMenu = new MainMenu();

                Console.ReadKey();
        }

        private static void PopulateTools()
        {
            // tools
        }

        public static void PopulateUsers()
        {
            // user members and a staff member
        }
    }
}
