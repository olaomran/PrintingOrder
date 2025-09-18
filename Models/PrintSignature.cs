using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    //ملزمة مطبوعة
    public class PrintSignature : BaseEntity
    {
        [Display(Name = "أمر الطباعة")]
        public int PrintOrderId { get; set; }
        public PrintOrder? PrintOrder { get; set; }


        [Display(Name = "رقم الملزمة")]
        public int SignatureOrder { get; set; }

        [Display(Name = "ملزمة كاملة")]
        public bool? WholeSignature { get; set; }

        //نصف ربع ثلث ..

        [Display(Name = "الجزء من الملزمة")]
        public decimal? SignaturePart { get; set; }


        [Display(Name = "عدد صفحات الملزمة")]

        public int? PagesCount { set; get; }



        [Display(Name = "الكمية المطلوبة ")]

        public int RequiredQuantity { set; get; }

        [Display(Name = "الكمية المنجزة ")]

        public int CompletedQuantity { set; get; }

        [Display(Name = "الكمية المتبقية ")]

        public int RemainingQuantity { set; get; }


        //قيد الطباعة , منتهية , لم تبدأ 
        [Display(Name = "الحالة")]
        public SignatureStatus SignatureStatus { get; set; } = SignatureStatus.NotStarted;


        public ICollection<MachineProduction>? MachineProductions { get; set; }


    }
}
