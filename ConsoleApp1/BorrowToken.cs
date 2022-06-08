using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class BorrowToken
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public BorrowToken(string name)
        {
            Name = name;
            Count = 1;
        }
    }
}
