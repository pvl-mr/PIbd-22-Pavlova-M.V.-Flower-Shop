using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.HelperModels;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowerShopBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IFlowerStorage _flowerStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IStorePlaceStorage _storePlaceStorage;
        public ReportLogic(IFlowerStorage flowerStorage, IComponentStorage componentStorage, IOrderStorage orderStorage, IStorePlaceStorage storePlaceStorage)
        {
            _flowerStorage = flowerStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _storePlaceStorage = storePlaceStorage;

        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportFlowerComponentViewModel> GetFlowerComponent()
        {
            var components = _componentStorage.GetFullList();
            var flowers = _flowerStorage.GetFullList();
            var list = new List<ReportFlowerComponentViewModel>();
            foreach (var flower in flowers)
            {
                var record = new ReportFlowerComponentViewModel
                {
                    FlowerName = flower.FlowerName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in components)
                {
                    if (flower.FlowerComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(component.ComponentName, flower.FlowerComponents[component.Id].Item2));
                        record.TotalCount += flower.FlowerComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            var orders = _orderStorage.GetFilteredList(new OrderBindingModel
            { DateFrom = model.DateFrom, DateTo = model.DateTo })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                FlowerName = x.FlowerName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
            Console.WriteLine("2 step");
            foreach (var order in orders)
            {
                Console.WriteLine(order.DateCreate.ToString());
            }
            return orders;
        }

        public List<ReportStorePlaceComponentViewModel> GetStorePlaceComponents()
        {
            var components = _componentStorage.GetFullList();
            var storePlaces = _storePlaceStorage.GetFullList();
            var records = new List<ReportStorePlaceComponentViewModel>();
            foreach (var storePlace in storePlaces)
            {
                var record = new ReportStorePlaceComponentViewModel
                {
                    StorePlaceName = storePlace.StorePlaceName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in components)
                {
                    if (storePlace.StorePlaceComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(
                            component.ComponentName, storePlace.StorePlaceComponents[component.Id].Item2));

                        record.TotalCount += storePlace.StorePlaceComponents[component.Id].Item2;
                    }
                }
                records.Add(record);
            }
            return records;
        }

        public List<ReportTotalOrdersViewModel> GetTotalOrders()
        {
            return _orderStorage.GetFullList()
                .GroupBy(order => order.DateCreate.ToShortDateString())
                .Select(rec => new ReportTotalOrdersViewModel
                {
                    Date = Convert.ToDateTime(rec.Key),
                    Count = rec.Count(),
                    Sum = rec.Sum(order => order.Sum)
                })
                .ToList();
        }

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveFlowersToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Flowers = _flowerStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveFlowerComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Изделия с указанием компонентов",
                FlowerComponents = GetFlowerComponent()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }

        public void SaveStorePlacesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocStorePlace(new WordInfoStorePlace
            {
                FileName = model.FileName,
                Title = "Список складов",
                StorePlaces = _storePlaceStorage.GetFullList()
            });
        }

        public void SaveStorePlaceComponentsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDocStorePlace(new ExcelInfoStorePlace
            {
                FileName = model.FileName,
                Title = "Список складов",
                StorePlaceComponents = GetStorePlaceComponents()
            });
        }

        public void SaveTotalOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocTotalOrders(new PdfInfoTotalOrders
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetTotalOrders()
            });
        }

    }
}
