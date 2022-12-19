using System;
using System.Collections.Generic;
using Training.Domain;

public class Program
{
    private static void Main(string[] args)
    {

        //Defining custom function
        static string ReadWrite(string args)
        {
            Console.Write(args);
            return Console.ReadLine();
        }

        //Defining default value for Deals and Activity
        List<Deal> ListOfDeals = new List<Deal>();
        List<Activity> ListOfActivity = new List<Activity>();

        ListOfDeals.Add(new Deal("1", "Opulent Spa Heaven", "In need of a relaxing spa day? We've got you covered! Offering bespoke treatments, using only fresh local ingredients, Spa Alila Seminyak promises an exclusive spa experience that will leave you feeling rejuvenated and relaxed with a renewed sense of well-being.", 50, true, 0));
        ListOfDeals.Add(new Deal("2", "Discounted Dinner and Drinks at Boy’n’Cow", "Looking for something different? Boy’N’Cow is not your average steakhouse... welcome to Bali's first 'meat boutique'!\r\nLocated at the top of Seminyak's famous 'Eat Street', Boy'N'Cow is an industrial dry-aged meat boutique and cocktail lounge that delivers quality produce, from scratch, using only the finest ingredients from across the globe.", 35, true, 2));
        ListOfDeals.Add(new Deal("3", "Day Trip to Nusa Penida", "The largest of the three Nusa Islands, Nusa Penida is renowned for its spectacular viewpoints, turquoise waters and Insta-worthy beaches. You may have seen the likes of Kelingking Beach, Angel Billabong and the iconic Tree House – locally known as Rumah Pohon – on your feed, but now it's time for you to experience them first-hand.", 200, true, 40));

        ListOfActivity.Add(new Activity("1", "Snorkeling to Menjangan Island", "For make better service,handled qualified guide and also legal company.\r\nSnorkeling is famous activity at West Bali National Park. The best snorkeling spot in Bali called Menjangan Island ", 97, true, 10));
        ListOfActivity.Add(new Activity("2", "Ubud Guided Tour & Iconic Tanah Lot Temple", "Ubud is a wonderful village with amazing shopping, art, villas and spas, but get out of the main area and there is a whole other world to discover.", 58, true, 10));
        ListOfActivity.Add(new Activity("3", "Seafood Romatict Dinner In Jimbaran Beach Bali", "Spend the evening dining on grilled seafood while you take in the sunsets of Jimbaran Bay with this romantic dinner package. You sit down to dine at Pandan sari Cafe Jimbaran, where you’ll be offered a set seafood dinner featuring grilled lobster", 51, true, 20));


        //Creating cart
        List<Cart> Carts = new List<Cart>();

        //Creating SalesOrder and dummy data for it
        List<SalesOrder> SalesOrders = new List<SalesOrder>();

        SalesOrders.Add(new SalesOrder
        {
            Id = "1",
            CartOrder = new List<Cart>(){ new Cart(99, ListOfDeals[1]), new Cart(999,ListOfDeals[2]), new Cart(9999, ListOfActivity[1]), new Cart(9998, ListOfActivity[2])},
            Status = "Draft",
            TotalPrice = new List<Product>() { ListOfDeals[1], ListOfDeals[2], ListOfActivity[1], ListOfActivity[2] }.Sum(x => x.Price)
        });


        //Main Program
        int cartId = 1;  
        int dealId = 4;
        int activityId = 4; //var for autoincrement
        int salesOrderId = 3;
        bool loopingOver = true;
        string Choice = "";
        while (loopingOver)
        {
            Console.WriteLine();
            Console.WriteLine("========== Wellcome to Store ==========");
            Console.WriteLine("0. Show Product");
            Console.WriteLine("1. Create Product");
            Console.WriteLine("2. Add Carts");
            Console.WriteLine("3. Remove from Carts");
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
                    if(item.IsActive == true)
                    {
                        Console.WriteLine($"Item ID: {item.Id} \nType: {item.ProductType} \nName: {item.Name} \nDesc: {item.Description} \nPrice: {item.Price} \nAvailable: {item.Quantity}\n");
                    }
                });
                Console.WriteLine();
                Console.WriteLine("List of Activity");
                ListOfActivity.ForEach(item =>
                {
                    if(item.IsActive == true)
                    {
                        Console.WriteLine($"Item ID: {item.Id} \nType:  {item.ProductType}  \nName:  {item.Name} \nDesc: {item.Description} \nPrice: {item.Price} \nAvailable: {item.Quantity}\n");
                    }
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
                    ListOfDeals.Add(new Deal(dealId++.ToString(), ReadWrite("Name of Deals: "), ReadWrite("Desc of Deals: "), int.Parse(ReadWrite("Price of Deals: ")), Quantity: int.Parse(ReadWrite("Availability: ")))); ;
                    Console.WriteLine("Successfully Created");
                }else if(ProductCreateNumber == "2")
                {
                    ListOfActivity.Add(new Activity(activityId++.ToString(), ReadWrite("Name of Activity: "), ReadWrite("Desc of Activity: "), int.Parse(ReadWrite("Price of Activity: ")), Quantity: int.Parse(ReadWrite("Availability: "))));
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
                        if (item.IsActive)
                        {
                            Console.Write($"{item.Id.Split("-")[1]}. {item.Name} ({item.Quantity})\n");
                        }
                    });

