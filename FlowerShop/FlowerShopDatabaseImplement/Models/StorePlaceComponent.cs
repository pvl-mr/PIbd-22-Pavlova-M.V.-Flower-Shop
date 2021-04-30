using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlowerShopDatabaseImplement.Models
{
    public class StorePlaceComponent
    {
        public int Id { get; set; }

        public int ComponentId { get; set; }

        public int StorePlaceId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Component Component { get; set; }

        public virtual StorePlace StorePlace { get; set; }
    }
}
