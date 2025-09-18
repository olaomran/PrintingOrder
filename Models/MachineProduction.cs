namespace PrintingOrder.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MachineProduction : BaseEntity
    {
        [Display(Name = "أمر الطباعة")]
        public int PrintOrderId { get; set; }
        public PrintOrder? PrintOrder { get; set; }


        [Display(Name = "الآلة")]
        public int MachineId { get; set; }
        public Machine? Machine { get; set; }

        
        [Display(Name = "القسم")]
        public ProductionSection Section { get; set; } = ProductionSection.Print;

        [Display(Name = "تاريخ تسليم الإنتاج")]
        public DateTime ProductionDate { get; set; } = DateTime.Today;

        [Display(Name = "مدة الإنتاج بالساعات")]
        public decimal Hours { get; set; }

        [Display(Name = "عدد الكبسات")]
        public int PressRuns { get; set; }

        //[Display(Name = "كمية النسخ")]
        //public int ProducedCopies { get; set; }

        [Display(Name = "الموظفين المنفذين")]
        public ICollection<EmployeeProduction>? EmployeeProductions { get; set; }

        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

        
    }

}
