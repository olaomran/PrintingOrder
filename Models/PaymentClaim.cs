using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class PaymentClaim:BaseEntity
    {
        /// <summary>
        /// Claim Fields
        /// </summary>
        /// 
        [Required]
        [DisplayName("رقم المطالبة")]
        public int ClaimNumber { get; set; }
        [Required]
        [DisplayName("تاريخ المطالبة")]
        public DateTime ClaimDate { get; set; }
        [Required]
        [DisplayName("قيمة المطالبة")]
        public long ClaimValue { get; set; } = 0;
        [DisplayName("ملاحظات المطالبة")]
        public string? ClaimNotes { get; set; }


        /// <summary>
        /// Payment Fields
        /// </summary>
        [DisplayName("مسددة")]
        public bool? Paid { get; set; } = false;

        [DisplayName("تاريخ التسديد")]
        public DateTime? PaymentDate { get; set; }


        [DisplayName("القيمة المسددة")]
        public long? PaymentValue { get; set; }

        [DisplayName("ملاحظات التسديد")]
        public string? PaymentsNotes { get; set; }

        public ICollection<PrintOrderCalimPayment> PrintOrderPayments { get; set; }


    }
}
