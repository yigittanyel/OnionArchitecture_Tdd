using OnArch.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnArch.Domain.Entities
{
    public class Product : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Stock { get; set; }
    }
}
