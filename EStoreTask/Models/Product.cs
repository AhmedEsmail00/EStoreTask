using System.ComponentModel.DataAnnotations;

namespace EStoreTask.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }


        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new HashSet<OrderDetails>();
    }
}
