using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWindowsProject.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public bool IsPurchased { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}