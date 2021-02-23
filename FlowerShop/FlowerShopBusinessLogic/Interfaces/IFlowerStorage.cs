using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopBusinessLogic.Interfaces
{
    public interface IFlowerStorage
    {
        List<FlowerViewModel> GetFullList();
        List<FlowerViewModel> GetFilteredList(FlowerBindingModel model);
        FlowerViewModel GetElement(FlowerBindingModel model);
        void Insert(FlowerBindingModel model);
        void Update(FlowerBindingModel model);
        void Delete(FlowerBindingModel model);
    }
}
