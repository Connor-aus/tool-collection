using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StaffMenu : Menu
    {
        public override string Name { get; }
        StaffMember staffMember;

        public StaffMenu(StaffMember staff)
        {
            Name = "Staff Menu";
            staffMember = staff;
            DisplayStaffMenu();
        }

        private void DisplayStaffMenu()
        {
            Console.Clear();

            var menuOptions = new string[] { $"{nameof(StaffMember.AddTool)}", $"{nameof(StaffMember.RemoveTool)}", $"{nameof(StaffMember.RegisterMember)}",
                $"{nameof(StaffMember.RemoveMember)}", $"{nameof(StaffMember.DisplayMembersBorrowingTool)}", $"{nameof(StaffMember.FindMemberPhoneNumber)}", "Exit" };

            DisplayMenuOptions(menuOptions);
        }

        public override void InvokeMethod(int selection)
        {
            switch (selection)
            {
                case 0:
                    break;

                case 1:
                    staffMember.AddTool();
                    break;

                case 2:
                    staffMember.RemoveTool();
                    break;

                case 3:
                    staffMember.RegisterMember();
                    break;

                case 4:
                    staffMember.RemoveMember();
                    break;

                case 5:
                    staffMember.DisplayMembersBorrowingTool();
                    break;

                case 6:
                    staffMember.FindMemberPhoneNumber();
                    break;

                default:
                    break;
            }
        }
    }
}
