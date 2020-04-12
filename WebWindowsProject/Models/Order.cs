using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebWindowsProject.Models
{
    public class Order
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        public ProductItem Product { get; set; }
  

    }
}
