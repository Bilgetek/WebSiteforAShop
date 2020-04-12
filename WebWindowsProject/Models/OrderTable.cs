using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebWindowsProject.Models
{
    public class OrderTable
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public DateTime DatetoPresent { get; set; }
        public int productDetailsId { get; set; }
        public string amount { get; set; }
        public double price { get; set; }
        public bool isPurchased { get; set; }
        public virtual ProductItem productDetails { get; set; }
    }
}
