using System;

namespace ConsoleApp1
{
    class ToolLibrary
    {
        static void Main(string[] args)
        {
            MemberCollection memberCollection = MemberCollection.InitializeMemberCollection();
            ToolCollection toolCollection = ToolCollection.InitializeToolCollection();

            // populate tool data
            toolCollection.PopulateToolData();

            // populate dummy user members and a staff member data
            PopulateTestUserData();

            Console.WriteLine("Welcome to the Tool Library System\n");

            Menu mainMenu = new MainMenu();
            mainMenu.DisplayMainMenu();

            Console.ReadKey();
        }

        public static void PopulateTestUserData()
        {
            // TOFO: user members and a staff member
        }

        public static void TestHashTable()
        {
            // TODO: 
            Hashtable h = new Hashtable(17);
            h.Insert(59);
            h.Print();
            h.Insert(39);
            h.Print();
            h.Insert(20);
            h.Print();
            h.Insert(33);
            h.Print();
            h.Insert(58);
            h.Print();
            h.Insert(23);
            h.Print();
            h.Insert(12);
            h.Print();
            h.Insert(29);
            h.Print();
            h.Insert(57);
            h.Print();
            h.Delete(29);
            h.Print();
            h.Delete(39);
            h.Print();
        }
    }
}
