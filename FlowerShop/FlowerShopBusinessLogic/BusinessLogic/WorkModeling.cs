using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.Enums;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShopBusinessLogic.BusinessLogic
{
    public class WorkModeling
    {
        private readonly IImplementerStorage _implementerStorage;

        private readonly IOrderStorage _orderStorage;

        private readonly OrderLogic _orderLogic;

        private readonly Random rnd;

        public WorkModeling(IImplementerStorage implementerStorage, IOrderStorage orderStorage, OrderLogic orderLogic)
        {
            _implementerStorage = implementerStorage;
            _orderStorage = orderStorage;
            _orderLogic = orderLogic;
            rnd = new Random(1000);
        }

        public void DoWork()
        {
            var implementers = _implementerStorage.GetFullList();
            var orders = _orderStorage.GetFilteredList(new OrderBindingModel { FreeOrders = true });
            foreach (var implementer in implementers)
            {
                WorkerWorkAsync(implementer, orders);
            }
        }

        private async void WorkerWorkAsync(ImplementerViewModel implementer, List<OrderViewModel> orders)
        {
            //Cперва отрабатываются заказы со статусом «Выполняются»

            var runOrders = await Task.Run(() => _orderLogic.Read(new OrderBindingModel
            {
                ImplementerId = implementer.Id
            }));

            foreach (var order in runOrders)
            {
                Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                _orderLogic.FinishOrder(new ChangeStatusBindingModel { OrderId = order.Id });
                Thread.Sleep(implementer.PauseTime);
            }

            //Потом заказы со статусом «Требуются материалы» 

            var ordersWithRequiredMaterials = await Task.Run(() => _orderLogic.Read(null)
            .Where(rec => rec.Status == OrderStatus.Требуются_материалы).ToList());

            foreach (var order in ordersWithRequiredMaterials)
            {
                try
                {
                    _orderLogic.TakeOrderInWork(new ChangeStatusBindingModel
                    {
                        OrderId = order.Id,
                        ImplementerId = implementer.Id
                    });

                    var processedOrder = _orderStorage.GetElement(new OrderBindingModel
                    {
                        Id = order.Id
                    });

                    if (processedOrder.Status == OrderStatus.Требуются_материалы)
                    {
                        continue;
                    }

                    Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                    _orderLogic.FinishOrder(new ChangeStatusBindingModel { OrderId = order.Id });
                    Thread.Sleep(implementer.PauseTime);
                }
                catch (Exception) { }
            }

            // Только потом новые заказы

            await Task.Run(() =>
            {
                foreach (var order in orders)
                {
                    try
                    {
                        _orderLogic.TakeOrderInWork(new ChangeStatusBindingModel
                        {
                            OrderId = order.Id,
                            ImplementerId = implementer.Id
                        });

                        if (order.Status == OrderStatus.Требуются_материалы)
                        {
                            continue;
                        }

                        Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                        _orderLogic.FinishOrder(new ChangeStatusBindingModel
                        {
                            OrderId = order.Id
                        });
                        Thread.Sleep(implementer.PauseTime);
                    }
                    catch (Exception) { }
                }
            });
        }
    }
}