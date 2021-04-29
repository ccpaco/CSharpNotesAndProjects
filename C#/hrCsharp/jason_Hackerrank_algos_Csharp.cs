// C# code, Jason Hillegass

// Fourth from last, byte 
public static int fourthBit(int number)
    {
        List<int> toBinary = new List<int>();
        
        
        while (number > 0)
        {
           int numToList = number % 2;
           number /= 2;
           toBinary.Insert(0, numToList);
        }
        int item = toBinary[toBinary.Count - 4];
        return item;
    }


// Finding the min deletions required to remove Distinct chars, or substrings
public static int getMinDeletions(string s)
    {
        int MinDels = s.Count() - s.Distinct().Count();
        
        return MinDels; 
    }

// Min steps in 

public static int minimumSteps(List<string> loggedMoves)
    {
        int minSteps = 0;   

        foreach(string move in loggedMoves)
        {
            if(move == "./")
            {
                continue;
            }
            else if (move == "../")
            {
                minSteps -= 1;
            }
            else
            {
                minSteps += 1;
            }
        }
        
        return minSteps;
    }

// 

public static int isPrime(long n)
    {
        //long primeNum = 0;
        
        if (n % 2 == 0 && n != 2)
        {
            return 2;
        }
        for(int d = 3; d < n/2; d=d+2)
        {
            long dd = Convert.ToInt64(d);
            if (n % dd == 0)
            {
                return (int)d;
            }
        }
        
        return 1;
    }

// 

public static int minDiff(List<int> arr)
    {
        arr.Sort();
        int TotalDiff = 0;
        for (int i = 0; i < (arr.Count - 1); i++)
        {
            TotalDiff += Math.Abs(arr[i] - arr[i + 1]);
        }
        
        return TotalDiff;
    }

// Calculate points in 3D space

public class Point2D
{
    public double x;
    public double y;
    
    public Point2D(double X, double Y)
    {d
        x = X;
        y = Y;
    }
    
    public double dist2D(Point2D p)
    {
        double result1 = Math.Pow((p.x - x), 2);
        double result2 = Math.Pow((p.y - y), 2);
        double final = Math.Sqrt(result1 + result2);
        return final;
    }
    
    public void printDistance(double d)
    {
        double round = Math.Ceiling(d);
        Console.WriteLine($"2D distance = {round}");
    }
}

public class Point3D : Point2D
{
    public double z;
    
    public Point3D(double X, double Y, double Z) : base(X, Y)
    {
        z = Z;
    }
    
    public double dist3D(Point3D p)
    {
        double result1 = Math.Pow((p.x - x), 2);
        double result2 = Math.Pow((p.y - y), 2);
        double result3 = Math.Pow((p.z - z), 2);
        double final = Math.Sqrt(result1 + result2 + result3);
        return final;
    }
    
    // public void printDistance(double d)
    // {
    //     do
    // 