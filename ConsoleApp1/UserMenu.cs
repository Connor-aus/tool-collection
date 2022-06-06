using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class UserMenu : Menu
    {
        public override string Name { get; }
        public delegate void PreviousMenu();
        private PreviousMenu previousMenu;

        public UserMember userMember { get; }

        public UserMenu(UserMember user)
        {
            Name = "Staff Menu";
            userMember = user;
        }

        public override void DisplayMainMenu()
        {
            Console.Clear();
            previousMenu = () => { return; };

            var menuOptions = new string[] { "Display Tools of a Tool Type", "Borrow Tool", "Return Tool", 
                "List Borrowed Tools", "Display Top 3 Borrowed Tools", "Logout" };

            DisplayMenuOptions(menuOptions);
            previousMenu();
        }

        public override void InvokeMethod(int selection)
        {
            switch (selection)
            {
                case 0:
                    previousMenu();
                    break;

                case 1:
                    userMember.DisplayToolsOfType();
                    previousMenu = DisplayMainMenu;
                    break;

                case 2:
                    userMember.BorrowTool();
                    previousMenu = DisplayMainMenu;
                    break;

                case 3:
                    userMember.ReturnTool();
                    previousMenu = DisplayMainMenu;
                    break;

                case 4:
                    userMember.ListBorrowedTools();
                    previousMenu = DisplayMainMenu;
                    break;

                case 5:
                    userMember.DisplayTopThreeTools();
                    previousMenu = DisplayMainMenu;
                    break;

                default:
                    break;
            }
        }
    }
}
