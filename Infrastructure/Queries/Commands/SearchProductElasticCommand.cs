using Infrastructure.Entities.Extend;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.Commands
{
    public class SearchProductElasticCommand : IRequest<IEnumerable<object>>
    {
        public string Index { get; set; }
        public string FieldName { get; set; }
        public string SearchTerm { get; set; }
    }
}
