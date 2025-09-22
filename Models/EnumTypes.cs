using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public enum MachineType {

        [Display(Name = "الأوفست")]
        Offset,
        [Display(Name = "الرول")]
        Role,
        [Display(Name = "الريزو")]
        Rizo,
        [Display(Name = "التيبو")]
        Tipo,
        [Display(Name = "التجليد")]
        Folding
    }
    public enum ProductionSection
    {
        Print,
        Binding,
        CTP,
        Montage
    }
    public enum ShiftType { First, Second, Third, Extra }

    
    public enum SignatureStatus { NotStarted ,Pending, Done }

    public enum SignaturePrintMechanism 
    {
        [Display(Name = "وجه وخلف")]
        FaceAndBehind,
        [Display(Name = "وجه فقط")]
        OnlyFace
    }


    public enum PrintOrderType {Commerical, School}

    public enum PrintOrderLevel {
        [Display(Name = "لم يبدأ")]
        NotStarted ,
        [Display(Name = "طور الطباعة")]
        Printing,
        [Display(Name = "تم الطبع")]
        PrintingDone,
        [Display(Name = "طور التجليد")]
        Binding,
        [Display(Name = "تم التجليد")]
        BindingDone,
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
