using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class MemberCollection
    {
        private int buckets; //number of buckets
        private const string empty = "empty"; //an empty bucket
        private const string deleted = "deleted";  //a bucket where a key-and-value pair was deleted
        public int Count { get; set; } //the number of key-and-value pairs currently stored in the hashtable

        public Key_Value_Pair[] MemberArray { get; set; } // data structure containing all user members

        // initiate singleton
        private static MemberCollection members;

        // return singleton
        public static MemberCollection Members
        {
            get { return members; }
        }


        // initial singleton set-up and return singleton
        public static MemberCollection InitializeMemberCollection()
        {
            if (members == null)
                members = new MemberCollection(100);

            return members;
        }


        private MemberCollection(int size)
        {
            MemberArray = new Key_Value_Pair[100];

            if (size > 0)
                buckets = size;
            Count = 0;
            MemberArray = new Key_Value_Pair[buckets];
            for (int i = 0; i < buckets; i++)
                MemberArray[i] = new Key_Value_Pair(empty, null);
        }


        public int Capacity
        {
            get { return buckets; }
            set { buckets = Capacity; }
        }


        /* pre:  the hashtable is not full
         * post: return the bucket for inserting the key
         */
        private int FindInsertionBucket(string key)
        {
            int bucket = Hashing(key);
            int i = 0;
            int offset = 0;
            while ((i < buckets) &&
                (MemberArray[(bucket + offset) % buckets].Key != empty) &&
                (MemberArray[(bucket + offset) % buckets].Key != deleted))
            {
                offset = ProbingMethod(offset);
                i++;
            }
            return (offset + bucket) % buckets;
        }


        /* pre:  true
        * post: all the elements in the hashtable have been removed
        */
        public void Clear()
        {
            Count = 0;
            for (int i = 0; i < buckets; i++)
                MemberArray[i].Key = empty;
        }


        /* pre:  true
        * post: return the bucket where the key is stored
        *		 if the given key in the hashtable;
        *		 otherwise, return -1.
        */
        public void Insert(UserMember member)
        {
            var key = String.Concat(member.Name[0], member.Name[1]);

            // check the pre-condition
            if (Count < MemberArray.Length)
            {
                int bucket = FindInsertionBucket(key);
                MemberArray[bucket] = new Key_Value_Pair(key, member);
                Count++;
            }
            else
                Console.WriteLine("The hashtable is full"); // doubling size of array is out of scope
        }


        /* pre:  true
         * post: return the bucket where the key is stored
         *		 if the given key in the hashtable;
         *		 otherwise, return -1.
         */
        public int Search(string[] name)
        {
            var key = String.Concat(name[0], name[1]);

            int bucket = Hashing(key);

            int i = 0;
            int offset = 0;
            while ((i < buckets) &&
                (MemberArray[(bucket + offset) % buckets].Key != empty))
            {
                if (MemberArray[(bucket + offset) % buckets].Key == key)
                    return (offset + bucket) % buckets;

                offset = ProbingMethod(offset);
                i++;
            }

            return -1;
        }


        /* pre:  nil
         * post: the given key has been removed from the hashtable if the given key is in the hashtable
        */
        public void Delete(string[] name)
        {
            int bucket = Search(name);
            if (bucket != -1)
            {
                MemberArray[bucket] = new Key_Value_Pair(deleted, null);
                Count--;
            }
        }


        /* pre:  key>=0
         * post: return the bucket (location) for the given key
         */
        private int Hashing(string key)
        {
            // last names are usually unique and when they are not the first name is usually unique
            // all names are assumed to be minimum 2 letters for both the first and last name

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] keyArray = key.ToCharArray();
            int keylength = key.Length;
            int[] keyIndexes = new int[4] { 1, keylength - 3, keylength - 2, keylength - 1 };
            int[] keyValues = new int[4];
            int keyValue = 0;

            for (int i = 0; i < keyValues.Length; i++)
            {
                var value = Char.ToUpper(keyArray[keyIndexes[i]]);

                for (int j = 0; j < alpha.Length; j++)
                {
                    if (value == alpha[j])
                    {
                        keyValues[i] = j;
                        break;
                    }
                }
            }

            for (int i = 0; i < keyValues.Length; i++)
                keyValue += keyValues[i];

            return keyValue * 3 % buckets;
        }


        // linear probing
        private int ProbingMethod(int offset)
        {
            // linear pobing is sufficient due to the natural spread of initial keys.

            return offset + 1;
        }


        /* pre:  nil
	 * post: print all the elements in the hashtable
	*/
        public void Print()
        {
            Console.WriteLine("------------Printed representation of the Member array-----------------\n");

            for (int i = 0; i < buckets; i++)
            {
                if (MemberArray[i].Key == empty)
                    Console.Write(" ____ ");
                else if (MemberArray[i].Key == deleted)
                    Console.Write(" _del_ ");
                else
                {
                    var member = (UserMember)MemberArray[i].Value;
                    Console.Write(" " + member.Name[0] + " " + member.Name[1] + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
