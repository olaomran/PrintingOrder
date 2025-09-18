using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class PrintOrderDelivery:BaseEntity
    {
        [Display(Name = "أمر الطباعة")]
        public int? PrintOrderId { get; set; }
        public PrintOrder? PrintOrder { get; set; }

        [Display(Name = "مذكرة الاستلام")]
        public int? DeliveryId { get; set; }
        public DeliveryToStore? DeliveyToStore { get; set; }

        [Required]
        [Display(Name = "الكمية المسلمة")]
        public int DeliverdAmount { get; set; }

        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }
    }
}
