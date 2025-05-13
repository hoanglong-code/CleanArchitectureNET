using Infrastructure.Entities.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityDtos
{
    public class ProductDto : Product
    {
        public string? BrandName { get; set; }
        public static Expression<Func<Product, ProductDto>> Expression => p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Code = p.Code,
            Note = p.Note,
            BrandId = p.BrandId,
            Price = p.Price,
            BrandName = p.Brand.Name,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt,
            CreatedById = p.CreatedById,
            UpdatedById = p.UpdatedById,
            CreatedBy = p.CreatedBy,
            UpdatedBy = p.UpdatedBy,
        };
    }
}
