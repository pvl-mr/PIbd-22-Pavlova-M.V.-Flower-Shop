using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.Enums;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.BusinessLogic
{
    public class OrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly object locker = new object();
        private readonly IStorePlaceStorage _storePlaceStorage;
        private readonly IFlowerStorage _flowerStorage;
        public OrderLogic(IOrderStorage orderStorage, IStorePlaceStorage storePlaceStorage, IFlowerStorage flowerStorage)
        {
            _orderStorage = orderStorage;
            _storePlaceStorage = storePlaceStorage;
            _flowerStorage = flowerStorage;
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
                ClientId = model.ClientId,
                FlowerId = model.FlowerId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock(locker)
            {
                var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != OrderStatus.Принят && order.Status != OrderStatus.Требуются_материалы)
                {
                    throw new Exception("Заказ не в статусе \"Принят\" или \"Требуются материалы\"");
                }
                if (order.ImplementerId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }
                var updateBindingModel = new OrderBindingModel
                {
                    Id = order.Id,
                    FlowerId = order.FlowerId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    ClientId = order.ClientId
                };

                if (!_storePlaceStorage.TakeComponents(_flowerStorage.GetElement(new FlowerBindingModel { Id = order.FlowerId }).FlowerComponents, order.Count))
                {
                    updateBindingModel.Status = OrderStatus.Требуются_материалы;
                }
                else
                {
                    updateBindingModel.DateImplement = DateTime.Now;
                    updateBindingModel.Status = OrderStatus.Выполняется;
                    updateBindingModel.ImplementerId = model.ImplementerId;
                }

                _orderStorage.Update(updateBindingModel);
            }    
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                FlowerId = order.FlowerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
        }
        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                FlowerId = order.FlowerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
    }
}
