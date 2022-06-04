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

        StaffMember staffMember;
        UserMember userMember;

        public MainMenu()
        {
            Name = "Main Menu";

            DisplayMainMenu();
        }

        public void DisplayMainMenu()
        {
            Console.Clear();
            previousMenu = () => { Console.WriteLine("\nExiting program..."); };

            var menuOptions = new string[] { $"{nameof(StaffLogin)}", $"{nameof(MemberLogin)}", "Exit" };

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
                    break;

                case 2:
                    MemberLogin();
                    break;

                default:
                    break;
            }
        }

        public void StaffLogin()
        {
            Console.Clear();
            previousMenu = DisplayMainMenu;
            string[] staffDetails = new string[] { "staff", "today123" };
            bool validInput = false;
            string username;
            string password = "-1";

            Console.WriteLine("==========Staff Login==========");
            Console.WriteLine("\n**you can enter '0' at any time to return**");

            while (!validInput && password != "0")
            {

                Console.Write("\n   Please enter your first username    : ");
                username = Console.ReadLine();

                if (username != "0")
                {
                    Console.Write("\n   Please enter your password          : ");
                    password = Console.ReadLine();

                    if (username == staffDetails[0] && password == staffDetails[1])
                    {
                        staffMember = new StaffMember(username, password);
                        break;
                    }
                }
                else
                {
                    break;
                }

                Console.WriteLine("\n User details not found. Please try again");
            }

            previousMenu();
        }

        public void MemberLogin()
        {
            Console.Clear();
            previousMenu = DisplayMainMenu;

            string[] userDetails;

            Console.WriteLine("==========Member Login==========");

            Console.Write("\n   Please enter your first name    : ");
            string firstName = Console.ReadLine();

            Console.Write("\n   Please enter your last name     : ");
            string lastName = Console.ReadLine();

            Console.Write("\n   Please enter your password      : ");
            string password = Console.ReadLine();

            userDetails = new string[] { firstName, lastName, password };

            // search in membercollection.

        }
    }
}
