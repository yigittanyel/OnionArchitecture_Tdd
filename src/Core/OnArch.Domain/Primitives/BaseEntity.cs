using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnArch.Domain.Primitives
{
    public class BaseEntity<T> 
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
