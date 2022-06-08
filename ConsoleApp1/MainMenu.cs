using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace ConsoleApp1
{
    public class MainMenu : Menu
    {
        public override string Name { get; }
        public delegate void PreviousMenu();
        private PreviousMenu previousMenu;
        private StaffMember staffMember;

        public MainMenu()
        {
            Name = "Main Menu";

            // create generic staff member
            staffMember = new StaffMember("staff", "today123");
        }


        public override void DisplayMainMenu()
        {
            Console.Clear();
            previousMenu = () => { Console.WriteLine("\nExiting program . . ."); };

            var menuOptions = new string[] { "Staff Login", "Member Login", "Exit" };

            DisplayMenuOptions(menuOptions);
        }


        public override void InvokeMethod(int selection)
        {
            switch (selection)
            {
                case 0:
                    previousMenu();
                    break;

                case 1:
                    StaffLogin();
                    previousMenu();
                    break;

                case 2:
                    MemberLogin();
                    previousMenu();
                    break;

                default:
                    break;
            }
        }


        public void StaffLogin()
        {
            //TODO remove auto login
            previousMenu = DisplayMainMenu;
            staffMember.staffMenu.DisplayMainMenu();
            return;


            Console.Clear();
            previousMenu = DisplayMainMenu;

            string username = "";
            string password = "";

            Console.WriteLine("==========Staff Login==========");
            Console.WriteLine("     Enter login details (0 to exit)");

            while (password != "0")
            {
                Console.Write("\n   Please enter your username  : ");
                username = Console.ReadLine();

                if (username == "0")
                    return;

                if (username == staffMember.Username)
                {
                    Console.Write("\n   Please enter your password  : ");
                    password = Console.ReadLine();

                    if (staffMember.CheckPassword(password))
                    {
                        staffMember.staffMenu.DisplayMainMenu();
                        return;
                    }

                    if (password == "0")
                        return;
                }

                Console.WriteLine("\n User not found. Please try again");
            }
        }


        public void MemberLogin()
        {
            Console.Clear();
            previousMenu = DisplayMainMenu;

            string[] userDetails;
            string firstName = "";
            string lastName = "";
            string password = "";

            Console.WriteLine("==========Member Login==========");
            Console.WriteLine("     Enter login details (0 to exit)");

            if (password != "0")
            {
                Console.Write("\n   Please enter your first name    : ");
                firstName = Console.ReadLine();

                if (firstName == "0")
                    return;

                while (firstName == "")
                    firstName = InvalidInput();

                Console.Write("\n   Please enter your last name     : ");
                lastName = Console.ReadLine();

                if (lastName == "0")
                    return;

                while (lastName == "")
                    lastName = InvalidInput();

                userDetails = new string[] { firstName, lastName };

                var memberIndex = MemberCollection.Members.Search(userDetails);

                if (memberIndex == -1)
                {
                    Console.WriteLine("\nUser not found, please try again . . .");
                    Console.ReadLine();
                    MemberLogin();
                }
                else
                {
                    Console.Write("\n   Please enter your password      : ");

                    UserMember member = (UserMember)MemberCollection.Members.MemberArray[memberIndex].Value;

                    while (!member.CheckPassword(password))
                    {
                        password = Console.ReadLine();

                        if (password == "0")
                            return;

                        if (member.CheckPassword(password))
                        {
                            Console.Write($"\n\tWelcome {firstName}\n ");
                            Console.ReadKey();

                            member.userMenu.DisplayMainMenu();
                            return;
                        }

                        Console.Write("\nIncorrect password, please try again : ");
                    }
                }
            }
        }


        public string InvalidInput()
        {
            Console.Write("\n\t Invalid input. Try again: ");
            return Console.ReadLine();
        }
    }
}
