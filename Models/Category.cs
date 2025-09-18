using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class Category: BaseEntity
    {
        [Display(Name = "المستودع")]
        public int? StoreId { get; set; }
        public Store Store { get; set; }
        [Required]
        [Display(Name = "اسم القسم")]
        public string Name { get; set; }
        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

        public ICollection<Item>? Items { get; set; }
    }
}
