using FlowerShopBusinessLogic.Enums;
using FlowerShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FlowerShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string FlowerFileName = "Flower.xml";
        private readonly string StorePlaceFileName = "StorePlace.xml";
        public List<Componet> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Flower> Flowers { get; set; }
        public List<StorePlace> StorePlaces { get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Flowers = LoadFlowers();
            StorePlaces = LoadStorePlaces();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveFlowers();
            SaveStorePlaces();
        }

        private List<Componet> LoadComponents()
        {
            var list = new List<Componet>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
               
                foreach (var elem in xElements)
                {
                    list.Add(new Componet
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FlowerId = Convert.ToInt32(elem.Element("FlowerId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                        Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }

        private List<Flower> LoadFlowers()
        {
            var list = new List<Flower>();
            if (File.Exists(FlowerFileName))
            {
                XDocument xDocument = XDocument.Load(FlowerFileName);
                var xElements = xDocument.Root.Elements("Flower").ToList();
                foreach (var elem in xElements)
                {
                    var flowerComp = new Dictionary<int, int>();
                    foreach (var component in elem.Element("FlowerComponents").Elements("FlowerComponent").ToList())
                    {
                        flowerComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Flower
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FlowerName = elem.Element("FlowerName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        FlowerComponents = flowerComp
                    });
                }
            }
            return list;
        }

        private List<StorePlace> LoadStorePlaces()
        {
            var list = new List<StorePlace>();
            if (File.Exists(StorePlaceFileName))
            {
                XDocument xDocument = XDocument.Load(StorePlaceFileName);
                var xElements = xDocument.Root.Elements("StorePlace").ToList();
                foreach (var elem in xElements)
                {
                    var storePlaceComp = new Dictionary<int, int>();
                    foreach (var component in elem.Element("StorePlaceComponents").Elements("StorePlaceComponent").ToList())
                    {
                        storePlaceComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new StorePlace
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        StorePlaceName = elem.Element("StorePlaceName").Value,
                        AdministratorName = elem.Element("AdministratorName").Value,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        StorePlaceComponents = storePlaceComp
                    });
                }
            }
            return list;
        }

        private void SaveStorePlaces()
        {
            if (StorePlaces != null)
            {
                var xElement = new XElement("StorePlaces");
                foreach (var storePlace in StorePlaces)
                {
                    var compElement = new XElement("StorePlaceComponents");
                    foreach (var component in storePlace.StorePlaceComponents)
                    {
                        compElement.Add(new XElement("StorePlaceComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("StorePlace",
                    new XAttribute("Id", storePlace.Id),
                    new XElement("StorePlaceName", storePlace.StorePlaceName),
                    new XElement("AdministratorName", storePlace.AdministratorName),
                    new XElement("DateCreate", storePlace.DateCreate.ToString()),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(StorePlaceFileName);
            }
        }

        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("FlowerId", order.FlowerId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveFlowers()
        {
            if (Flowers != null)
            {
                var xElement = new XElement("Flowers");
                foreach (var flower in Flowers)
                {
                    var compElement = new XElement("FlowerComponents");
                    foreach (var component in flower.FlowerComponents)
                    {
                        compElement.Add(new XElement("FlowerComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Flower",
                    new XAttribute("Id", flower.Id),
                    new XElement("FlowerName", flower.FlowerName),
                    new XElement("Price", flower.Price),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(FlowerFileName);
            }
        }
    }
}
