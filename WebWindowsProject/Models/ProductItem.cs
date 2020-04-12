using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebWindowsProject.Models
{
    public class ProductItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }
        public bool IsPurchased { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string Image{ get; set; }
        public int Amount { get; set; }
        public virtual ICollection<OrderTable> order { get; set; }
    }
}
