using System.Runtime.Serialization;

namespace InventoryService.Models
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Cost { get; set; }
    }
}