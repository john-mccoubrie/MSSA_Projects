
using System.IO;
using System;
using System.Security.Cryptography.X509Certificates;

struct Employee
{
    public string Title { get; set;}
    public float Price { get; set;}

    public Employee(string title, float price)
    {
        Title = title;
        Price = price;
    }
    public override string ToString()
    {
        return $"Name: {Title}, Price: {Price}";
    }
}

struct MealCombo
{
    public string Name { get; }
    public string MainCourse { get; }
    public string Side { get; }

    public MealCombo(string name, string mainCourse, string side)
    {
        Name = name;
        MainCourse = mainCourse;
        Side = side;
    }

    public override string ToString()
    {
        return $"Combo: {Name} {MainCourse} {Side}";
    }
}

class Program
{
 
    //pre defined employees
    Employee Manager = new Employee("Manager", 30f);
    Employee Chef = new Employee("Chef", 12f);
    Employee Server = new Employee("Server", 10f);
    Employee BusBoy = new Employee("Bus Boy", 8f);
    Employee Host = new Employee("Host", 5f);

    static MealCombo[] predefinedCombos =
    {
        new MealCombo("Disgustingly Healthy", "Salad", "Veggies"),
        new MealCombo("Heart attackers delight", "Burger", "Fries")
    };


    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to John's Deli! Please select a combo or create your own: ");
        Console.WriteLine("1 - Disgustingly Healthy (Salad & Veggies)");
        Console.WriteLine("2 - Heart attackers delight (Burger & Fries)");
        Console.WriteLine("3 - Create your own");

        int comboSelection = Convert.ToInt32(Console.ReadLine());

        MealCombo selectedCombo;

        if(comboSelection >= 1 && comboSelection <= 2)
        {
            selectedCombo = predefinedCombos[comboSelection - 1];
        }
        else
        {
            //Create your own combo
            string mainResponse = AskForMainCourse();
            string sideResponse = AskForSide();
            selectedCombo = new MealCombo("Custom Combo", mainResponse, sideResponse);

            foreach (var combo in predefinedCombos)
            {
                if(combo.MainCourse == mainResponse && combo.Side == sideResponse)
                {
                    selectedCombo = combo;
                    break;
                }
            }
        }
        Console.Write($"Your meal is: {selectedCombo}, enjoy!");
        
        static string AskForMainCourse()
        {
            Console.WriteLine("Welcome to John's Deli, type the food item you would like: ");
            Console.WriteLine();
            Console.WriteLine("Salad");
            Console.WriteLine();
            Console.WriteLine("Sandwhich");
            Console.WriteLine();
            Console.WriteLine("Burger");
            Console.WriteLine();
            Console.WriteLine("Burrito");

            string response = Console.ReadLine();

            switch (response)
            {
                case "Salad":
                    Console.WriteLine("You selected a Salad, what side would you like?");
                    return response;
                case "Sandwhich":
                    Console.WriteLine("You selected a Sandwhich, what side would you like?");
                    return response;
                case "Burger":
                    Console.WriteLine("You selected a Burger, what side would you like?");
                    return response;
                case "Burrito":
                    Console.WriteLine("You selected a Burrito, what side would you like?");
                    return response;
                default:
                    Console.WriteLine("Hmm, that's not on the menu. Please try again!");
                    return null;
            }
        }

        static string AskForSide()
        {
            Console.WriteLine();
            Console.WriteLine("Fries");
            Console.WriteLine();
            Console.WriteLine("Drink");
            Console.WriteLine();
            Console.WriteLine("Chips");
            Console.WriteLine();
            Console.WriteLine("Veggies");

            string response = Console.ReadLine();

            switch (response)
            {
                case "Fries":
                    Console.WriteLine("You selected Fries.");
                    return response;
                case "Drink":
                    Console.WriteLine("You selected a Drink.");
                    return response;
                case "Chips":
                    Console.WriteLine("You selected Chips.");
                    return response;
                case "Veggies":
                    Console.WriteLine("You selected Veggies (ew).");
                    return response;
                default:
                    Console.WriteLine("Hmm, that's not on the menu. Please try again!");
                    return null;
            }
        } 
        
    }
}
