using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public enum MachineType { RollV30, RollV25, Offset8Color, Offset4Color }
    public enum ProductionSection
    {
        Print,
        Binding,
        CTP,
        Montage
    }
    public enum ShiftType { First, Second, Third, Extra }

    
    public enum SignatureStatus { NotStarted ,Pending, Done }


    public enum PrintOrderType { Commerical, School}

    public enum PrintOrderLevel {
        [Display(Name = "لم يبدأ")]
        NotStarted ,
        [Display(Name = "طور الطباعة")]
        Printing,
        [Display(Name = "طور التجليد")]
        Binding,
        [Display(Name = "طور الطباعة والتجليد")]
        PrintingAndBinding,
        [Display(Name = "في المستودع")]
        DeliveredToStore,
        [Display(Name = "مطالب")] 
        Claimed,
        [Display(Name = "مسدد")]
        Paid,
        [Display(Name = "مسدد جزئياً")]
        PartiallyPaid }
    public class EnumTypes
    {
    }
}
