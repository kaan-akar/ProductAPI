using MediatR;
using ProductAPI.CQRS.Commands.Request;
using ProductAPI.CQRS.Commands.Response;
using ProductAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductAPI.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly ProductDatabaseContext _context;
        public CreateProductCommandHandler(ProductDatabaseContext context)
        {
            _context = context;
        }


        
        public Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            
            _context.Products.Add(new Product()
            {
                ProductName = request.ProductName,
                ProductColour = request.ProductColour,
                ProductPrice = request.ProductPrice,
                ProductStockValue = request.ProductStockValue
            });
            _context.SaveChanges();
            return Task.FromResult(new CreateProductCommandResponse()
            {
                IsSuccess = true
            });
        }
    }
}
