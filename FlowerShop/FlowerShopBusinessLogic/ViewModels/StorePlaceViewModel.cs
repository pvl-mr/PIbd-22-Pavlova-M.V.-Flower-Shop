using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FlowerShopBusinessLogic.ViewModels
{
    public class StorePlaceViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название склада")]
        public string StorePlaceName { get; set; }

        [DisplayName("ФИО ответственного")]
        public string AdministratorName { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> StorePlaceComponents { get; set; }
    }
}
