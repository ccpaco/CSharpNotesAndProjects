// Output is "int constructor" first, then "double constructor", then "default constructor"
// collapsed use cmd+option+[ or ] 
public class TestClass
	{   
        // Constructors are methods
        // But they are not special "properties" of a class

        //The code  : this(1)  is special, like  : base() in a constructor
        //The constructor public TestClass() says: look for a double constructor within our class
		public TestClass(): this(1.0)
		{
			Console.Write("default constructor ");
		}

        //This constructor says: look for an int constructor within our class. 
		private TestClass(double value): this(1)
		{
			Console.Write("double constructor ");
		}

		private TestClass(int i)
		{
			Console.Write("int constructor ");
		}

public class Program
{
    // Main method for console
    public static void Main()
    {
        //new TestClass obj tc
        TestClass tc = new TestClass();
    }
}
///////////
// HR 16. Shape Classes

public class Circle
{
    // Property Radius, Can be used as Constructor. It is in this case.
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

///////////
// HR 17. C# Computer Inheritance

// abstract is blueprint of a blueprint. Like how there's no Sport called Sport 
// collapsed use cmd+option+[ or ] 
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
    class PersonalComputer:Computer // collapsed use cmd+option+[ or ] 
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

//ENUMS ENUMS ENUMS 

//Enums lesson from YouTube video Dani Krossing

struct Person {
    public string name;
    public string eyeColor;
    public int age;
}

public enum ProductCodes
{
    Milk = 0,
    Juice = 1,
    Tea = 2 
}

class Program
{
    static void Main(string[] args)
    { 
        // assign new var 'test' to enum ProductCodes.Milk 
        ProductCodes test = ProductCodes.Milk;
        Console.WriteLine(test); // outputs milk
        Console.WriteLine((int)test); // outputs 0

        int test2 = 1;
        Console.WriteLine((ProductCodes)test2); // outputes Juice

        string test3 = "Tea";
        ProductCodes getParse;
        bool checkParse = Enum.TryParse(test3, out getParse); // attempt to convert to Enum, 
        Console.WriteLine(getParse); // outputs 'Tea'
        Console.WriteLine(checkParse); // outputs True

    }
}

// Get Set Enums from Stack Overflow

// Try not to use nested types unless there's a clear benefit.
public enum Difficulty { Easy, Normal, Hard }

public class Foo
{
    // Declares a property of *type* Difficulty, and with a *name* of Difficulty
    public Difficulty Difficulty { get; set; }
}

public enum Difficulty { Easy, Normal, Hard }

public class Foo
{
    private Difficulty difficulty;

    public void SetDifficulty(Difficulty value)
    {
        difficulty = value;
    }

    public Difficulty GetDifficulty()
    {
        return difficulty;
    }
}

//Hackkerrank 18, class inheritance with enums and such
//special case, with enums being defined in the Solutions class
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

