using System.Runtime.Serialization;

namespace InventoryService.Models
{
    [DataContract]
    public class Inventory
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public int ProductId { get; set; }
    }
}