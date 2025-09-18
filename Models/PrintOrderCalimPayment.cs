using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class PrintOrderCalimPayment:BaseEntity
    {
        [Display(Name = "المطالبة")]
        public int? PaymentClaimId {get; set;}
        public PaymentClaim? PaymentClaim { get; set; }

        
        [Display(Name = "أمر التشغيل")]
        public int? PrintOrderId { get; set; }
        public PrintOrder? PrintOrder { get; set; }

        
        [Display(Name = "رقم الجزء")]
        public int?PartNumber { get; set; }

        [Required]
        [DisplayName("القيمة المطالبة")]
        public long ClaimedValue { get; set; } = 0;
        [DisplayName("ملاحظات المطالبة")]
        public string? ClaimNotes { get; set; }


        [DisplayName("مسددة")]
        public bool? Paid { get; set; } = false;

        [DisplayName("تاريخ التسديد")]
        public DateTime? PaymentDate { get; set; }


        [DisplayName("القيمة المسددة")]
        public long? PaymentValue { get; set; }

        [DisplayName("ملاحظات التسديد")]
        public string? PaymentsNotes { get; set; }
    }
}
