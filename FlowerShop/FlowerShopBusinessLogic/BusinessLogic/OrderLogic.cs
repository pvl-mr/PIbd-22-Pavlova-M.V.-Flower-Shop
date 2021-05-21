using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.Enums;
using FlowerShopBusinessLogic.HelperModels;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.BusinessLogic
{
    public class OrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IStorePlaceStorage _storePlaceStorage;
        private readonly IFlowerStorage _flowerStorage;
        private readonly IClientStorage _clientStorage;
        private readonly object locker = new object();

        public OrderLogic(IOrderStorage orderStorage, IStorePlaceStorage storePlaceStorage, IFlowerStorage flowerStorage, IClientStorage clientStorage)
        {
            _orderStorage = orderStorage;
            _storePlaceStorage = storePlaceStorage;
            _flowerStorage = flowerStorage;
            _clientStorage = clientStorage;
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                FlowerId = model.FlowerId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = model.ClientId })?.Email,
                Subject = $"Новый заказ",
                Text = $"Заказ от {DateTime.Now} на сумму {model.Sum:N2} принят."
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                OrderStatus status = OrderStatus.Выполняется;
                var order = _orderStorage.GetElement(new OrderBindingModel
                {
                    Id = model.OrderId
                });
                if (order == null)
                {
                    throw new Exception("Заказ не найден");
                }
                if (order.Status != OrderStatus.Принят)
                {
                    throw new Exception("заказ не в статусе \"Принят\"");
                }
                var flower = _flowerStorage.GetElement(new FlowerBindingModel { Id = order.FlowerId });
                if (!_storePlaceStorage.TakeComponents(flower.FlowerComponents, order.Count))
                {
                    status = OrderStatus.Требуются_материалы;
                }
                if (order.ImplementerId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }
                _orderStorage.Update(new OrderBindingModel
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    ImplementerId = model.ImplementerId,
                    FlowerId = order.FlowerId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                    Status = status
                });
                MailLogic.MailSendAsync(new MailSendInfo
                {
                    MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Email,
                    Subject = $"Заказ №{order.Id}",
                    Text = $"Заказ №{order.Id} передан в работу."
                });
            
            }
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (order.Status == OrderStatus.Требуются_материалы)
            {
                order.Status = OrderStatus.Выполняется;
            }
            var flower = _flowerStorage.GetElement(new FlowerBindingModel { Id = order.FlowerId });
            if (!_storePlaceStorage.TakeComponents(flower.FlowerComponents, order.Count))
            {
                return;
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                FlowerId = order.FlowerId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                Status = OrderStatus.Готов
            });
            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Email,
                Subject = $"Заказ №{order.Id}",
                Text = $"Заказ №{order.Id} выполнен."
            });
        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                FlowerId = order.FlowerId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Оплачен
            });
            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = _clientStorage.GetElement(new ClientBindingModel { Id = order.ClientId })?.Email,
                Subject = $"Заказ №{order.Id}",
                Text = $"Заказ №{order.Id} оплачен."
            });
        }
    }
}
