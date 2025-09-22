using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class EmployeeProduction:BaseEntity
    {
        public int? MachineProductionId { get; set; }
        public MachineProduction? MachineProduction { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }


        // ممكن تخزين الوردية كقيمة مفصولة أو ككائن JSON
        public string? Shifts { get; set; }
        //وجه وخلف ام وجه فقط

        [Display(Name = "طريقة الطباعة")]
        public SignaturePrintMechanism? SignaturePrintMechanismSignatureStatus { get; set; } = SignaturePrintMechanism.FaceAndBehind;

        public string? Notes { get; set; }

         public ICollection<EmployeeProductionDetail>? EmployeeProductionDetail { get; set; }    
    }
}
