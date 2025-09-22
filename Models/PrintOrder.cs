using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class PrintOrder : BaseEntity
    {

        [Required]
        [Display(Name = "نوع المطبوعة")]
        public PrintOrderType PrintOrderType
        {
            get; set;
        }



        [Display(Name = "رقم أمر العمل")]
        [Required(ErrorMessage = "رقم أمر العمل مطلوب")]
        public string OrderNumber
        {
            get; set;
        }


        [Required(ErrorMessage = "اسم المطبوعة مطلوب")]
        [Display(Name = "اسم المطبوعة")]
        public string PrintName { get; set; }



        [Required(ErrorMessage = "التاريخ مطلوب")]
        [Display(Name = "التاريخ")]
        public DateTime Date { get; set; }


        [Required(ErrorMessage = "رقم العقد مطلوب")]
        [Display(Name = "رقم العقد")]
        public string ContractNumber { get; set; }


        //السنة تؤخذ آلياً من حقل المباشرة 
        [Display(Name = "السنة")]
        public string OrderYear { get; set; }





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


        [Required(ErrorMessage = "يجب اختيار العائدية")]

        [Display(Name = "العائدية")]
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }


        [Display(Name = "المندوب")]
        public int? DelegateId { get; set; }
        public Delegate? Delegate { get; set; }

        [Required(ErrorMessage = "عدد النسخ مطلوب")]
        [Range(1, int.MaxValue, ErrorMessage = "أدخل رقم صحيح أكبر من 0")]
        [Display(Name = " عدد النسخ المطلوبة")]
        public int CopiesCount { get; set; }


        [Required(ErrorMessage = "عدد الصفحات مطلوب")]
        [Range(1, int.MaxValue, ErrorMessage = "أدخل رقم صحيح أكبر من 0")]
        [Display(Name = "عدد صفحات المطبوعة")]
        public int PagesCount { get; set; }

        // Calculated fields stored for convenience (can also be computed on the fly)
        //عدد الملازم الكلي
        [Display(Name = "عدد الملازم للمطبوعة")]
        public decimal PrintSignatureCount { get; set; } // = (Pages / 16) 



        [Display(Name = "عدد الملازم الكلي")]
        public decimal TotalPrintSignatureCount { get; set; } // = (Pages / 16) * Copies


        [Display(Name = "عدد الكبسات الكلي")]
        public int TotalPressRuns { get; set; } // number of "كبسات" overall



        [Display(Name = "عدد الكبسات المتبقية")]
        public int RemainingPressRuns { get; set; }


        [Display(Name = "عدد الكبسات المنجزة")]
        public int CompletedPressRuns { get; set; }



        [Display(Name = "عدد النسخ المجلدة ")]
        public int FoldedCopies { get; set; } = 0; // عدد النسخ المجلدة، يبدأ بـ0

        [Display(Name = "عدد النسخ المُسلمة للمستودع ")]
        public int DeliveriedCopiesToStore { get; set; } = 0; // عدد النسخ المُسلمة، يبدأ بـ0

        [Required(ErrorMessage = "يجب اختيار القياس")]
        [Display(Name = "قياس النموذج")]
        public int? PrintSizeId { get; set; }
        public PrintSize? Size { get; set; }


        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }


        [Display(Name = "تفصيل")]
        public string? Details { get; set; }

        [Display(Name = "المرحلة ")]
        public PrintOrderLevel PrintOrderLevel { get; set; } = PrintOrderLevel.NotStarted;

        [Display(Name = "مطالب ")]
        public bool isClaimed { get; set; } = false;

        [Display(Name = "مسددة")]
        public bool isPaied { get; set; } = false;



        public ICollection<PrintSignature>? PrintSignatures { get; set; }

        public ICollection<MachineProduction>? MachineProductions { get; set; }

        public ICollection<PrintOrderRequiredItem>? RequiredItems { get; set; }

        public ICollection<PrintOrderDelivery>? PrintOrderDeliveries { get; set; }
        public ICollection<PrintOrderCalimPayment>? PrintOrderPayments { get; set; }




    }
}
