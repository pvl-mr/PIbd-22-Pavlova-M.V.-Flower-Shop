using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopListImplement.Models
{
    class StorePlace
    {
        public int Id { get; set; }
        public string StorePlaceName { get; set; }
        public string AdministratorName { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, int> StorePlaceComponents { get; set; }
    }
}
