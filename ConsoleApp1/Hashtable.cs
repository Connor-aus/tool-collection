// File: Hashtable.cs
// A hashtable ADT implementation using quardratic probing 
//  to resolve collisions
// Maolin Tang
// April 2006
//Modified im April 2021

using System;

public class Hashtable : iHashtable
{

    private int count; //the number of key-and-value pairs currently stored in the hashtable
    private int buckets; //number of buckets
    private int[] table; //a table storing key-and-value pairs
    private const int empty = -10000; //an empty bucket
    private const int deleted = -9999;  //a bucket where a key-and-value pair was deleted

    // constructor
    public Hashtable(int buckets)
    {
        if (buckets > 0)
            this.buckets = buckets;
        count = 0;
        table = new int[buckets];
        for (int i = 0; i < buckets; i++)
            table[i] = empty;
    }

    public int Count
    {
        get { return count; }
    }

    public int Capacity
    {
        get { return buckets; }
        set { buckets = Capacity; }
    }

    /* pre:  the hashtable is not full
	 * post: return the bucket for inserting the key
	 */
    private int FindInsertionBucket(int key)
    {
        int bucket = Hashing(key);
        int i = 0;
        int offset = 0;
        while ((i < buckets) &&
            (table[(bucket + offset) % buckets] != empty) &&
            (table[(bucket + offset) % buckets] != deleted))
        //++offset; //linear probing
        {
            i++;
            offset = i * i;
        }
        return (offset + bucket) % buckets;
    }

    /* pre:  true
	* post: all the elements in the hashtable have been removed
	*/
    public void Clear()
    {
        count = 0;
        for (int i = 0; i < buckets; i++)
            table[i] = empty;
    }

    /* pre:  true
	* post: return the bucket where the key is stored
	*		 if the given key in the hashtable;
	*		 otherwise, return -1.
	*/
    public void Insert(int key)
    {
        // check the pre-condition
        if ((Count < table.Length) && (Search(key) == -1))
        {
            int bucket = FindInsertionBucket(key);
            table[bucket] = key;
            count++;
        }
        else
            Console.WriteLine("The key has already been in the hashtable or the hashtable is full");
    }

    /* pre:  true
	 * post: return the bucket where the key is stored
	 *		 if the given key in the hashtable;
	 *		 otherwise, return -1.
	 */
    public int Search(int key)
    {
        int bucket = Hashing(key);

        int i = 0;
        int offset = 0;
        while ((i < buckets) &&
            (table[(bucket + offset) % buckets] != key) &&
            (table[(bucket + offset) % buckets] != empty))
        //offset++;// linear probing
        {

            i++;
            offset = i * i; //qudratic probing
        }
        if (table[(bucket + offset) % buckets] == key)
            return (offset + bucket) % buckets;
        else
            return -1;
    }

    /* pre:  nil
	 * post: the given key has been removed from the hashtable if the given key is in the hashtable
	*/
    public void Delete(int key)
    {
        int bucket = Search(key);
        if (bucket != 1)
        {
            table[bucket] = deleted;
            count--;
        }
        else
            Console.WriteLine("The given key is not in the hashtable");
    }


    /* pre:  key>=0
	 * post: return the bucket (location) for the given key
	 */
    private int Hashing(int key)
    {
        return (key % buckets);
    }


    /* pre:  nil
	 * post: print all the elements in the hashtable
	*/

    public void Print()
    {
        for (int i = 0; i < buckets; i++)
        {
            if ((table[i] == empty) || (table[i] == deleted))
                Console.Write(" __ ");
            else
                Console.Write(" " + table[i].ToString() + " ");
        }
        Console.WriteLine();
        Console.WriteLine();

    }
}
