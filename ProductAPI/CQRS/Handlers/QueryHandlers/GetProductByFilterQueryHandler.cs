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
    public class GetProductByFilterQueryHandler : IRequestHandler<GetProductByFilterQueryRequest, List<GetProductByFilterQueryResponse>>
    {
        private readonly ProductDatabaseContext _context;

        public GetProductByFilterQueryHandler(ProductDatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<GetProductByFilterQueryResponse>> Handle(GetProductByFilterQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.Where(p => (p.ProductName.Contains(request.ProductName))&&(p.ProductColour==request.ProductColour)).ToListAsync();


            var response = result.Select(product => new GetProductByFilterQueryResponse
            {
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductStockValue = product.ProductStockValue,
                ProductColour = product.ProductColour
            }).ToList();


            return await Task.FromResult(response);
        }





    }
}
