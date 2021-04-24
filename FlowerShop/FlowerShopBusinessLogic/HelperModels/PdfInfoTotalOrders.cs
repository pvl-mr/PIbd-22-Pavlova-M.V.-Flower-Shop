using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopBusinessLogic.HelperModels
{
    public class PdfInfoTotalOrders
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportTotalOrdersViewModel> Orders { get; set; }
    }
}
