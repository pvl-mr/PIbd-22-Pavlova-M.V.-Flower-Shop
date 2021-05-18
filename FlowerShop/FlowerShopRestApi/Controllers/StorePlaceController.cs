using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.BusinessLogic;
using FlowerShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorePlaceController : Controller
    {
        private readonly StorePlaceLogic _storePlace;

        private readonly ComponentLogic _component;

        public StorePlaceController(StorePlaceLogic storePlace, ComponentLogic componentLogic)
        {
            _storePlace = storePlace;
            _component = componentLogic;
        }

        [HttpGet]
        public List<StorePlaceViewModel> GetStorePlaces() => _storePlace.Read(null)?.ToList();

        [HttpPost]
        public void CreateOrUpdateStorePlace(StorePlaceBindingModel model)
            => _storePlace.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteStorePlace(StorePlaceBindingModel model) => _storePlace.Delete(model);

        [HttpPost]
        public void AddComponent(StorePlaceComponentBindingModel model)
            => _storePlace.AddComponent(model);

        [HttpGet]
        public StorePlaceViewModel GetStorePlace(int storePlaceId)
            => _storePlace.Read(new StorePlaceBindingModel { Id = storePlaceId })?[0];

        [HttpGet]
        public List<ComponentViewModel> GetComponents()
            => _component.Read(null);
    }
}
