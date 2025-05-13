using Infrastructure.Configurations;
using Infrastructure.Entities.Extend;
using Infrastructure.Reponsitories.Abstractions;
using Infrastructure.Reponsitories.Abstractions.Extend;
using Infrastructure.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Reponsitories.Implementations.Extend
{
    public class ProductRepository : AsyncGenericRepository<Product, int>, IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IUserContext _userContext;
        public ProductRepository(AppDbContext context,IUserContext userContext) : base(context, userContext)
        {
            _context = context;
            _userContext = userContext;
        }
    }
}
