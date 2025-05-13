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
    public class SearchProductElasticHandler :IRequestHandler<SearchProductElasticCommand, IEnumerable<object>>
    {
        private readonly IProductService _service;
        public SearchProductElasticHandler(IProductService service)
        {
            _service = service;
        }
        public async Task<IEnumerable<object>> Handle(SearchProductElasticCommand request, CancellationToken cancellationToken)
        {
            return await _service.SearchAsync(request.FieldName,request.SearchTerm,request.Index);
        }
    }
}
