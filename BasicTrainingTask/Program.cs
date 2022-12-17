using System;
using System.Collections.Generic;
using Training.Domain;

public class Program
{
    private static void Main(string[] args)
    {
        //Defining default value for Deals and Activity
        List<Deal> ListOfDeals = new List<Deal>();
        List<Activity> ListOfActivity = new List<Activity>();

        ListOfDeals.Add(new Deal("1", "Bali Snorkling", "Vacation in Bali with Snorkling", 2000, true ,20));
        ListOfDeals.Add(new Deal("2", "Australia", "Vacation in Aussie", 1000, true, 30));
        ListOfDeals.Add(new Deal("3", "Sunset in Nusa Penida", "Why must Lost in Work? When you could enjoy your vacation", 5000, true, 40));

        ListOfActivity.Add(new Activity("1", "Bali Snorkling", "Vacation in Bali with Snorkling", 2000), true, 10);
        ListOfActivity.Add(new Activity("2", "Australia", "Vacation in Aussie", 1000, true, 20));
        ListOfActivity.Add(new Activity("3", "Sunset in Nusa Penida", "Why must Lost in Work? When you could enjoy your vacation", 5000, true, 20));


        //Creating cart
        List<Product> Cart = new List<Product>();

        //Creating SalesOrder
        List<SalesOrder> SalesOrders = new List<SalesOrder>();

        SalesOrders.Add(new SalesOrder
        {
            Id = "1",
            CartOrder = new List<Product>(){ ListOfDeals[1], ListOfDeals[2], ListOfActivity[1], ListOfActivity[2] },
            Status = "Draft",
            TotalPrice = 20000
        });

        static string ReadWrite(string args)
        {
            Console.Write(args);
            return (Console.ReadLine());
        }
        int salesOrderId = 3;
        bool loopingOver = true;
        string Choice = "";
        while (loopingOver)
        {
            Console.WriteLine();
            Console.WriteLine("Wellcome to Store");
            Console.WriteLine("0. Show Product");
            Console.WriteLine("1. Create Product");
            Console.WriteLine("2. Add Cart");
            Console.WriteLine("3. Remove from Cart");
            Console.WriteLine("4. Show Carts");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. Show Sales Order Document");
            Console.WriteLine("7. Select One To Pay");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Your Choice: ");
            Choice = Console.ReadLine();
            Console.WriteLine();

            if (Choice == "0")
            {
                Console.WriteLine("List of Deals");
                ListOfDeals.ForEach(item =>
                {
                    Console.WriteLine($"{item.Id} | {item.ProductType} | {item.Name} | {item.Description} | {item.Price} | {item.Quantity} | {item.IsActive} ");
                });
                Console.WriteLine("List of Activity");
                ListOfActivity.ForEach(item =>
                {
                    Console.WriteLine($"{item.Id} | {item.ProductType}  | {item.Name} | {item.Description} | {item.Price} | {item.Quantity} | {item.IsActive} ");
                });
            }
            else if (Choice == "1") {
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
                    Console.WriteLine($"{item.Id} | {item.Name} | {item.Description} | {item.ProductType} | {item.Price}");
                });
            }else if (Choice == "5")
            {
                SalesOrders.Add(new SalesOrder
                {
                    Id = salesOrderId++.ToString(),
                    CartOrder = Cart,
                    Status = "Draft",
                    TotalPrice = Cart.Sum(x => x.Price)
                });
                Cart.Clear();

            }else if (Choice == "6")
            {
                Console.WriteLine();
                SalesOrders.ForEach(item =>
                {
                    Console.WriteLine($"{item.Id} | {item.Status} | {item.TotalPrice}");
                });
            }else if (Choice == "7")
            {
                Console.WriteLine();
                SalesOrders.ForEach(item =>
                {
                    Console.WriteLine($"{item.Id} | {item.Status} | {item.TotalPrice}");
                });
                Console.Write("Select Number Id You Want To Pay: ");
                var SalesOrderNumber = Console.ReadLine();

                var SelectedSalesOrder = SalesOrders.First(item => item.Id.Split("-")[1] == SalesOrderNumber);
                SelectedSalesOrder.Status = "Done";
                SelectedSalesOrder.CartOrder.ForEach(item =>
                {
                    if (item.ProductType == "Deal")
                    {
                        var getDeals = ListOfDeals.First(x => x.Id == item.Id).Quantity--;
                    }
                    else if (item.ProductType == "Activity")
                    {
                        ListOfActivity.First(x => x.Id == item.Id).Quantity--;
                    }
                });
                Console.WriteLine("Paid Successfully");
            }
            else if (Choice == "8")
            {
                return;
            }
            else
            {
                Console.WriteLine("Wrong Selected Number");
            }



        }


        Console.WriteLine("Hello, World!");
    }
}