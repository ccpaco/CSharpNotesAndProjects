// HackerRank Practice Set, Per Scholas. Problems 1-17 
// The code runs in HackerRank but here they are standalone.

// 1. Adding Two Numbers

public static int addNumbers(float a, float b)
    {
        return (int) (a+b);
    }

// 2. Sum Them All
// Run through array and add everything, return one number

public static int arraySum(List<int> numbers)
    {
        int resul = 0;
        foreach (int n in numbers) 
        {
            resul += n;
        }
        return resul;
        
    }

// 3. Jump to the Flag
// A flag is set at x units (whatever feet, miles whatever). How many jumps does it take?
// There are big jumps (passed in through HackerRank) and small jumps (of 1 unit)

public static int jumps(int flagHeight, int bigJump)
    {
        // the trick here is that you find big jumps you make first, 
        int howHigh = flagHeight / bigJump;
        // then use (modulo %) to get the remainder, which is small jumps
        if (flagHeight % bigJump != 0) {
            // add big jumps and small jumps
            return (howHigh + (flagHeight % bigJump));
        }
        return howHigh; 
    }

// 4. Last and Second-Last
// Make a new string with the last and second last letters, in reverse order. (ie apple become el)

public static string lastLetters(string word)
    {
        string myAns = word[word.Length - 1] + " " + word[word.Length - 2];
        return myAns;
    }

// 5. Two's Power
// This one is a RegEx (Regular Expression) problem with one specifc answer. From Google.

static string regularExpression = @"^0*10*$";

// 6.  FizzBuzz 
// A thing where 3 and 5 are important and you print out Fizz, Buzz or FizzBuzz

public static void fizzBuzz(int n)
    {
        for (int x=1; x <= n; x++){
        if (x % 3 == 0 && x % 5 == 0)  
        {  
            Console.WriteLine("FizzBuzz");  
        }  
        else if (x % 3 == 0)  
        {  
           Console.WriteLine("Fizz");  
        }  
        else if (x % 5 == 0)  
        {  
           Console.WriteLine("Buzz");  
        }  
        else  
        {  
            Console.WriteLine(x);  
        }
        }
    }

// 7. 4th Bit
// This one is somewhat complex. You need to convert a number to Binary and get the 4th to last digit
// But it's 

public static int fourthBit(int number)
    {
        
        string myByte = Convert.ToString(number, 2); // to binary string, 2 is the base which is binary
        string nuByte = myByte[myByte.Length - 4].ToString(); // catch the 4th from last character
        Console.Write(myByte); //Not needed
        return Convert.ToInt32(nuByte); //Finally make the string an integer
        
    }

// 8. String Reduction
// Basically get rid of any duplicate letters, count how many things you delete. 2 versions from my mates, Jimmy Style and Jason Style

// - - - Jimmy Style - - -
    // Long algo style, by unique char
    static int max_char = 26; 
    public static int getMinDeletions(string s)
    {
        foreach char unique
        count of oldString.Length - newString
        
        int n = s.Length;
        int dist_count = 0;
        int[] count = new int[max_char];
        for(int i = 0; i < n; i++){
            if(count[s[i] - 'a'] == 0){
                dist_count++;
            }
            count[(s[i] - 'a')]++;
        }
            if(dist_count > max_char){
                return -1;
            }
            return (n-dist_count);
    }

// - - - - Jason Style, simple - - - -
     
    public static int getMinDeletions(string s)
    {
    // for some reason both s.Length or s.Count() works
    // return (int) s.Length - s.Distinct().Count();    
    return (int) s.Count() - s.Distinct().Count();      
    }


// 9. Compliance Crawler Director Reset
// Basically count ../ and ./ 

public static int minimumSteps(List<string> loggedMoves)
    {
        Stack<String> stack =
        new Stack<String>();
        
        for(int i = 0; i < loggedMoves.Count; i++)
        {
            if (loggedMoves[i] == "../" &&
                stack.Count != 0)
            {
                stack.Pop();
            }
            else if (loggedMoves[i] != "./")
            {
                stack.Push(loggedMoves[i]);
            }
        }
        return stack.Count;
    }

// 10. Task Que
// 

public static long minTime(List<int> batchSize, List<int> processingTime, List<int> numTasks)
    {
    long minTime = 0;  
    List<long> minTimeList = new List<long>();

    // numTasks / batchSize + numTasks - (batchSize%numTasks)
    
    for (int i = 0; i < batchSize.Count; i++){
            long xF = numTasks[i] / batchSize[i];
            long yF = numTasks[i]%batchSize[i] != 0 ? 1 : 0;
            minTime = (xF + yF) * processingTime[i];
            //Console.WriteLine(minTime);
            minTimeList.Add(minTime);
        }   
    return minTimeList.Max();
    }

// 11. Double on Match 
// Get array, and create a second array. Any time firstArray[i] = secArray, double secArray. 

public static long doubleSize(List<long> arr, long b)
    {
        arr.Sort();
        foreach(long num in arr){
            if(b == num)
            {
                b *= 2;
            }
        }
        return b;
    }

