using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
    public class PizzaBoxRepository
    {
        private PizzaBoxContext _ctx;
        public User user { get; set; }
        public Store store { get; set; }
        public Order order { get; set; }
        

        public PizzaBoxRepository(PizzaBoxContext context)
        {
            _ctx = context;
        }

        public List<string> GetStores()
        {
            return _ctx.Stores.Select(s => s.Name).ToList();
        }
        public IEnumerable<Store> ReadStores()
        {
            return _ctx.Stores;
        }
        // public IEnumerable<T> Get<T>() where T : AEntity
        // {
        //     return _ctx.Set<T>.Select(t => t.GetType().GetProperty()).ToList();
        // }
        public List<string> GetCustomers()
        {
            return _ctx.Users.Select(s => s.Username).ToList();
        }
        public void NewUser(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }
        public User GetUser(string username)
        {
            var u = _ctx.Users.FirstOrDefault(u =>u.Username == username);
            return u;
        }
        public Store ReadStore(string name)
        {
            var s = _ctx.Stores.FirstOrDefault(s => s.Name == name);
            return s;
        }
        public string ReadStoreName(string name)
        {
            var s = _ctx.Stores.FirstOrDefault(s => s.Name == name);
            return s.Name;
        }
        public IEnumerable<Order> UserOrderHistroy(User user)
        {
            return _ctx.Orders.Where(s => s.User == user).Include(s => s.Store); 
        }
    }
}