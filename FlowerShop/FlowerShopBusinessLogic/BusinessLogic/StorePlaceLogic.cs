using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopBusinessLogic.BusinessLogic
{
    public class StorePlaceLogic
    {
        private readonly IStorePlaceStorage _storePlaceStorage;
        private readonly IComponentStorage _componentStorage;

        public StorePlaceLogic(IStorePlaceStorage storePlaceStorage, IComponentStorage componentStorage)
        {
            _storePlaceStorage = storePlaceStorage;
            _componentStorage = componentStorage;
        }

        public List<StorePlaceViewModel> Read(StorePlaceBindingModel model)
        {
            if (model == null)
            {
                return _storePlaceStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<StorePlaceViewModel> { _storePlaceStorage.GetElement(model) };
            }
            return _storePlaceStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(StorePlaceBindingModel model)
        {
            var element = _storePlaceStorage.GetElement(new StorePlaceBindingModel { StorePlaceName = model.StorePlaceName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            if (model.Id.HasValue)
            {
                _storePlaceStorage.Update(model);
            }
            else
            {
                _storePlaceStorage.Insert(model);
            }
        }

        public void Delete(StorePlaceBindingModel model)
        {
            var element = _storePlaceStorage.GetElement(new StorePlaceBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _storePlaceStorage.Delete(model);
        }

        public void AddComponent(StorePlaceComponentBindingModel model)
        {
            StorePlaceViewModel storePlace = _storePlaceStorage.GetElement(new StorePlaceBindingModel { Id = model.StorePlaceId });

            if (storePlace == null)
            {
                throw new Exception("Склад не найден");
            }

            ComponentViewModel component = _componentStorage.GetElement(new ComponentBindingModel { Id = model.ComponentId });

            if (component == null)
            {
                throw new Exception("Компонент не найден");
            }

            var storageComponents = storePlace.StorePlaceComponents;

            if (storageComponents.ContainsKey(model.ComponentId))
            {
                storageComponents[model.ComponentId] = (storageComponents[model.ComponentId].Item1, storageComponents[model.ComponentId].Item2 + model.Count);
            }
            else
            {
                storageComponents.Add(model.ComponentId, (component.ComponentName, model.Count));
            }

            _storePlaceStorage.Update(new StorePlaceBindingModel
            {
                Id = storePlace.Id,
                StorePlaceName = storePlace.StorePlaceName,
                AdministratorName = storePlace.AdministratorName,
                DateCreate = storePlace.DateCreate,
                StorePlaceComponents = storageComponents
            });
        }
    }
}
