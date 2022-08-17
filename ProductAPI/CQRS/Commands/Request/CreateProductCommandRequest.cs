using MediatR;
using ProductAPI.CQRS.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.CQRS.Commands.Request
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string ProductName { get; set; }
        public string ProductColour { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStockValue { get; set; }
    }
}
