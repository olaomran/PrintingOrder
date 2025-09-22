using System.ComponentModel;

namespace PrintingOrder.Models
{
    public class EmployeeProductionDetail:BaseEntity
    {

        public int EmployeeProductionId { get; set; }
        public EmployeeProduction EmployeeProduction { get; set; }

        public int? BookSignatureId { get; set; }
        public PrintSignature? PrintSignature { get; set; }

        [DisplayName("الكمية المنجزة")]
        public int? PrintedQuantity { get; set; } // الكمية المطبوعة
        
    }
}
