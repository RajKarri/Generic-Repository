using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Models
{
    [Table("Inventory")]
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
