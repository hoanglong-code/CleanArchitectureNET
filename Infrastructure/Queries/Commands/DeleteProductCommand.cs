using Infrastructure.Commons;
using Infrastructure.Entities.Extend;
using Infrastructure.EntityDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.Commands
{
    public class DeleteProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
