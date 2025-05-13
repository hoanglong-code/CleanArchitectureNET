using AutoMapper;
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
    public class SaveProductHandler : IRequestHandler<SaveProductCommand, Product>
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public SaveProductHandler(IProductService service,IMapper mapper) 
        { 
            _service = service; 
            _mapper = mapper;
        }
        public async Task<Product> Handle(SaveProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            return await _service.SaveData(product);
        } 
    }
}
