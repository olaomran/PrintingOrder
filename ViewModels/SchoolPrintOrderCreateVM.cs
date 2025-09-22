
using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.ViewModels
{
    public class SchoolPrintOrderCreateVM
    {
        [Required]
        [Display(Name = "رقم أمر العمل")]
        public string OrderNumber { get; set; }

        [Required]
        [Display(Name = "التاريخ")]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required]
        [Display(Name = "اسم المطبوعة")]
        public string PrintName { get; set; }

        [Required]
        [Display(Name = "رقم العقد")]
        public string ContractNumber { get; set; }

        [Display(Name = "السنة")]
        public string OrderYear => Date.Year.ToString();

        [Display(Name = "رقم الورود")]
        public string? IntryNumber { get; set; }

        [Display(Name = "تاريخ الورود")]
        public DateTime? IntryDate { get; set; }

        [Display(Name = "رقم كتاب الجهة")]
        public string? PartyBookNumber { get; set; }

        [Display(Name = "تاريخ كتاب الجهة")]
        public DateTime? PartyBookDate { get; set; }

        [Display(Name = "التاريخ المتفق عليه للتسليم")]
        public DateTime? AgreedDeliveryDate { get; set; }

        [Display(Name = "المندوب")]
        public int? DelegateId { get; set; }


        [Display(Name = "العائدية")]
        public int? CustomerId { get; set; }

        [Required]
        [Display(Name = "عدد النسخ المطلوبة")]
        public int CopiesCount { get; set; }

        [Required]
        [Display(Name = "عدد صفحات المطبوعة")]
        public int PagesCount { get; set; }

        [Required]
        [Display(Name = "قياس النموذج")]
        public int PrintSizeId { get; set; }

        // --- الحقول المحسوبة ---
        [Display(Name = "عدد الملازم للمطبوعة الواحدة")]
        public decimal PrintSignatureCount { get; set; }

        [Display(Name = "عدد الملازم للمطبوعة الواحدة")]
        public decimal? ManualSignatureCount { get; set; }


        [Display(Name = "عدد الملازم الكلي")]
        public decimal TotalPrintSignatureCount { get; set; }

        [Display(Name = "عدد الكبسات الكلي")]
        public int TotalPressRuns { get; set; }

        // جدول الملازم الناتج
        public List<SignatureRowVM> Signatures { get; set; } = new();

        public List<RequiredItemVM> RequiredItems { get; set; } = new();
    }

    public class SignatureRowVM
    {
        public int SignatureOrder { get; set; }
        public bool WholeSignature { get; set; }
        public decimal PagesCount { get; set; }
        public decimal SignaturePart { get; set; }
        public int RequiredQuantity { get; set; }
    }

    public class RequiredItemVM
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } // لعرضها فقط
        public decimal RequiredAmount { get; set; }
    }
}


