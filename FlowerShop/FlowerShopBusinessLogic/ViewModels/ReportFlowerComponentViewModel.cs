using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopBusinessLogic.ViewModels
{
    public class ReportFlowerComponentViewModel
    {
        public string FlowerName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}
