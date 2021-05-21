using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopListImplement.Models
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Flower> Flowers { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> Messages { get; set; }
        public List<StorePlace> StorePlaces { get; set; }
      
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Flowers = new List<Flower>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            Messages = new List<MessageInfo>();
            StorePlaces = new List<StorePlace>();
        }
      
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}