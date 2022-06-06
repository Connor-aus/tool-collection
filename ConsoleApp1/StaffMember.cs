using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StaffMember
    {
        public string Username { get; }
        private readonly string password;
        public Menu staffMenu;


        public StaffMember(string username, string pswd)
        {
            Username = username;
            password = pswd;
            staffMenu = new StaffMenu(this);
        }


        public void AddTool()
        {
            // TODO: 
        }


        public void RemoveTool()
        {
            // TODO: make sure to remove from all tool arrays in Member (should be automatic)
        }


        public void RegisterMember()
        {
            Console.Clear();

            string[] userDetails;
            string firstName = "";
            string lastName = "";
            string contactNumber = "";
            string password = "";

            Console.WriteLine("==========Register Member==========");

            Console.Write("\n   Please enter member first name  : ");
            firstName = Console.ReadLine();

            while (firstName == "")
                firstName = InvalidInput();

            Console.Write("\n   Please enter member last name   : ");
            lastName = Console.ReadLine();

            while (lastName == "")
                lastName = InvalidInput();

            Console.Write("\n   Please enter member contact number  : ");
            contactNumber = Console.ReadLine();

            while (contactNumber == "")
                contactNumber = InvalidInput();

            userDetails = new string[] { firstName, lastName };

            // a member with the same first and last name combination is considered to be unique
            var found = MemberCollection.Members.Search(userDetails);

            if (found != -1)
            {
                bool validResponse = false;

                Console.WriteLine("\n\tThis user already exists. Please select an option");
                Console.WriteLine("\t1. Try again");
                Console.WriteLine("\t0. Return");
                Console.Write("\t\t: ");

                while (!validResponse)
                {
                    var response = Console.ReadLine();

                    if (response == "1")
                    {
                        RegisterMember();
                        continue;
                    }
                    else if (response == "0")
                    {
                        continue;
                    }

                    Console.Write("\n\t\tInvalid respones, try again: ");
                }
            }
            else
            {
                Console.Write("\n   Please enter member password  : ");
                password = Console.ReadLine();

                while (password == "")
                    password = InvalidInput();

                MemberCollection.Members.Insert(new UserMember(userDetails, password, contactNumber));

                Console.Write("\n\tSuccess ");
                Console.ReadKey();
            }
        }


        public void RemoveMember()
        {
            // TODO: make sure member is removed from all tool collections also

            Console.Clear();

            string[] userDetails;
            string firstName = "";
            string lastName = "";

            Console.WriteLine("==========Remove Member==========");

            Console.Write("\n   Please enter member first name  : ");
            firstName = Console.ReadLine();

            while (firstName == "")
                firstName = InvalidInput();

            Console.Write("\n   Please enter member last name   : ");
            lastName = Console.ReadLine();

            while (lastName == "")
                lastName = InvalidInput();

            userDetails = new string[] { firstName, lastName };

            // a member with the same first and last name combination is considered to be unique
            var found = MemberCollection.Members.Search(userDetails);

            if (found == -1)
            {
                bool validResponse = false;

                Console.WriteLine("\n\tUser not found. Please select an option");
                Console.WriteLine("\t1. Try again");
                Console.WriteLine("\t0. Return");
                Console.Write("\t\t: ");

                while (!validResponse)
                {
                    var response = Console.ReadLine();

                    if (response == "1")
                    {
                        RemoveMember();
                        break;
                    }
                    else if (response == "0")
                    {
                        break;
                    }

                    Console.Write("\n\t\tInvalid respones, try again: ");
                }
            }
            else
            {
                MemberCollection.Members.Delete(userDetails);

                Console.Write("\n\tSuccess ");
                Console.ReadKey();
            }
        }


        public void DisplayMembersBorrowingTool()
        {
            // TODO: 
        }


        public void FindMemberPhoneNumber()
        {
            Console.Clear();

            string[] userDetails;
            string firstName;
            string lastName;

            Console.WriteLine("==========Find Member Contact Details==========");

            Console.Write("\n   Please enter member first name  : ");
            firstName = Console.ReadLine();

            Console.Write("\n   Please enter member last name   : ");
            lastName = Console.ReadLine();

            userDetails = new string[] { firstName, lastName };

            var found = MemberCollection.Members.Search(userDetails);

            if (found != -1)
            {
                UserMember member = (UserMember)MemberCollection.Members.MemberArray[found].Value;
                Console.Write($"\n\tMember contact number    : {member.ContactNumber}");
                Console.ReadKey();
            }
            else
            {
                bool validResponse = false;

                Console.WriteLine("\n\tUser not found. Please select an option");
                Console.WriteLine("\t1. Try again");
                Console.WriteLine("\t0. Return");
                Console.Write("\t\t: ");

                while (!validResponse)
                {
                    var response = Console.ReadLine();

                    if (response == "1")
                    {
                        FindMemberPhoneNumber();
                        continue;
                    }
                    else if (response == "0")
                    {
                        continue;
                    }

                    Console.Write("\n\t\tInvalid respones, try again: ");
                }
            }
        }


        public bool CheckPassword(string password)
        {
            if (password == this.password)
                return true;
            return false;
        }


        public string InvalidInput()
        {
            Console.Write("\n\t Invalid input. Try again: ");
            return Console.ReadLine();
        }
    }
}
