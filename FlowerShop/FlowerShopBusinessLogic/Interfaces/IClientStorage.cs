using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopBusinessLogic.Interfaces
{
    public interface IClientStorage
    {
        List<ClientViewModel> GetFullList();

        List<ClientViewModel> GetFilteredList(ClientBindingModel model);

        ClientViewModel GetElement(ClientBindingModel model);

        void Insert(ClientBindingModel model);

        void Update(ClientBindingModel model);

        void Delete(ClientBindingModel model);
    }
}
