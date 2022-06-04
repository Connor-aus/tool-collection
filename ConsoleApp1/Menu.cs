using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public abstract class Menu
    {
        public abstract string Name { get; }

        public void DisplayMenuOptions(string[] menuOptions)
        {
            bool validSelection = false;
            int menuOptionsLength = menuOptions.Length;

            Console.WriteLine($"=========={Name}==========");

            for (int i = 0; i < menuOptionsLength - 1; i++)
            {
                Console.WriteLine($"{i + 1}. {menuOptions[i]}");
            }
            Console.WriteLine($"0. {menuOptions[menuOptionsLength - 1]}");

            Console.WriteLine("==========================");


            while (!validSelection)
            {
                Console.Write("     Select option from menu (0 to exit) - ");
                validSelection = Int32.TryParse(Console.ReadLine(), out int selection);

                if (validSelection && 0 <= selection && selection < menuOptions.Length)
                {
                    InvokeMethod(selection);
                    break;
                }
                else
                {
                    InvalidInputMessage();
                    validSelection = false;
                }
            }
        }

        public void InvalidInputMessage()
        {
            Console.WriteLine(" Invalid input, please try again or select '0' to exit.\n");
        }

        public abstract void InvokeMethod(int selection);
    }
}
