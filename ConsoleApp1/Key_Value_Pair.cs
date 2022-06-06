using System;

public struct Key_Value_Pair
{
	private string key;
	private Object val;

	public Key_Value_Pair(string key, Object val)
	{
		this.key = key;
		this.val = val;
	}

	public string Key
	{
		get { return key; }
		set { key = value; }
	}

	public Object Value
	{
		get { return val; }
		set { val = value; }
	}

}