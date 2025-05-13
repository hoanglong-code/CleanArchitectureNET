using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities.Base;

namespace Infrastructure.Entities.Extend
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Note { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
