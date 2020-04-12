using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebWindowsProject.Models
{
    public class SatinAlViewModel
    {
        public string product_name { get; set; }
        public double price{ get; set; }
        public string type_name{ get; set; }
        public string description { get; set; }
        public int Amount { get; set; }
        public int product_id { get; set; }
    }
}
