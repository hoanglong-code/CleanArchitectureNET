using Infrastructure.Entities.Extend;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.Commands
{
    public class SaveProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Note { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
    }
}
