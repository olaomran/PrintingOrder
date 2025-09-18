using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class Unit: BaseEntity
    {
        [Display(Name = "المستودع")]
        public int? StoreId { get; set; }
        public Store Store { get; set; }


        //مثلا نعرف الواحدة ماعون فتكون الواحدة الجزئية هنا هي الطبق وكميتها أي ItemsInUnit = 500 
        [Display(Name = "الواحدة الجزئية")]
        public int? UnitId { get; set; }

        public Unit SubUnit { get; set; }


        [Display(Name = "عدد الواحدات الجزئية")]
        public int? ItemsInUnit { get; set; }


        [Required]
        [Display(Name = "اسم الواحدة")]
        public string Name { get; set; }


        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

        public ICollection<Item>? Items { get; set; }

        //قائمة الواحدات الآباء التي تشكل لهم هذا الواحدة جزء
        //مثلا لو كانت هذه الواحدة طبق فآباؤها هم ماعون باكيت رول ...
        public ICollection<Unit>? FatherUnit { get; set; }
    }
}
