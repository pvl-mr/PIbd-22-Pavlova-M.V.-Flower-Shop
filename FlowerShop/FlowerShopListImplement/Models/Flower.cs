using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopListImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    class Flower
    {
        public int Id { get; set; }
        public string FlowerName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> FlowerComponents { get; set; }
    }
}
