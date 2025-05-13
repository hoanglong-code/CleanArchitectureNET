using AutoMapper;
using Infrastructure.Commons;
using Infrastructure.Entities.Extend;
using Infrastructure.EntityDtos;
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
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdCommand, Product>
    {
        private readonly IProductService _service;
        public GetProductByIdHandler(IProductService service)
        {
            _service = service;
        }
        public async Task<Product> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            return await _service.GetById(request.Id);
        }
    }
}
