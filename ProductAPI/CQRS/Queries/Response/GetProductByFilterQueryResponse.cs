using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.CQRS.Queries.Response
{
    public class GetProductByFilterQueryResponse
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductColour { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStockValue { get; set; }
    }
}
