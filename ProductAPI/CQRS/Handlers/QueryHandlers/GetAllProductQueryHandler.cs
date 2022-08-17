using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductAPI.CQRS.Queries.Request;
using ProductAPI.CQRS.Queries.Response;
using ProductAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductAPI.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly ProductDatabaseContext _context;

        public GetAllProductQueryHandler(ProductDatabaseContext context)
        {
            _context = context;
        }

        
        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            
            return await _context.Products.Select(product => new GetAllProductQueryResponse
            {
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductStockValue = product.ProductStockValue,
                ProductColour = product.ProductColour
            }).ToListAsync();
        }
    }
}
