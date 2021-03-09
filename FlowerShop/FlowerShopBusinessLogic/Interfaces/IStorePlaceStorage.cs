using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopBusinessLogic.Interfaces
{
    public interface IStorePlaceStorage
    {
        List<StorePlaceViewModel> GetFullList();
        List<StorePlaceViewModel> GetFilteredList(StorePlaceBindingModel model);
        StorePlaceViewModel GetElement(StorePlaceBindingModel model);
        void Insert(StorePlaceBindingModel model);
        void Update(StorePlaceBindingModel model);
        void Delete(StorePlaceBindingModel model);
        bool TakeComponents(Dictionary<int, (string, int)> flowerComponents, int count);
    }
}
