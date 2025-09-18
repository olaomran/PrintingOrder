using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class ProductionConsumedItem:BaseEntity
    {
        [Display(Name = "أمر الطباعة")]
        public int MachineProductionId{ get; set; }
        public MachineProduction? MachineProduction { get; set; }



        [Display(Name = "اسم المادة")]
        public int ItemId { get; set; }
        public Item? Item { get; set; }



        [Display(Name = "الكمية المستهلكة")]
        public decimal ConsumedAmount { get; set; }

        [Display(Name = "يوجد تلف؟")]
        public bool isDamaging { get; set; } = false;

        [Display(Name = "يوجد وفر؟")]
        public bool isSaving { get; set; } = false;

        [Display(Name = "التبرير")]
        public string? Justification { get; set; }



    }
}
