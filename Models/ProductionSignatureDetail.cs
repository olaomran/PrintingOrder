using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class ProductionSignatureDetail:BaseEntity
    {

        public int MachineProductionId { get; set; }
        public MachineProduction MachineProduction { get; set; }
        public int PrintSignatureId { get; set; }
        public PrintSignature PrintSignature { get; set; }
        
        [Display(Name = "الكمية المنجزة")]
        public int PrintedQuantity { get; set; }



    }
}
