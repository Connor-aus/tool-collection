using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StaffMenu : Menu
    {
        public override string Name { get; }
        public delegate void PreviousMenu();
        private PreviousMenu previousMenu;

        StaffMember staffMember;

        public StaffMenu(StaffMember staff)
        {
            Name = "Staff Menu";
            staffMember = staff;
        }

        public override void DisplayMainMenu()
        {
            Console.Clear();
            previousMenu = () => { return; };

            var menuOptions = new string[] { "Add Tool", "Remove Tool", "Register Member", "Remove Member", 
                "Display Members Borrowing a Tool", "Find Member Phone Number", "Logout" };

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
                    staffMember.AddTool();
                    previousMenu = DisplayMainMenu;
                    break;

                case 2:
                    staffMember.RemoveTool();
                    previousMenu = DisplayMainMenu;
                    break;

                case 3:
                    staffMember.RegisterMember();
                    previousMenu = DisplayMainMenu;
                    break;

                case 4:
                    staffMember.RemoveMember();
                    previousMenu = DisplayMainMenu;
                    break;

                case 5:
                    staffMember.DisplayMembersBorrowingTool();
                    previousMenu = DisplayMainMenu;
                    break;

                case 6:
                    staffMember.FindMemberPhoneNumber();
                    previousMenu = DisplayMainMenu;
                    break;

                default:
                    break;
            }
        }
    }
}
