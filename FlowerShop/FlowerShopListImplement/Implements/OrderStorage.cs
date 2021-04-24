﻿using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowerShopListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton source;

        public OrderStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<OrderViewModel> GetFullList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                result.Add(CreateModel(order));
            }
            return result;
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if ((!model.DateFrom.HasValue && !model.DateTo.HasValue && order.DateCreate.Date == model.DateCreate.Date) ||
                  (model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate.Date >= model.DateFrom.Value.Date && order.DateCreate.Date <= model.DateTo.Value.Date))
                {
                    result.Add(CreateModel(order));
                }
            }
            return result;
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Flowers.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id)
                {
                    return CreateModel(order);
                }
            }
            return null;
        }

        private OrderViewModel CreateModel(Order order)
        {
            string FlowerName = "";
            for (int j = 0; j < source.Flowers.Count; ++j)
            {
                if (source.Flowers[j].Id == order.FlowerId)
                {
                    FlowerName = source.Flowers[j].FlowerName;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                FlowerName = FlowerName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };     
        }

        private Order CreateModel(OrderBindingModel model, Order tempOrder)
        {
            tempOrder.FlowerId = model.FlowerId == 0 ? tempOrder.FlowerId : model.FlowerId;
            tempOrder.Count = model.Count;
            tempOrder.Sum = model.Sum;
            tempOrder.Status = model.Status;
            tempOrder.DateCreate = model.DateCreate;
            tempOrder.DateImplement = model.DateImplement;
            return tempOrder;
        }

        public void Insert(OrderBindingModel model)
        {
            Order tempOrder = new Order { Id = 1 };
            foreach (var order in source.Orders)
            {
                if (order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
            }
            source.Orders.Add(CreateModel(model, tempOrder));
        }

        public void Update(OrderBindingModel model)
        {
            Order tempOrder = null;
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id)
                {
                    tempOrder = order;
                }
            }
            if (tempOrder == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempOrder);
        }
    }
}
