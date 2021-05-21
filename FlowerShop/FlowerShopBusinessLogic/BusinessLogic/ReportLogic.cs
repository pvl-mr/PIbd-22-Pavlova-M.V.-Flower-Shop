using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.HelperModels;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FlowerShopBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IFlowerStorage _flowerStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IStorePlaceStorage _storePlaceStorage;
        public ReportLogic(IFlowerStorage flowerStorage, IOrderStorage orderStorage, IStorePlaceStorage storePlaceStorage)
        {
            _flowerStorage = flowerStorage;
            _orderStorage = orderStorage;
            _storePlaceStorage = storePlaceStorage;

        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportFlowerComponentViewModel> GetFlowerComponent()
        {
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
                foreach (var component in flower.FlowerComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;

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
            return orders;
        }

        public List<ReportStorePlaceComponentViewModel> GetStorePlaceComponents()
        {
            var storePlaces = _storePlaceStorage.GetFullList();
            var list = new List<ReportStorePlaceComponentViewModel>();
            foreach (var storePlace in storePlaces)
            {
                var record = new ReportStorePlaceComponentViewModel
                {
                    StorePlaceName = storePlace.StorePlaceName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in storePlace.StorePlaceComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
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
            MethodInfo method = GetType().GetMethod("GetFlowerComponent");

            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Изделия с указанием компонентов",
                FlowerComponents = (List<ReportFlowerComponentViewModel>)method.Invoke(this, null)
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            MethodInfo method = GetType().GetMethod("GetOrders");
            
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = (List<ReportOrdersViewModel>)method.Invoke(this, new object[] { model })
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
            MethodInfo method = GetType().GetMethod("GetStorePlaceComponent");

            SaveToExcel.CreateDocStorePlace(new ExcelInfoStorePlace
            {
                FileName = model.FileName,
                Title = "Список складов",
                StorePlaceComponents = (List<ReportStorePlaceComponentViewModel>)method.Invoke(this, null)
            });
        }

        public void SaveTotalOrdersToPdfFile(ReportBindingModel model)
        {
            MethodInfo method = GetType().GetMethod("GetTotalOrders");

            SaveToPdf.CreateDocTotalOrders(new PdfInfoTotalOrders
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = (List<ReportTotalOrdersViewModel>)method.Invoke(this, null)
            });
        }

    }
}
