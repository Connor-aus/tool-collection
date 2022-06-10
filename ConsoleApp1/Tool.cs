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
        public int[] MembersCurrentlyBorrowingIndex { get; set; }

        public int Available
        {
            get { return (Total - NumberOnLoan); }
        }

        public Tool(string category, string type, string name, int quantity)
        {
            Category = category;
            Type = type;
            Name = name;
            Total = quantity;
            NumberOnLoan = 0;
            MembersCurrentlyBorrowingIndex = new int[MemberCollection.Members.Capacity];
        }


        public void AddBorrower(UserMember user)
        {
            int index = MemberCollection.Members.Search(user.Name);

            MembersCurrentlyBorrowingIndex[index] = 1;
            NumberOnLoan++;
        }


        public void RemoveBorrower(UserMember user)
        {
            int index = MemberCollection.Members.Search(user.Name);

            MembersCurrentlyBorrowingIndex[index] = 0;
            NumberOnLoan--;
        }


        public void DisplayCurrentBorrowing()
        {
            int loansFound = 0;
            int numberLoaned = 0;

            if (NumberOnLoan <= 0)
            {
                Console.WriteLine("None of these tools are on loan");
                return;
            }

            // can use brute force as array is small
            for (int i = 0; i < MembersCurrentlyBorrowingIndex.Length && loansFound < NumberOnLoan; i++)
            {
                if (MembersCurrentlyBorrowingIndex[i] == 1)
                {
                    var member = (UserMember)MemberCollection.Members.MemberArray[i].Value;

                    for (int j = 0; j < member.CurrentBorrowedTools.Length; j++)
                    {
                        if (member.CurrentBorrowedTools[j]?.Name == this.Name)
                        {
                            numberLoaned = member.CurrentBorrowedTools[j].Count;
                            loansFound += numberLoaned;
                            break;
                        }
                    }

                    Console.WriteLine($"Member: {member.Name[0]} {member.Name[1]}  Count: x{numberLoaned}");
                }
            }
        }


        public void SortMembers()
        {
            //TODO if needed
        }
    }
}
