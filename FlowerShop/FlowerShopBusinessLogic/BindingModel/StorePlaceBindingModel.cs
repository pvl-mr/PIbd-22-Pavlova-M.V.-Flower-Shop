using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopBusinessLogic.BindingModel
{
    public class StorePlaceBindingModel
    {
        public int? Id { get; set; }

        public string StorePlaceName { get; set; }

        public string AdministratorName { get; set; }

        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> StorePlaceComponents { get; set; }
    }
}
