using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;

namespace PizzaBox.ConsoleClient
{
    class Program
    {
        private static readonly ClientSingleton _client = ClientSingleton.Instance;
        private static readonly SqlClient _sql = new SqlClient();


        static void Main(string[] args)
        {
            UserStore();
            //UserView();

        }
        static void UserStore()
        {
            Console.WriteLine("Are you a \n1. User\n2. Store");
            bool isvalid = false;
            while (isvalid == false)
            {
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        LogIn();
                        isvalid = true;
                        break;
                    case 2:
                        StoreLogIn();
                        isvalid = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        UserStore();
                        break;
                }
            }
        }
        static void StoreLogIn()
        {
            PrintAllStores();
            var SelectedStore =_sql.SelectStore();
            StoreHistory(SelectedStore);
        }
        static void StoreHistory(Store store)
        {
            Console.WriteLine("Would you like to\n1. View sales\n2. View order history");
            bool isvalid = false;
            while (isvalid == false)
            {
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        ViewSales(store);
                        isvalid = true;
                        break;
                    case 2:
                        StoreOrderHistory(store);
                        isvalid = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        StoreHistory(store);
                        break;
                }

            }
        }
        static void ViewSales(Store store)
        {
            Console.WriteLine("Would you like to view sales from this\n1. Week \n2. Month");
            bool isvalid = false;
            while (isvalid == false)
            {
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        IEnumerable<Order> orderhist = _sql.StoreOrderHistory(store);
                        double totalprice = 0;
                        double totalorder = 0;
                        foreach (Order order in orderhist)
                        {
                            if (order.DateModifier > DateTime.Now.AddDays(-7))
                            {
                                totalprice += order.TotalPrice; 
                                totalorder += 1;
                            }
                        }
                        Console.WriteLine($"Total number of orders this week: {totalorder} \nTotal revenue this week: ${totalprice}");
                        isvalid = true;
                        break;
                    case 2:
                        IEnumerable<Order> orderhistmonth = _sql.StoreOrderHistory(store);
                        double totalpricemonth = 0;
                        double totalordermonth = 0;
                        foreach (Order order in orderhistmonth)
                        {
                            if (order.DateModifier > DateTime.Now.AddMonths(-1))
                            {
                                totalpricemonth += order.TotalPrice;
                                totalordermonth += 1;
                            }
                        }
                        Console.WriteLine($"Total nubmer of orders this month: {totalordermonth} \nTotal revenue this month: ${totalpricemonth}");
                        isvalid = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }
        static void StoreOrderHistory(Store store)
        {
            IEnumerable<Order> orderhist = _sql.StoreOrderHistory(store);
            foreach (Order order in orderhist)
                {
                    Console.WriteLine($"Store: {order.Store.Name}\nUser: {order.User.Username} \nPrice: {order.TotalPrice}\nOrderTime: {order.DateModifier}\n");
                }
        }
        static void LogIn()
        {
            Console.WriteLine("Welcome!  Are you a new customer? (Y/n)");
            var input = Console.ReadLine();
            if (input == "y")
            {
                NewCustomerInfo();
            }
            else if (input == "n")
            {
                ReturningUser();
            }
            else 
            {
                Console.WriteLine("Invalid Input. Please Try again");
                LogIn(); // user while loops?
            }
        }
        static void NewCustomerInfo()
        {
            Console.WriteLine("Please Create a User");
            var input = Console.ReadLine().ToLower();
            User user = new User(input);
            _sql.NewUser(user);
            UserView(user);
        }
        static void ReturningUser()
        {
            Console.WriteLine("Please Log In");
            var input = Console.ReadLine().ToLower();
            User user = _sql.GetUser(input);
            if (user != null)
            {
                Console.WriteLine("Welcome back!");
                OrderOrHistory(user);
            }
            else
            {
                Console.WriteLine("Invalid User. Please Try again");
                ReturningUser();
            }
        }
        static void OrderOrHistory(User user)
        {
            Console.WriteLine("Would you like to\n1. Order\n2. View order history");
            bool isvalid = false;
            while (isvalid == false)
            {
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        UserView(user);
                        isvalid = true;
                        break;
                    case 2:
                        IEnumerable<Order> orderhist = _sql.UserOrderHistroy(user);
                        foreach (Order order in orderhist)
                        {
                            Console.WriteLine($"Store: {order.Store.Name}\nUser: {order.User.Username} \nPrice: ${order.TotalPrice}\n");
                        }
                        isvalid = true;
                        break;
                    default:
                        Console.WriteLine("Input invalid. Please try again.");
                        OrderOrHistory(user);
                        break;
                }
            }
        }
        static void PrintAllStores()
        {
            Console.WriteLine("Select Store:");
            foreach(var store in _sql.ReadStores())
            {
                Console.WriteLine(store);
            }
        }
        static void SelectPizza(User user)
        {
            Console.WriteLine("Please select your pizza \n1. Hawaian Pizza \n2. Meat Lovers Pizza \n3. Supreme Pizza \n4. Veggie Pizza");
            bool isvalidated = false;
            Size size; 
            string crust; 
            while (isvalidated == false)
            {
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        size = GetSize();
                        crust = GetCrust();
                        user.Orders.Last().MakeHawaianPizza(size, crust);
                        isvalidated = true;
                        break;
                    case 2:
                        size = GetSize();
                        crust = GetCrust();
                        user.Orders.Last().MakeMeatPizza(size, crust);
                        isvalidated = true;
                        break;
                    case 3:
                        size = GetSize();
                        crust = GetCrust();
                        user.Orders.Last().MakeSupremePizza(size, crust);
                        isvalidated = true;
                        break;
                    case 4:
                        size = GetSize();
                        crust = GetCrust();
                        user.Orders.Last().MakeVeggiePizza(size, crust);
                        isvalidated = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection.  Please try again.");
                        break;
                }
            }
            MultiplePizzas(user);
        }
        static void MultiplePizzas(User user)
        {
            Console.WriteLine("Would You like to: \n1. Buy more pizza \n2. Checkout \n3. Restart order");
            bool isvalid = false;
            while (isvalid == false)
            {
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        {
                            SelectPizza(user);
                            isvalid = true;
                            break;
                        }
                    case 2:
                        {
                            Checkout(user);
                            isvalid = true;
                            break;
                        }
                    case 3:
                        {
                            user.SelectedStore.DeleteOrder(user.SelectedStore.Orders.Last());
                            user.SelectedStore.CreateOrder();
                            user.Orders.Add(user.SelectedStore.Orders.Last());
                            SelectPizza(user);
                            isvalid = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid seelction. Please try again.");
                            break;
                        }
                }
            }
        }
        static void Checkout(User user)
        {
            Console.WriteLine($"This is your order: \n{user}\nWould you like to complete checkout? (Y/n)");
            var input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                var test = user.Orders.Last().Pizzas;
                double totalprice = 0;
                foreach (APizzaModel Pizza in test)
                {
                    totalprice += Pizza.Size.Price;
                    foreach (Topping topping in Pizza.Toppings)
                    {
                        totalprice += topping.Price;
                    }
                }
                user.Orders.Last().TotalPrice = totalprice;
                Console.WriteLine($"This is your price: ${totalprice}");
            }
            else if (input == "n")
            {
                user.SelectedStore.DeleteOrder(user.SelectedStore.Orders.Last());
                user.SelectedStore.CreateOrder();
                user.Orders.Add(user.SelectedStore.Orders.Last());
                SelectPizza(user);
            }
            else 
            {
                Console.WriteLine("Invalid selection. Please try again");
                Checkout(user);
            }
        }
        static Size GetSize()
        {
            Console.WriteLine("Select Size \n1. Small \n2. Medium \n3. Large");
            while (true)
            {
                int.TryParse(Console.ReadLine(), out int size);
                switch (size)
                {
                    case 1:
                        return new Size("Small");
                    case 2:
                        return new Size("Medium");
                    case 3:
                        return new Size("Large");
                    default:
                        Console.WriteLine("Invalid selection.  Please try again.");
                        break;
                }
            }
        }
        
        static string GetCrust()
        {
            Console.WriteLine("Select Crust \n1. Garlic \n2. Sesame \n3. Butter \n4. Plain");
            while (true)
            {
                int.TryParse(Console.ReadLine(), out int size);
                switch (size)
                {
                    case 1:
                        return "Garlic";
                    case 2:
                        return "Sesame";
                    case 3:
                        return "Butter";
                    case 4:
                        return "Plain";  
                    default:
                        Console.WriteLine("Invalid selection.  Please try again.");
                        break;
                }
            }


        }
        static void NewOrder(User user)
        {
            Console.WriteLine("Would you like to make another order? (Y/n)");
            var input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                UserView(user);
            }
            else if (input == "n")
            {
                Console.WriteLine("Have a nice day!");
            }
            else 
            {
                Console.WriteLine("Invalid selection. Please try again");
                NewOrder(user);
            }
        }
        

        static void UserView(User user)
        {
            PrintAllStores();

            user.SelectedStore =_sql.SelectStore();
            user.SelectedStore.CreateOrder();
            user.Orders.Add(user.SelectedStore.Orders.Last());
            SelectPizza(user);


            _sql.Update();
            
            System.Console.WriteLine("Order Successful!");
            NewOrder(user);
        }
    }
}
