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
        public int CurrentlyBorrowed { get; set; }
        public int Avalable { get; }
        public MemberCollection MembersBorrowingTool { get; set; } // house this elsewhere maybe - don't want collision detection 
        public int[] IndexOfMembersBorrowingTool { get; set; } // indexes all members borrowing this tool 

        public Tool(string category, string type, string name, int quantity)
        {
            Category = category;
            Type = type;
            Name = name;
            Total = quantity;
            CurrentlyBorrowed = 0;
            Avalable = Total - CurrentlyBorrowed;
            //MembersBorrowingTool = MemberCollection.InitializeMemberCollection();
        }

        public void AddBorrower(UserMember userBorrowing)
        {
            // TODO: cant use singleton
            // don't remove index if borrow count is greater than

            //var user = MemberBorrowingTool.Members.Search(user);
            //if (user == null)
            //{
            //    // this method is in StaffMember class
            //    MembersBorrowingTool.AddMember(userBorrowing);
            //}
        }
    }
}
