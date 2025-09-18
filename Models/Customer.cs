using Microsoft.Build.Framework;

namespace PrintingOrder.Models
{
    public class Customer: BaseEntity
    {

        [Required]
        public string Name { get; set; }
        public string? Notes { get; set; }

        public ICollection<PrintOrder>? PrintingOrders { get; set; }
    }
}
