using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowerShopDatabaseImplement.Implements
{
    public class FlowerStorage : IFlowerStorage
    {
        public List<FlowerViewModel> GetFullList()
        {
            using (var context = new FlowerShopDatabase())
            {
                return context.Flowers
                .Include(rec => rec.FlowerComponents)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(rec => new FlowerViewModel
                {
                    Id = rec.Id,
                    FlowerName = rec.FlowerName,
                    Price = rec.Price,
                    FlowerComponents = rec.FlowerComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                })
                .ToList();
            }
        }

        public List<FlowerViewModel> GetFilteredList(FlowerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FlowerShopDatabase())
            {
                return context.Flowers
                .Include(rec => rec.FlowerComponents)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.FlowerName.Contains(model.FlowerName))
                .ToList()
                .Select(rec => new FlowerViewModel
                {
                    Id = rec.Id,
                    FlowerName = rec.FlowerName,
                    Price = rec.Price,
                    FlowerComponents = rec.FlowerComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                }).ToList();
            }
        }

        public FlowerViewModel GetElement(FlowerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FlowerShopDatabase())
            {
                var flower = context.Flowers
                .Include(rec => rec.FlowerComponents)
                .ThenInclude(rec => rec.Component)
                .FirstOrDefault(rec => rec.FlowerName == model.FlowerName || rec.Id == model.Id);
                return flower != null ?
                new FlowerViewModel
                {
                    Id = flower.Id,
                    FlowerName = flower.FlowerName,
                    Price = flower.Price,
                    FlowerComponents = flower.FlowerComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                } :
                null;
            }
        }

        public void Insert(FlowerBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Flower flower = new Flower
                        {
                            FlowerName = model.FlowerName,
                            Price = model.Price
                        };
                        context.Flowers.Add(flower);
                        context.SaveChanges();
                        CreateModel(model, flower, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(FlowerBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Flowers.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(FlowerBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                Flower element = context.Flowers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Flowers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Flower CreateModel(FlowerBindingModel model, Flower flower, FlowerShopDatabase context)
        {
            if (model.Id.HasValue)
            {
                var flowerComponents = context.FlowerComponents.Where(rec => rec.FlowerId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.FlowerComponents.RemoveRange(flowerComponents.Where(rec => !model.FlowerComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in flowerComponents)
                {
                    updateComponent.Count = model.FlowerComponents[updateComponent.ComponentId].Item2;
                    model.FlowerComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.FlowerComponents)
            {
                context.FlowerComponents.Add(new FlowerComponent
                {
                    FlowerId = flower.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return flower;
        }

    }
}
