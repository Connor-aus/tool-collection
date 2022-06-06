// File: Hashtable.cs
// A hashtable ADT implementation using quardratic probing 
//  to resolve collisions
// Maolin Tang
// April 2006
//Modified im April 2021

using System;


interface iHashtable
{
	int Count //get the number of elements in the hashtable
	{
		get;
	}

	int Capacity //get and set of the capacity of the hashable
	{
		get;
		set;
	}

	/* pre:  true
	* post: return the bucket where the key is stored
	*		 if the given key in the hashtable;
	*		 otherwise, return -1.
	*/
	int Search(int key); 


	/* pre:  true
	* post: all the elements in the hashtable have been removed
	*/
	void Clear(); 

	/* pre:  true
	* post: the given key has been inserted into the hashtable, if it has not
	*/
	void Insert(int key); //insert the key to the hashtable

	/* pre:  nil
	* post: the given key has been removed from the hashtable if the given key is in the hashtable
	*/
	void Delete(int key); 

	/* pre:  nil
	 * post: print all the elements in the hashtable
	*/
	void Print(); 
}