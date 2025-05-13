using Infrastructure.Entities.Extend;
using Infrastructure.Queries.Commands;
using Infrastructure.Services.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly IProductService _service;
        public DeleteProductHandler(IProductService service)
        {
            _service = service;
        }
        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteData(request.Id);
        }
    }
}
