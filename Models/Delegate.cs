using System.ComponentModel.DataAnnotations;

namespace PrintingOrder.Models
{
    public class Delegate:BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Nickname { get; set; }
        public string? FatherName { get; set; }
        public string Notes { get; set; }


        public ICollection<PrintOrder>? PrintOrders { get; set; }
    }
}
