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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly ProductDatabaseContext _context;

        public DeleteProductCommandHandler(ProductDatabaseContext context)
        {
            _context = context;
        }
        public Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteProduct = _context.Products.Find(request.ProductCode);

            _context.Remove(deleteProduct);
            var response = new DeleteProductCommandResponse()
            {
                IsSuccess = true
            };
            return Task.FromResult(response);
        }

    }
}
