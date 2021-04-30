using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlowerShopDatabaseImplement.Models
{
    public class Flower
    {
        public int Id { get; set; }
        [Required]
        public string FlowerName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("FlowerId")]
        public virtual List<FlowerComponent> FlowerComponents { get; set; }
        [ForeignKey("FlowerId")]
        public virtual List<Order> Orders { get; set; }
    }
}
