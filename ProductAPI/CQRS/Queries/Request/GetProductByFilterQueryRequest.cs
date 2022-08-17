using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.CQRS.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.CQRS.Queries.Request
{
    public class GetProductByFilterQueryRequest : IRequest<List<GetProductByFilterQueryResponse>>
    {

        
        public string ProductName { get; set; }

        public string ProductColour { get; set; }
    }
}
