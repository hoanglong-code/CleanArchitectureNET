using Infrastructure.Entities.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityDtos
{
    public class BrandDto : Brand
    {
        public List<Product>? Products {  get; set; }
    }
}
