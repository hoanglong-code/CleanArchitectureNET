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
    public class DeleteMultipleProductHandler : IRequestHandler<DeleteMultipleProductCommand, List<Product>>
    {
        private readonly IProductService _service;
        public DeleteMultipleProductHandler(IProductService service)
        {
            _service = service;
        }
        public async Task<List<Product>> Handle(DeleteMultipleProductCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteMultipleData(request.Products);
        }
    }
}
