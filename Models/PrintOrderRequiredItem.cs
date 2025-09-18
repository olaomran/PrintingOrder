using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class PrintOrderRequiredItem:BaseEntity
    {
        [Display(Name = "أمر الطباعة")]
        public int PrintOrderId { get; set; }
        public PrintOrder? PrintOrder { get; set; }
        [Display(Name = "اسم المادة")]
        public int ItemId { get; set; }
        public Item? Item { get; set; }
        [Display(Name = "الكمية المطلوبة")]
        public decimal RequiredAmount { get; set; }

        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

    }
}
