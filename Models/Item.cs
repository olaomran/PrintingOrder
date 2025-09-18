using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class Item: BaseEntity
    {
        [Display(Name = "القسم")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }



        [Display(Name = "الواحدة")]
        public int? UnitId { get; set; }
        public Unit Unit { get; set; }


        [Required]
        [Display(Name = "اسم المادة")]
        public string Name { get; set; }

      
        [Display(Name = "رقم المادة")]
        public int? Order { get; set; }

        [Display(Name = "رقم المادة الفرعي")]
        public int? SubOrder { get; set; }

        [Display(Name = "رصيد المادة")]
        public decimal? Quantity { get; set; }

        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

        public ICollection<PrintOrderRequiredItem>? RequiredItems { get; set; }
    }
}
