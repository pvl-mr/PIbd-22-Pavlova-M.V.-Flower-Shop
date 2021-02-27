using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FlowerShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class FlowerViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название изделия")]
        public string FlowerName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> FlowerComponents { get; set; }
    }
}
