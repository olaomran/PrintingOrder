using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.ViewModels
{
    public class CreatePrintOrderViewModel
    {
        // Required fields
        [Display(Name = "رقم أمر العمل")]
        [Required(ErrorMessage = "رقم أمر العمل مطلوب")]
        [Range(1, int.MaxValue, ErrorMessage = "أدخل رقم صحيح أكبر من 0")]
        public int OrderNumber { get; set; }


        [Required(ErrorMessage = "التاريخ مطلوب")]
         public DateTime Date { get; set; } = DateTime.Today;


        [Required(ErrorMessage = "اسم المطبوعة مطلوب")]
        public string PrintName { get; set; }



        [Required(ErrorMessage = "رقم العقد مطلوب")]
        public string ContractNumber { get; set; }



        [Required(ErrorMessage = "عدد الصفحات مطلوب")]
        [Range(1, int.MaxValue, ErrorMessage = "أدخل رقم صحيح أكبر من 0")]
        public int PagesCount { get; set; }



        [Required(ErrorMessage = "عدد النسخ مطلوب")]
        [Range(1, int.MaxValue, ErrorMessage = "أدخل رقم صحيح أكبر من 0")]
        public int CopiesCount { get; set; }

        [Required(ErrorMessage = "يجب اختيار القياس")]
        public int? PrintSizeId { get; set; }

        // Optional
        public string? IntryNumber { get; set; }
        public DateTime? IntryDate { get; set; }
        public string? PartyBookNumber { get; set; }
        public DateTime? PartyBookDate { get; set; }
        public DateTime? AgreedDeliveryDate { get; set; }
        public int? DelegateId { get; set; }
        public string? Notes { get; set; }
        // Calculated (editable by user)
        [Display(Name = "عدد الملازم للمطبوعة")]
        public decimal PrintSignatureCount { get; set; }  // pages/16, 2 decimals
        [Display(Name = "عدد الملازم الكلي")]
        public decimal TotalPrintSignatureCount { get; set; } // PrintSignatureCount * CopiesCount
        [Display(Name = "عدد الكبسات الكلي")]
        public int TotalPressRuns { get; set; } // equals total signatures rounded? kept editable

        // Temp lists for UI
        public List<SignatureRowViewModel> SignatureRows { get; set; } = new();
        public List<TempConsumedItemViewModel> TempConsumedItems { get; set; } = new();

        // Select lists (populate in GET)
        public IEnumerable<SelectListItem>? Sizes { get; set; }
        public IEnumerable<SelectListItem>? Delegates { get; set; }
        public IEnumerable<SelectListItem>? Stores { get; set; }
        public IEnumerable<SelectListItem>? Categoris { get; set; }
        public IEnumerable<SelectListItem>? Items { get; set; }
    }


    public class SignatureRowViewModel
    {
        public int SignatureOrder { get; set; }
        public bool WholeSignature { get; set; }
        public decimal SignaturePart { get; set; } // e.g. 0.25
        public int PagesCount { get; set; } = 16;
        public int RequiredQuantity { get; set; } // initial = CopiesCount
    }

    public class TempConsumedItemViewModel
    {
        public int? StoreId { get; set; }
        public int? CategoryId { get; set; }
        public int? ItemId { get; set; }
        public decimal Amount { get; set; }
    }
}
