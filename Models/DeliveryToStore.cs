using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class DeliveryToStore:BaseEntity
    {
        [DisplayName("رقم مذكرة التسليم")]
        [Required]
        public int DeliveryNumber { get; set; }

        [DisplayName("تاريخ مذكرة التسليم")]
        [Required]
        public DateTime DeliveryDate { get; set; }


        public ICollection<PrintOrderDelivery> PrintOrderDeliveries { get; set; }
    }
}
