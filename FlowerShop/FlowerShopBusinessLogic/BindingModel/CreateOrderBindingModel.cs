using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopBusinessLogic.BindingModel
{
    /// <summary>
    /// Данные от клиента, для создания заказа
    /// </summary>
    public class CreateOrderBindingModel
    {
        public int FlowerId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
