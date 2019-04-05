using System.Collections.Generic;

namespace Core.Models
{
    public class Order
    {
        public int Id { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
