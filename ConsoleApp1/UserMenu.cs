using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class UserMenu : Menu
    {
        public override string Name { get; }
        UserMember userMember;

        public UserMenu(UserMember user)
        {
            Name = "Staff Menu";
            userMember = user;
            DisplayUserMenu();
        }

        private void DisplayUserMenu()
        {
            Console.Clear();

            var menuOptions = new string[] { $"{nameof(UserMember.DisplayToolsOfType)}", $"{nameof(UserMember.BorrowTool)}", $"{nameof(UserMember.ReturnTool)}",
                $"{nameof(UserMember.ListBorrowedTools)}", $"{nameof(UserMember.DisplayTopThreeTools)}", "Exit" };

            DisplayMenuOptions(menuOptions);
        }

        public override void InvokeMethod(int selection)
        {
            switch (selection)
            {
                case 0:
                    break;

                case 1:
                    userMember.DisplayToolsOfType();
                    break;

                case 2:
                    userMember.BorrowTool();
                    break;

                case 3:
                    userMember.ReturnTool();
                    break;

                case 4:
                    userMember.ListBorrowedTools();
                    break;

                case 5:
                    userMember.DisplayTopThreeTools();
                    break;

                default:
                    break;
            }
        }
    }
}
