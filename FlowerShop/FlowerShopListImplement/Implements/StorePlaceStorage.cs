using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowerShopListImplement.Implements
{
    public class StorePlaceStorage : IStorePlaceStorage
    {
        private readonly DataListSingleton source;

        public StorePlaceStorage()
        {
            source = DataListSingleton.GetInstance();
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
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> storePlaceComponents = new Dictionary<int, (string, int)>();
            foreach (var storePlaceComponent in storePlace.StorePlaceComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (storePlaceComponent.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                storePlaceComponents.Add(storePlaceComponent.Key, (componentName, storePlaceComponent.Value));
            }
            return new StorePlaceViewModel
            {
                Id = storePlace.Id,
                StorePlaceName = storePlace.StorePlaceName,
                AdministratorName = storePlace.AdministratorName,
                DateCreate = storePlace.DateCreate,
                StorePlaceComponents = storePlaceComponents
            };
        }

        public void Delete(StorePlaceBindingModel model)
        {
            for (int i = 0; i < source.StorePlaces.Count; ++i)
            {
                if (source.StorePlaces[i].Id == model.Id)
                {
                    source.StorePlaces.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public StorePlaceViewModel GetElement(StorePlaceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var storePlace in source.StorePlaces)
            {
                if (storePlace.Id == model.Id || storePlace.StorePlaceName == model.StorePlaceName)
                {
                    return CreateModel(storePlace);
                }
            }
            return null;
        }

        public List<StorePlaceViewModel> GetFilteredList(StorePlaceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            List<StorePlaceViewModel> result = new List<StorePlaceViewModel>();
            foreach (StorePlace storePlace in source.StorePlaces)
            {
                if (storePlace.StorePlaceName.Contains(model.StorePlaceName))
                {
                    result.Add(CreateModel(storePlace));
                }
            }
            return result;
        }

        public List<StorePlaceViewModel> GetFullList()
        {
            List<StorePlaceViewModel> result = new List<StorePlaceViewModel>();
            foreach (StorePlace storePlaces in source.StorePlaces)
            {
                result.Add(CreateModel(storePlaces));
            }
            return result;
        }

        public void Insert(StorePlaceBindingModel model)
        {
            StorePlace tempStorePlace = new StorePlace
            {
                Id = 1,
                StorePlaceComponents = new Dictionary<int, int>(),
                DateCreate = DateTime.Now
            };

            foreach (StorePlace storePlace in source.StorePlaces)
            {
                if (storePlace.Id >= tempStorePlace.Id)
                {
                    tempStorePlace.Id = storePlace.Id + 1;
                }
            }
            source.StorePlaces.Add(CreateModel(model, tempStorePlace));
        }

        public void Update(StorePlaceBindingModel model)
        {
            StorePlace tempStorePlace = null;

            foreach (StorePlace storePlace in source.StorePlaces)
            {
                if (storePlace.Id == model.Id)
                {
                    tempStorePlace = storePlace;
                }
            }

            if (tempStorePlace == null)
            {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, tempStorePlace);
        }

        public bool TakeComponents(Dictionary<int, (string, int)> flowerComponents, int count)
        {
            throw new NotImplementedException();
        }
    }
}
