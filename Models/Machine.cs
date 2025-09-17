using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class Machine: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }


        public ICollection<MachineProduction>? MachineProductions { get; set; }
    }
}
