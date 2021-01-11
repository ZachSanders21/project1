using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.ConsoleClient
{
    public class SqlClient
    {
        private readonly PizzaBoxContext _db = new PizzaBoxContext();

        public IEnumerable<Store> ReadStores()
        {
            return _db.Stores;
        }
        public IEnumerable<Topping> ReadToppings()
        {
            return _db.Toppings; 
        }
        public IEnumerable<User> ReadUsers()
        {
            return _db.Users;
        }
        public void NewUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
        public User GetUser(string username)
        {
            var u = _db.Users.FirstOrDefault(u =>u.Username == username);
            return u;
        }
        public Topping GetTopping(string name)
        {
            var t = _db.Toppings.FirstOrDefault(t => t.Name == name);
            return t;
        }
        public Store ReadOne(string name)
        {
            var s = _db.Stores.FirstOrDefault(s => s.Name == name);
            return s;
        }
        public Size GetSize(string name)
        {
            var z = _db.Sizes.FirstOrDefault(z => z.Name == name);
            return z;
        }
        public IEnumerable<Order> ReadOrders(Store store)
        {
            var s = ReadOne(store.Name);

            return s.Orders;
        }
        // public IEnumerable<APizzaModel> ListPizzas()
        // {
        //     return _db.Pizzas;
        // }
        public void Update()
        {
            _db.SaveChanges();
        }

        public Store SelectStore()
        {
            string input = Console.ReadLine();
            return ReadOne(input);
        }
        public IEnumerable<Order> StoreOrderHistory(Store store)
        {
            return _db.Orders.Where(s => s.Store == store).Include(s => s.User);
        }
        public IEnumerable<Order> UserOrderHistroy(User user)
        {
            return _db.Orders.Where(s => s.User == user).Include(s => s.Store); 
        }
    }
}