                    Console.Write("Select Number Deals You Wanna Add To: ");
                    ProductNumber = Console.ReadLine();

                    var SelectedDeals = ListOfDeals.First(item => item.Id.Split("-")[1] == ProductNumber);
                
                    //Check if available.
                    if(SelectedDeals.Quantity > 0)
                    {
                        Carts.Add(new Cart(cartId++, SelectedDeals));
                        Console.WriteLine($"{SelectedDeals.Name} successfully added");
                    }
                    else
                    {
                        Console.WriteLine($"{SelectedDeals.Name} out of stock. Try again");
                    }
                }
                else if(ProductChoice == "2")
                {
                    string ProductNumber = "";
                    ListOfActivity.ForEach(item =>
                    {
                        if (item.IsActive)
                        {
                            Console.Write($"{item.Id.Split("-")[1]}. {item.Name} ({item.Quantity}) ");
                        }
                    });

                    Console.Write("Select Number Activity You Wanna Add To: ");
                    ProductNumber = Console.ReadLine();

                    var SelectedActivity = ListOfActivity.First(item => item.Id.Split("-")[1] == ProductNumber);

                    //Check if available.
                    if (SelectedActivity.Quantity > 0)
                    {
                        Carts.Add(new Cart(cartId++, SelectedActivity));
                        Console.WriteLine($"{SelectedActivity.Name} successfully added");
                    }
                    else
                    {
                        Console.WriteLine($"{SelectedActivity.Name} out of stock. Try again");
                    }
                }else
                {
                    Console.WriteLine("Wrong Selected Number");
                }

            }
            else if (Choice == "3")
            {

                int number = 1;
                Carts.ForEach(item =>
                {
                    Console.Write($"{number++}. ");
                    Console.WriteLine($"{item.ProductData.Id} | {item.ProductData.Name}");
                });
                Console.Write("Select Number Cart You Wanna Delete: ");
                var CartNumber = Console.ReadLine();

                Carts.RemoveAt(int.Parse(CartNumber)-1);

            }
            else if (Choice == "4")
            {
                Console.WriteLine("Showing Item in Carts\n");
                Carts.ForEach(item =>
                {
                    string AlertOuttaStock = item.ProductData.Quantity <= 0 ? "\nThis Product is Outta Stock" : ""; 
                    Console.WriteLine($"ItemID: {item.Id} \nName: {item.ProductData.Name} \nDesc: {item.ProductData.Description} \nType: {item.ProductData.ProductType} \nPrice {item.ProductData.Price} {AlertOuttaStock}\n");
                });

                if(Carts.Any(item => item.ProductData.Quantity <= 0))
                {
                    Console.WriteLine("Do you want to remove Outta Stock Product from Cart? (Y/N): ");
                    if(Console.Read().ToString() == "Y")
                    {
                        Carts.RemoveAll(item => item.ProductData.Quantity <= 0);
                        Console.WriteLine("Removed Successfully");
                    }
                }
            }else if (Choice == "5")
            {
                SalesOrders.Add(new SalesOrder
                {
                    Id = salesOrderId++.ToString(),
                    CartOrder = Carts,
                    Status = "Draft",
                    TotalPrice = Carts.Sum(x => x.ProductData.Price)
                });
                Carts.Clear();

            }else if (Choice == "6")
            {
                SalesOrders.ForEach(item =>
                {
                    Console.WriteLine($"ItemID: {item.Id} \nStatus: {item.Status} \nTotalPrice: {item.TotalPrice}\n");
                });
                Console.WriteLine();
            }
            else if (Choice == "7")
            {
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
                    if (item.ProductData.ProductType == "Deal")
                    {
                        var getDeals = ListOfDeals.First(x => x.Id == item.Id).Quantity--;
                    }
                    else if (item.ProductData.ProductType == "Activity")
                    {
                        ListOfActivity.First(x => x.Id == item.Id).Quantity--;
                    }
                });
                Console.WriteLine("Paid Successfully");
                Console.WriteLine();
            }
            else if (Choice == "8")
            {
                loopingOver = false;
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