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


        // creates 9 dummy members and adds them to the member collection
        public static void PopulateTestUserData()
        {
            string[] name = new string[2];
            string number;

            for (int i = 0; i < 9; i++)
            {
                number = (i + 1).ToString();
                name[0] = "member" + number;
                name[1] = "member";

                MemberCollection.Members.Insert(new UserMember(name, number, (i + 1) * 111));

                Console.WriteLine($"new Member : fname: {name[0]}  lname: {name[1]}  pswd: {number}  contact:  {(i + 1) * 111}");
            }

            name = new string[] { "1", "1" };
            MemberCollection.Members.Insert(new UserMember(name, "1", 1));
            Console.WriteLine("new Member : fname: 1  lname: 1  pswd: 1  contact: 1");

            Console.Write("\n\t Above are some dummy members. They can be used for the pupose of testing testing member methods. \n");
            Console.ReadLine();
        }
    }
}
