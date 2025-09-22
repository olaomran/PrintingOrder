namespace PrintingOrder.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class MachineProduction : BaseEntity
    {
        [Display(Name = "أمر التشغيل")]
        public int PrintOrderId { get; set; }
        public PrintOrder? PrintOrder { get; set; }

        [Display(Name = "القسم")]
        public ProductionSection Section { get; set; } = ProductionSection.Print;

        [Display(Name = "الآلة")]
        public int? MachineId { get; set; }
        public Machine? Machine { get; set; }


        [Display(Name = "تاريخ تسليم الإنتاج")]
        public DateTime ProductionDate { get; set; } = DateTime.Today;

        [Display(Name = "مدة الإنتاج بالساعات")]
        public decimal Hours { get; set; }

        [Display(Name = "عدد الكبسات")]
        public int PressRuns { get; set; }


        //عدد النسخ المجلدة في حال القسم المنفذ هو قسم التجليد 
        [Display(Name = "عدد النسخ المجلدة ")]
        public int FoldedCopies { get; set; } 



        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }


        [Display(Name = "الموظفين المنفذين")]
        public ICollection<EmployeeProduction>? EmployeeProductions { get; set; }

        [Display(Name = "الملازم المنجزة وكمياتها")]

        public ICollection<ProductionSignatureDetail>? ProductionSignatureList { get; set; }



        [Display(Name = "الكميات المستهلكة")]
        public ICollection<ProductionConsumedItem>? ProductionConsumedItems { get; set; }

        
    }

}
