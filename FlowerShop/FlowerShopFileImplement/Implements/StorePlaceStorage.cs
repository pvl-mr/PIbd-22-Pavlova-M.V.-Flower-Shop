using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowerShopFileImplement.Implements
{
    public class StorePlaceStorage : IStorePlaceStorage
    {
        private readonly FileDataListSingleton source;

        public StorePlaceStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        private StorePlace CreateModel(StorePlaceBindingModel model, StorePlace storePlace)
        {
            storePlace.StorePlaceName = model.StorePlaceName;
            storePlace.AdministratorName = model.AdministratorName;
            // удаляем убранные
            foreach (var key in storePlace.StorePlaceComponents.Keys.ToList())
            {
                if (!model.StorePlaceComponents.ContainsKey(key))
                {
                    storePlace.StorePlaceComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.StorePlaceComponents)
            {
                if (storePlace.StorePlaceComponents.ContainsKey(component.Key))
                {
                    storePlace.StorePlaceComponents[component.Key] = model.StorePlaceComponents[component.Key].Item2;

                }
                else
                {
                    storePlace.StorePlaceComponents.Add(component.Key, model.StorePlaceComponents[component.Key].Item2);
                }
            }
            return storePlace;
        }

        private StorePlaceViewModel CreateModel(StorePlace storePlace)
        {
            return new StorePlaceViewModel
            {
                Id = storePlace.Id,
                StorePlaceName = storePlace.StorePlaceName,
                AdministratorName = storePlace.AdministratorName,
                DateCreate = storePlace.DateCreate,
                StorePlaceComponents = storePlace.StorePlaceComponents
                                    .ToDictionary(recPC => recPC.Key, recPC =>
                                    (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }

        public void Delete(StorePlaceBindingModel model)
        {
            StorePlace element = source.StorePlaces.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.StorePlaces.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public StorePlaceViewModel GetElement(StorePlaceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var storePlace = source.StorePlaces
                        .FirstOrDefault(rec => rec.StorePlaceName == model.StorePlaceName || rec.Id == model.Id);
            return storePlace != null ? CreateModel(storePlace) : null;
        }

        public List<StorePlaceViewModel> GetFilteredList(StorePlaceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.StorePlaces
                    .Where(rec => rec.StorePlaceName.Contains(model.StorePlaceName))
                    .Select(CreateModel)
                    .ToList();
        }

        public List<StorePlaceViewModel> GetFullList()
        {
            return source.StorePlaces
                    .Select(CreateModel)
                    .ToList();
        }

        public void Insert(StorePlaceBindingModel model)
        {
            int maxId = source.StorePlaces.Count > 0 ? source.StorePlaces.Max(rec => rec.Id) : 0;
            var element = new StorePlace { Id = maxId + 1, StorePlaceComponents = new Dictionary<int, int>(), DateCreate = DateTime.Now };
            source.StorePlaces.Add(CreateModel(model, element));
        }

        public void Update(StorePlaceBindingModel model)
        {
            var element = source.StorePlaces.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public bool TakeComponents(Dictionary<int, (string, int)> components, int flowerCount)
        {
            foreach (var storePlaceComponent in components)
            {
                int count = source.StorePlaces.Where(component => component.StorePlaceComponents.ContainsKey(storePlaceComponent.Key)).Sum(compomemt => compomemt.StorePlaceComponents[storePlaceComponent.Key]);
                if (count < storePlaceComponent.Value.Item2 * flowerCount)
                {
                    return false;
                }
            }

            foreach (var storePlaceComponent in components)
            {
                int count = storePlaceComponent.Value.Item2 * flowerCount;
                IEnumerable<StorePlace> storePlaces = source.StorePlaces.Where(component => component.StorePlaceComponents.ContainsKey(storePlaceComponent.Key));

                foreach (StorePlace storePlace in storePlaces)
                {
                    if (storePlace.StorePlaceComponents[storePlaceComponent.Key] <= count)
                    {
                        count -= storePlace.StorePlaceComponents[storePlaceComponent.Key];
                        storePlace.StorePlaceComponents.Remove(storePlaceComponent.Key);
                    }
                    else
                    {
                        storePlace.StorePlaceComponents[storePlaceComponent.Key] -= count;
                        count = 0;
                    }

                    if (count == 0)
                    {
                        break;
                    }
                }
            }

            return true;
        }
    }
}