// 12. Counting closed paths 
// Basically, when you write a number and the stroke closes. So {0, 4, 6, 8, 9}

public static int closedPaths(int number)
    {
        int closePath = 0;
        
        Dictionary<int, int> map = new Dictionary<int, int>
        {
            {0, 1}, {4, 1}, {6, 1}, {9, 1}, {8, 2}
        };
        List<int> result = new List<int>();
        while (number != 0)
        {
            result.Add(number % 10);
            number /= 10;
        }
        foreach(int digit in result)
        {
            if(map.ContainsKey(digit))
            {
                closePath += map[digit];
            }
        }
        return closePath;
    }

// 13. Prime or Not?

public static int isPrime(long n)
    {
        List<int> divi = new List<int>();
        
        if(n == 2)
        {
            return 1;
        }
        for (int i = 1; i <= Math.Sqrt((double)n); i++)
        {
            if (n % i == 0){
                divi.Add(i);
            }
        } 
        divi.Sort();
        int getItem = divi.Count == 2 ? divi[1] : divi[0];
        return getItem;
    }

// 14. Subarray with given sum
// Passed K, we need to count how many subarrays summed = k.

// --- version one, with Rylan 

public static long countNumberOfSubarrays(List<int> arr, int k)
    {
        // HashMap to store number of subarrays
        // starting from index zero having
        // particular value of sum.
        Dictionary<int, int> prevSum = new Dictionary<int, int>();
        long res = 0;
        // Sum of elements so far
        int currsum = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            // Add current element to sum so far.
            currsum += arr[i];

            // If currsum is equal to desired sum,
            // then a new subarray is found. So
            // increase count of subarrays.
            if (currsum == k)
                res++;

            // currsum exceeds given sum by currsum
            // - sum. Find number of subarrays having
            // this sum and exclude those subarrays
            // from currsum by increasing count by
            // same amount.
            if (prevSum.ContainsKey(currsum - k))
                res += prevSum[currsum - k];

            // Add currsum value to count of
            // different values of sum.
            if (!prevSum.ContainsKey(currsum))
                prevSum.Add(currsum, 1);
            else
            {
                int count = prevSum[currsum];
                prevSum[currsum] = count + 1;
            }
        }
        return res;
    }

// - - - Jimmy version, simpler
 public static long countNumberOfSubarrays(List<int> arr, int k)
    {
        int sum = 0;
        long count = 0;
        Dictionary<int, int> dict = new Dictionary<int,int>();
        
        foreach(int n in arr)
        {
            if (dict.ContainsKey(sum)) dict[sum]+=1;
            else dict.Add(sum, 1);
            sum += n;
            var diff = sum -k;
            if(dict.ContainsKey(diff)) count += dict[diff];
        }
        return count;
    }

// 15. Minimum Difference Sum

public static int minDiff(List<int> arr)
    {
        arr.Sort();
        List<int> differ = new List<int>();
        
        for (int i = 1; i < arr.Count; i++)
        {
            differ.Add(arr[i] - arr[i-1]);
        }
        return differ.Sum();
        
    }


// 16. Shape Classes

public class Circle
{
    // Property Radius, Can be used as Constructor. It is in this case.
    // This is an auto implemented property, by the {get; set;}
    private double Radius{ get; set; }
    
    // Object Circle, has to be given radius. Radius passed to Property and getArea
    public Circle(double radius)
    { 
      Radius = radius;
    }
    
    //method of Circle class (and obj I guess... *kicks pebble*)
    public decimal getArea()
    {
      double circArea = 3.14159265 * Radius * Radius;
      return Math.Ceiling((decimal)circArea);
    }
}

// Class name is like a fancy job title, only decoration
public class Rectangle
{
    // More Properties of Rectangle
    private double Width{ get; set; }
    private double Height{ get; set; }
    
    // Object Rectangle 
    public Rectangle(double w, double h)
    { 
    Width = w;
    Height = h;
    }
    
    // method
    public decimal getArea()
    {
    double rectArea = Width * Height;
    return Math.Ceiling((decimal)rectArea);
    }
}

public class Square
{
    private double Width{ get; set; }
    
    public Square(double w)
    { 
      Width = w;
    }
    
    public decimal getArea()
    {
      double rectArea = Width * Width;
      return Math.Ceiling((decimal)rectArea);
    }
}

// 17. C# Computer Inheritance

