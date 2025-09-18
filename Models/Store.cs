using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class Store: BaseEntity
    {
        [Required]
        [Display(Name = "اسم المستودع")]
        public string Name { get; set; }
        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

        public ICollection<Category>? Categories { get; set; }
    }
}
