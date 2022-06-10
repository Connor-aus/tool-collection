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

            memberCollection.Print();

            Console.WriteLine("Welcome to the Tool Library System\n");

            Menu mainMenu = new MainMenu();
            mainMenu.DisplayMainMenu();

            Console.ReadKey();
        }


        // creates 10 dummy members and adds them to the member collection
        public static void PopulateTestUserData()
        {
            string[] firstNames = new string[10] { "Dave", "Julie", "Kelly", "Mohammad", "test1", "test2", "test3", "Chistine", "Masa", "Bo" };
            string[] lastNames = new string[10] { "Blazzeq", "Handers", "Whittaker", "Al Usam", "test", "test", "test", "Chay", "Hitataki", "Lo" };
            string[] name;
            string password = "p";

            for (int i = 0; i < firstNames.Length; i++)
            {
                name = new string[] { firstNames[i], lastNames[i] };
                MemberCollection.Members.Insert(new UserMember(name, password, 5));
                Console.WriteLine($"new Member : fname: {firstNames[i]}  lname: {lastNames[i]}  pswd: {password}  contact:  5");
            }

            name = new string[] { "11", "11" };
            MemberCollection.Members.Insert(new UserMember(name, "1", 1));
            Console.WriteLine("new Member : fname: 11  lname: 11  pswd: 1  contact: 1");

            Console.WriteLine("\n\t Above are some dummy members. They can be used for the pupose of testing member methods.");
            Console.WriteLine("\t * The members named Dave, test1, test2 and test3 will have the same hash key and require collision handling\n");
            Console.ReadKey();
        }
    }
}
