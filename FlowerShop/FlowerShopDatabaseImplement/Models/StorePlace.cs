using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlowerShopDatabaseImplement.Models
{
    public class StorePlace
    {
        public int Id { get; set; }

        [Required]
        public string StorePlaceName { get; set; }

        [Required]
        public string AdministratorName { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [ForeignKey("StorePlaceId")]
        public virtual List<StorePlaceComponent> StorePlaceComponents { get; set; }
    }
}
