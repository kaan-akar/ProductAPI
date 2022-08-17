using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Data
{
    public class Product
    {
        [Key]
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductColour { get; set; }       
        public double ProductPrice { get; set; }
        public int ProductStockValue { get; set; }
    }
}
