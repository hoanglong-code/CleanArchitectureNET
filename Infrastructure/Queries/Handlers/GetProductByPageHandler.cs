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
    public class GetProductByPageHandler : IRequestHandler<GetProductByPageCommand, BaseSearchResponse<ProductDto>>
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public GetProductByPageHandler(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<BaseSearchResponse<ProductDto>> Handle(GetProductByPageCommand request, CancellationToken cancellationToken)
        {
            BaseCriteria baseCriteria = _mapper.Map<BaseCriteria>(request);
            return await _service.GetByPage(baseCriteria);
        }
    }
}
