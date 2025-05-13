using Infrastructure.Entities.Extend;
using MediatR;


namespace Infrastructure.Queries.Commands
{
    public class DeleteMultipleProductCommand : IRequest<List<Product>>
    {
        public List<Product> Products { get; set; }
    }
}