// abstract is blueprint of a blueprint. Like how there's no Sport called Sport 
    abstract class Computer {
        // Variables, nothing fancy
        public string Type;
        public string Model;
        public string Cpu;
        public bool isTurnedOn = false;
        
        public Computer(){} //Constructor
        
        // CONSTRUCTOR OVERLOAD
        public Computer(string type, string model, string cpu)
        {
            Type = type;
            Model = model;
            Cpu = cpu;    
        }
        
        public string GetComputerType()
        {
            //ref keyword
            return this.Type;
        }
        
        public string GetComputerModel()
        {
            return this.Model;
        }
        
        public string GetComputerCpu()
        {
            return this.Cpu;
        }
        
        public bool GetComputerStatus()
        {
            return this.isTurnedOn;
        }
        // void basically auto-returns whatever the block calculates to
        public void SwitchComputerStatus()
        {
            this.isTurnedOn = !isTurnedOn; 
        }
    }
    // Inherit from Computer
    class PersonalComputer:Computer 
    {
        // Computer object, base() fills in any unused parameters of the Parent Object  
        public PersonalComputer(string model, string cpu):base()
        {
            this.Type = "PersonalComputer";
            this.Model = model;
            this.Cpu = cpu;
        }
        
    }
    
    class Notebook:Computer 
    {
        public Notebook(string model, string cpu):base()
        {
            this.Type = "Notebook";
            this.Model = model;
            this.Cpu = cpu;
        }
        
    }



namespace Solution
{
  

     
    
    abstract class User{
        // declare our member variables
        public string type;
        public string name;
        public int age;
        
        //enum, like a choice set 
        //Comment out because enum is declared in Solutions class
        //public enum Gender { Male, Female, Other }
        public Gender gender {get; set;}
        
        // initialize constructor
        public User(){}
        
        // overloading / filling in 
        public User(string _type, string _name, Gender _gender, int _age) {
            this.type = _type;
            this.gender = _gender;
            this.name = _name;
            this.age = _age;
        }
        
        public string GetUserName(){
            return this.name;
        }
        
        public string GetUserType(){
            return this.type;
        }
        
        public int GetAge(){
            return this.age;
        }
        
        public Gender GetGender(){
            return this.gender;
        }
    }
    // class Admin inherits from User
    class Admin:User
    {
        public Admin(string _name, Gender _gender, int _age ):base()
        {
            this.name = _name;
            this.type = "Admin";
            this.gender = _gender;
            this.age = _age;
        }
    }
    class Moderator:User 
    {
        public Moderator(string _name, Gender _gender, int _age ):base()
        {
            this.name = _name;
            this.type = "Moderator";
            this.gender = _gender;
            this.age = _age;
        }
    }
    class Solution
    {
        static void Main()
        {
            Type baseType = typeof(User);
            if (!baseType.IsAbstract)
                throw new Exception($"{baseType.Name} type should be abstract");
            
            string values = Console.ReadLine();
            string[] valuesArr = values.Split(' ');             
            var type = (Gender)Enum.Parse(typeof(Gender), valuesArr[1]);           
            User admin = new Admin(valuesArr[0], type, int.Parse(valuesArr[2]));
            
            values = Console.ReadLine();
            valuesArr = values.Split(' ');             
            type = (Gender)Enum.Parse(typeof(Gender), valuesArr[1]);           
            User moderator = new Moderator(valuesArr[0], type, int.Parse(valuesArr[2]));
            
            var name = admin.GetUserName();
            Console.WriteLine($"Type of user {name} is {admin.GetUserType()}");
            Console.WriteLine($"Age of user {name} is {admin.GetAge()}");
            Console.WriteLine($"Gender of user {name} is {admin.GetGender()}");
            
            name = moderator.GetUserName();
            Console.WriteLine($"Type of user {name} is {moderator.GetUserType()}");
            Console.WriteLine($"Age of user {name} is {moderator.GetAge()}");
            Console.WriteLine($"Gender of user {name} is {moderator.GetGender()}");       
        }
    }
    
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}


//Classes to calculate 2D distance of 2 points, 3D distance of 3 points.

class Point2D{
    
    public double x;
    public double y;
    
    public Point2D(){}
    
    public Point2D(double _x, double _y){
        x = _x;
        y = _y;
    }
    
    public double dist2D(Point2D p)
    {
        double res1 = Math.Pow((p.x - x), 2);
        double res2 = Math.Pow((p.y - y), 2);
        double final = Math.Sqrt(res1 + res2);
        return final; 
    }
    
    public void printDistance(double d)
    {
        double round = Math.Ceiling(d);
        Console.WriteLine($"2D distance = {round}");
    }
    
    
}

class Point3D : Point2D
{
    public double z;
    
    public Point3D(double _x, double _y, double _z) : base(_x, _y)
    {
        z = _z;
    }
    
    public double dist3D(Point3D p)
    {
        double res1 = Math.Pow((p.x - x), 2);
        double res2 = Math.Pow((p.y - y), 2);
        double res3 = Math.Pow((p.z - z), 2);
        double final = Math.Sqrt(res1 + res2 + res3);
        return final;
    }
    
     public void printDistance(double d)
    {
        double round = Math.Ceiling(d);
        Console.WriteLine($"3D distance = {round}");
    }
    
    
}


// nested list C#, bev

foreach(List<string> product in products)
{
  for(int i = 1; i < product.Count; i++)
    {

    }
}

foreach(List<string> discount in discounts)
{


}

// then i used discount[0], discount[1] and discount[2] to get the data i needed to store in dictionary