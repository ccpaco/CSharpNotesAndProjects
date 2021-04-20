// trippy logic
// methods run in the conditional, return their values, and then Main()

private static bool True() 
	{
		Console.WriteLine("True");
		return true;
	}

	private static bool False()
	{
		Console.WriteLine("False");
		return false;
	}

    // First we go to Main() 
	public static void Main()
	{
        // Then False() runs, True() runs. Then we get "True" or "False"
		if (False() || True()) Console.Write("True"); else Console.Write("False");
	

// Output from ^ is False True True

private static bool True() 
	{
		Console.WriteLine("True");
		return true;
	}

	private static bool False()
	{
		Console.WriteLine("False");
		return false;
	}

	public static void Main()
	{
		if (False() && True()) Console.Write("True");
	}

// Output ^ is False True

// this one deals with i++ vs ++i 
public static void Main()
	{
		int n = 10;
        // m becomes 10, and then n becomes 9
		int m = n--;
        
        // n becomes 8, then gets printed. 
        // m becomes a string which is printed out. m the variable becomes 11
		Console.WriteLine((--n).ToString() + "," + (m++).ToString());
	}

//  output is 8, 10