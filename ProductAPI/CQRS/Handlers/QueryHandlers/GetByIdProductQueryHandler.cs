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
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private ProductDatabaseContext _context;
        public GetByIdProductQueryHandler(ProductDatabaseContext context)
        {
            _context = context;
        }

      

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {

            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductCode == request.ProductCode);
            var response = new GetByIdProductQueryResponse()
            {
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductStockValue = product.ProductStockValue,
                ProductColour = product.ProductColour
            };
            return await Task.FromResult(response);
           
        }
    }
}
