using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopBusinessLogic.ViewModels
{
    public class ReportTotalOrdersViewModel
    {
        public DateTime Date { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
