using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Singletons
{
    public class ClientSingleton
    {
        private const string _path = @"./PizzaWorld.Client/pizzaworld.xml";
        private static ClientSingleton _instance; 
        public static ClientSingleton Instance 
        { 
            get
            {
                if(_instance == null)
                {
                    _instance = new ClientSingleton();
                }

                return _instance;

            } 
        } 

        public List<Store> Stores { get; set; }
        public List<APizzaModel> Pizzas { get; set; }

        private ClientSingleton()
        {
            Read();
        }


        public void MakeStore()
        {
            Stores.Add(new Store());
            Save();
        }


        public Store SelectStore()
        {
            int.TryParse(Console.ReadLine(), out int input); // 0 or selection

            // Stores.FirstOrDefault(s => s == input);  // unique property, customer entered right input
            return Stores.ElementAtOrDefault(input - 1);
            //Stores[input];

        }

        private void Save()
        {
            var file = new StreamWriter(_path);
            var xml = new XmlSerializer(typeof(List<Store>));

            xml.Serialize(file, Stores);
        }

        private void Read()
        {
            if (File.Exists(_path))
            {
                var file = new StreamReader(_path);
                var xml = new XmlSerializer(typeof(List<Store>));

                Stores = xml.Deserialize(file) as List<Store>;
            }
            else
            {
                Stores = new List<Store>();
                return; 
            }


        }

    }
}