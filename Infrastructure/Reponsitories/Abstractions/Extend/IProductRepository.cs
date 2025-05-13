using Infrastructure.Entities.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Reponsitories.Abstractions.Extend
{
    public interface IProductRepository : IAsyncGenericRepository<Product, int>
    {
    }
}
