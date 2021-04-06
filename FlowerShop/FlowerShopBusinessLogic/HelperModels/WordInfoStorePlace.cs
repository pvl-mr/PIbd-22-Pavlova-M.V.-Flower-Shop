using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopBusinessLogic.HelperModels
{
    public class WordInfoStorePlace
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<StorePlaceViewModel> StorePlaces { get; set; }
    }
}
