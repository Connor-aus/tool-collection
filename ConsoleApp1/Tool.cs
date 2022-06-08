using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Tool
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
        public int NumberOnLoan { get; set; }
        public int Avalable { get; }
        //public UserMember[] MembersCurrentlyBorrowing { get; set; }
        //public BorrowToken[] MembersCurrentlyBorrowing { get; set; }
        public int[] MembersCurrentlyBorrowingIndex { get; set; }
        //public int[] NumberOnLoanByMember { get; set; }

        public Tool(string category, string type, string name, int quantity)
        {
            Category = category;
            Type = type;
            Name = name;
            Total = quantity;
            NumberOnLoan = 0;
            Avalable = Total - NumberOnLoan;

            // assumed an array of size 30 is sufficient 
            //MembersCurrentlyBorrowing = new UserMember[30];
            MembersCurrentlyBorrowingIndex = new int[MemberCollection.Members.Capacity];
            //MembersCurrentlyBorrowing = new BorrowToken[30];
            //NumberOnLoanByMember = new int[30];
        }


        public void AddBorrower(UserMember user)
        {
            // TODO fix this - user still in array after being removed by staff

            // list the index of borrower
            // count times the tool is in currently in CurrentlyBorrowed in Member

            int index = MemberCollection.Members.Search(user.Name);

            MembersCurrentlyBorrowingIndex[index] = 1;

            //MembersCurrentlyBorrowingIndex[index] = userBorrowing;
            //NumberOnLoanByMember[index] = 1;


            //var userBorrowedTools = userBorrowing.CurrentBorrowedTools;

            //NumberOnLoan++;

            //for (int i = 0; i < userBorrowedTools.Length && userBorrowedTools[i] != null; i++)
            //{
            //    if (userBorrowedTools[i].Name == this.Name)
            //    {
            //        NumberOnLoanByMember[i]++;
            //        return;
            //    }
            //}

            //int index = MemberCollection.Members.Search(userBorrowing.Name);

            //while (MembersCurrentlyBorrowingIndex[index] != null)
            //    index++;

            //MembersCurrentlyBorrowingIndex[index] = userBorrowing;
            //NumberOnLoanByMember[index] = 1;
        }


        public void DisplayCurrentBorrowing()
        {
            int loansFound = 0;
            int numberLoaned = 0;

            if (NumberOnLoan <=0)
            {
                Console.WriteLine("None of these tools are on loan");
                return;
            }

            // can use brute force as array is small
            for (int i = 0; i < MembersCurrentlyBorrowingIndex.Length && loansFound < NumberOnLoan; i++)
            {
                if (MembersCurrentlyBorrowingIndex[i] == 1)
                {
                    var member = (UserMember)MemberCollection.Members.MemberArray[MembersCurrentlyBorrowingIndex[i]].Value;

                    for (int j = 0; j < member.CurrentBorrowedTools.Length; j++)
                    {
                        if (member.CurrentBorrowedTools[i]?.Name == this.Name)
                        {
                            numberLoaned = member.CurrentBorrowedTools[i].Count;
                            loansFound += numberLoaned;
                            break;
                        }
                    }

                    Console.WriteLine($"{member.Name[0]} {member.Name[1]} is borrowing {numberLoaned} {this.Name}");
                }
            }
        }


        public void SortMembers()
        {
            //TODO if needed
        }
    }
}
