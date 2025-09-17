using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class PrintOrder : BaseEntity
    {
        [Required]
        [Display(Name = "رقم أمر العمل")]
        public string OrderNumber
        {
            get; set;
        }
        [Required]
        [Display(Name = "اسم المطبوعة")]
        public string PrintName { get; set; }
        [Required]
        [Display(Name = "التاريخ")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "رقم العقد")]
        public string ContractNumber { get; set; }


        [Display(Name = "السنة")]
        public string OrderYear { get; set; }
        [Required]
        [Display(Name = "عدد النسخ")]
        public int CopiesCount { get; set; }
        [Required]
        [Display(Name = "عدد الصفحات")]
        public int PagesCount { get; set; }


        // Calculated fields stored for convenience (can also be computed on the fly)
        //عدد الملازم الكلي
        [Display(Name = "عدد الملازم")]
        public int TotalBooklets { get; set; } // = (Pages / 16) * Copies
        [Display(Name = "عدد الكبسات الكلي")]
        public int TotalPressRuns { get; set; } // number of "كبسات" overall
        [Display(Name = "عدد الكبسات المتبقية")]
        public int RemainingPressRuns { get; set; }
        [Display(Name = "عدد الكبسات المنجزة")]
        public int CompletedPressRuns { get; set; }
        [Display(Name = "عدد النسخ المجلدة ")]
        public int FoldedCopies { get; set; } = 0; // عدد النسخ المجلدة، يبدأ بـ0

        [Display(Name = "قياس النموذج")]
        public string Size { get; set; } // e.g. "20.5x24" or "17.5x24"
        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }
        [Display(Name = "تفصيل")]
        public string? Details { get; set; }


        public ICollection<MachineProduction>? MachineProductions { get; set; }
    }
}
