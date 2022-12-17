using System;
using Training.Domain;

public class Program
{
    private static void Main(string[] args)
    {
        //Defining default value for Deals and Activity
        List<Deal> ListOfDeals = new List<Deal>();
        List<Activity> ListOfActivity = new List<Activity>();

        ListOfDeals.Add(new Deal("1", "Bali Snorkling", "Vacation in Bali with Snorkling", 2000));
        ListOfDeals.Add(new Deal("2", "Australia", "Vacation in Aussie", 1000));
        ListOfDeals.Add(new Deal("3", "Sunset in Nusa Penida", "Why must Lost in Work? When you could enjoy your vacation", 5000));

        ListOfActivity.Add(new Activity("1", "Bali Snorkling", "Vacation in Bali with Snorkling", 2000));
        ListOfActivity.Add(new Activity("2", "Australia", "Vacation in Aussie", 1000));
        ListOfActivity.Add(new Activity("3", "Sunset in Nusa Penida", "Why must Lost in Work? When you could enjoy your vacation", 5000));


        //Creating cart
        List<Product> Cart = new List<Product>();

        static string ReadWrite(string args)
        {
            Console.Write(args);
            return (Console.ReadLine());
        }

        bool loopingOver = true;
        string Choice = "";
        while (loopingOver)
        {
            Console.WriteLine();
            Console.WriteLine("Wellcome to Store");
            Console.WriteLine("1. Create Product");
            Console.WriteLine("2. Add Cart");
            Console.WriteLine("3. Remove from Cart");
            Console.WriteLine("4. Show Carts");
            Console.WriteLine("5. Exit");
            Console.Write("Enter Your Choice: ");
            Choice = Console.ReadLine();
            Console.WriteLine();

            if (Choice == "1") {
                Console.WriteLine("Which Product You Wanna Create?");
                Console.WriteLine("1. Deals");
                Console.WriteLine("2. Activity");
                Console.Write("Enter Your Choice: ");
                var ProductCreateNumber = Console.ReadLine();
                Console.WriteLine();
                if(ProductCreateNumber == "1")
                {
                    ListOfDeals.Add(new Deal(ReadWrite("Id of Deals: "), ReadWrite("Name of Deals: "), ReadWrite("Desc of Deals: "), int.Parse(ReadWrite("Price of Deals: "))));
                    Console.WriteLine("Successfully Created");
                }else if(ProductCreateNumber == "2")
                {
                    ListOfActivity.Add(new Activity(ReadWrite("Id of Activity: "), ReadWrite("Name of Activity: "), ReadWrite("Desc of Activity: "), int.Parse(ReadWrite("Price of Activity: "))));
                    Console.WriteLine("Successfully Created");
                }
                else
                {
                    Console.WriteLine("Wrong Selected Number");
                }
            }
            else if (Choice == "2")
            {
                string ProductChoice = "";
                Console.WriteLine("Which Product You Wanna Add?");
                Console.WriteLine("1. Deals");
                Console.WriteLine("2. Activity");
                Console.Write("Enter Your Choice: ");
                ProductChoice = Console.ReadLine();
                Console.WriteLine();

                if (ProductChoice == "1")
                {
                    string ProductNumber = "";
                    ListOfDeals.ForEach(item =>
                    {
                        Console.Write($"{item.Id.Split("-")[1]}. ");
                        Console.WriteLine(item.Name);
                    });

                    Console.Write("Select Number Deals You Wanna Add To: ");
                    ProductNumber = Console.ReadLine();

                    var SelectedDeals = ListOfDeals.First(item => item.Id.Split("-")[1] == ProductNumber);
                    Cart.Add(SelectedDeals);
                    Console.WriteLine($"{SelectedDeals.Name} successfully added");

                }
                else if(ProductChoice == "2")
                {
                    string ProductNumber = "";
                    ListOfActivity.ForEach(item =>
                    {
                        Console.Write($"{item.Id.Split("-")[1]}. ");
                        Console.WriteLine(item.Name);
                    });

                    Console.Write("Select Number Activity You Wanna Add To: ");
                    ProductNumber = Console.ReadLine();

                    var SelectedActivity = ListOfActivity.First(item => item.Id.Split("-")[1] == ProductNumber);
                    Cart.Add(SelectedActivity);
                    Console.WriteLine($"{SelectedActivity.Name} successfully added");
                }else
                {
                    Console.WriteLine("Wrong Selected Number");
                }

            }
            else if (Choice == "3")
            {

                int number = 1;
                Cart.ForEach(item =>
                {
                    Console.Write($"{number++}. ");
                    Console.WriteLine($"{item.Id} | {item.Name}");
                });
                Console.Write("Select Number Cart You Wanna Delete: ");
                var CartNumber = Console.ReadLine();

                Cart.RemoveAt(int.Parse(CartNumber)-1);

            }
            else if (Choice == "4")
            {
                Cart.ForEach(item =>
                {
                    Console.WriteLine($"{item.Id} | {item.Name}");
                });
            }
            else if (Choice == "5")
            {
                return;
            }
            else
            {
                Console.WriteLine("Wrong Selected Number");
            }


        }


        //var baliHoliday = new Deal
        //{
        //    Id = "1",
        //    Name= "Bali",
        //    Description="How is your holiday ? Stuck on the mind. Get your vacation to Bali with more beautiful and refreshing activities",
        //    Price= 2000,
        //    isActive= true,
        //};



        var baliHolidays = new Deal("1", "Bali", "How is your holiday ? Stuck on the mind.Get your vacation to Bali with more beautiful and refreshing activities", 2000);
        Console.WriteLine(baliHolidays.Id);


        //var aussieHoliday = new Deal
        //{
        //    Id = "2",
        //    Name= "Australia",
        //    Description="With Australia, you can see more than you get. Life would be more easier, the get more dramatic of this",
        //    Price=3000,
        //    isActive= true,
        //};

        //var singapuraHoliday = new Activity
        //{
        //    Id = "3",
        //    Name = "Singapura",
        //    Description = "Visit Singapore, with more of more clean, but high price. But, if you order in this, you could get more",
        //    Price = 10000,
        //    isActive = true,
        //};

        //var baliSurfingHoliday = new Surfing
        //{
        //    Id = "4",
        //    Name = "Bali Surfing",
        //    Description = "Bali Surfing Holiday",
        //    Price = 7000,
        //    isActive = true,
        //    beachName = "Kuta",
        //    surfingTime = 2
        //};

        //Activity surfingDo = baliSurfingHoliday;
        //Console.WriteLine( surfingDo.Name);
        //Surfing surfingDon = (Surfing) surfingDo;
        //Console.WriteLine( surfingDon.beachName);

 

        //List<Product> dealList = new List<Product>();
        //dealList.Add(aussieHoliday);
        //dealList.Add(baliHoliday);
        //dealList.Add(singapuraHoliday);
        //dealList.Add(baliSurfingHoliday);


        //dealList.ForEach(a =>
        //{
        //    Console.WriteLine(a.Name);
        //});

        Console.WriteLine("Hello, World!");
    }
}