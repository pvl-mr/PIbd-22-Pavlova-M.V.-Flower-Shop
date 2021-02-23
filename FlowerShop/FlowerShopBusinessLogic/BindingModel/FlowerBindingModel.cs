using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopBusinessLogic.BindingModel
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class FlowerBindingModel
    {
        public int? Id { get; set; }
        public string FlowerName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> FlowerComponents { get; set; }
    }
}
