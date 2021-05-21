using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopBusinessLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
    }
}
