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
    public class StorePlaceStorage : IStorePlaceStorage
    {
        public List<StorePlaceViewModel> GetFullList()
        {
            using (var context = new FlowerShopDatabase())
            {
                return context.StorePlaces
                    .Include(rec => rec.StorePlaceComponents)
                    .ThenInclude(rec => rec.Component)
                    .ToList()
                    .Select(rec => new StorePlaceViewModel
                    {
                        Id = rec.Id,
                        StorePlaceName = rec.StorePlaceName,
                        AdministratorName = rec.AdministratorName,
                        DateCreate = rec.DateCreate,
                        StorePlaceComponents = rec.StorePlaceComponents
                            .ToDictionary(recSPC => recSPC.ComponentId,
                            recSPC => (recSPC.Component?.ComponentName,
                            recSPC.Count))
                    })
                    .ToList();
            }
        }

        public List<StorePlaceViewModel> GetFilteredList(StorePlaceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new FlowerShopDatabase())
            {
                return context.StorePlaces
                    .Include(rec => rec.StorePlaceComponents)
                    .ThenInclude(rec => rec.Component)
                    .Where(rec => rec.StorePlaceName.Contains(model.StorePlaceName))
                    .ToList()
                    .Select(rec => new StorePlaceViewModel
                    {
                        Id = rec.Id,
                        StorePlaceName = rec.StorePlaceName,
                        AdministratorName = rec.AdministratorName,
                        DateCreate = rec.DateCreate,
                        StorePlaceComponents = rec.StorePlaceComponents
                            .ToDictionary(recSPC => recSPC.ComponentId,
                            recSPC => (recSPC.Component?.ComponentName,
                            recSPC.Count))
                    })
                    .ToList();
            }
        }

        public StorePlaceViewModel GetElement(StorePlaceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new FlowerShopDatabase())
            {
                StorePlace StorePlace = context.StorePlaces
                    .Include(rec => rec.StorePlaceComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.StorePlaceName == model.StorePlaceName ||
                    rec.Id == model.Id);

                return StorePlace != null ?
                    new StorePlaceViewModel
                    {
                        Id = StorePlace.Id,
                        StorePlaceName = StorePlace.StorePlaceName,
                        AdministratorName = StorePlace.AdministratorName,
                        DateCreate = StorePlace.DateCreate,
                        StorePlaceComponents = StorePlace.StorePlaceComponents
                            .ToDictionary(recSPC => recSPC.ComponentId,
                            recSPC => (recSPC.Component?.ComponentName,
                            recSPC.Count))
                    } :
                    null;
            }
        }

        public void Insert(StorePlaceBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new StorePlace(), context);
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

        public void Update(StorePlaceBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        StorePlace storePlace = context.StorePlaces.FirstOrDefault(rec => rec.Id == model.Id);

                        if (storePlace == null)
                        {
                            throw new Exception("Склад не найден");
                        }

                        CreateModel(model, storePlace, context);
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

        public void Delete(StorePlaceBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                StorePlace storePlace = context.StorePlaces.FirstOrDefault(rec => rec.Id == model.Id);

                if (storePlace == null)
                {
                    throw new Exception("Склад не найден");
                }
                context.StorePlaces.Remove(storePlace);
                context.SaveChanges();
            }
        }

        public bool TakeComponents(Dictionary<int, (string, int)> components, int flowerCount)
        {
            using (var context = new FlowerShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (KeyValuePair<int, (string, int)> storePlaceComponent in components)
                        {
                            int count = storePlaceComponent.Value.Item2 * flowerCount;
                            IEnumerable<StorePlaceComponent> StorePlaceComponents = context.StorePlaceComponents.Where(storePlace => storePlace.ComponentId == storePlaceComponent.Key);
                            int freeCount = StorePlaceComponents.Sum(storePlace => storePlace.Count);
                            if (freeCount < count)
                            {
                                throw new Exception("Недостаточно компонентов");
                            }

                            foreach (StorePlaceComponent component in StorePlaceComponents)
                            {
                                if (component.Count <= count)
                                {
                                    count -= component.Count;
                                    context.StorePlaceComponents.Remove(component);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    component.Count -= count;
                                    context.SaveChanges();
                                    count = 0;
                                }

                                if (count == 0)
                                {
                                    break;
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private StorePlace CreateModel(StorePlaceBindingModel model, StorePlace storePlace, FlowerShopDatabase context)
        {
            storePlace.StorePlaceName = model.StorePlaceName;
            storePlace.AdministratorName = model.AdministratorName;

            if (storePlace.Id == 0)
            {
                storePlace.DateCreate = DateTime.Now;
                context.StorePlaces.Add(storePlace);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var storePlaceComponents = context.StorePlaceComponents.Where(rec => rec.StorePlaceId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.StorePlaceComponents.RemoveRange(storePlaceComponents.Where(rec => !model.StorePlaceComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in storePlaceComponents)
                {
                    updateComponent.Count = model.StorePlaceComponents[updateComponent.ComponentId].Item2;
                    model.StorePlaceComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var storePlaceCpmponents in model.StorePlaceComponents)
            {
                context.StorePlaceComponents.Add(new StorePlaceComponent
                {
                    StorePlaceId = storePlace.Id,
                    ComponentId = storePlaceCpmponents.Key,
                    Count = storePlaceCpmponents.Value.Item2
                });
                context.SaveChanges();
            }
            return storePlace;
        }
    }
}
