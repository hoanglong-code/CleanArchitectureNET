using Infrastructure.Entities.Extend;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.Commands
{
    public class GetProductByIdCommand: IRequest<Product>
    {
        public int Id { get; set; }
    }
}
