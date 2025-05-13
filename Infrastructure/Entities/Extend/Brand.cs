using Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Extend
{
    public class Brand : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Note { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Brand()
        {
            Products = new List<Product>();
        }
    }
}
