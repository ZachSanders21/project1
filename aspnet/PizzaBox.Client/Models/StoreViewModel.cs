using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public class StoreViewModel
    {
        public List<string> temps { get; set; }
        
        public StoreViewModel()
        {
            temps = new List<string>()
            {
                "One",
                "Two",
                "Three",
                "Four"
            };
        }
    }
}