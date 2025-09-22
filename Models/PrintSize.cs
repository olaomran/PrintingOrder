namespace PrintingOrder.Models
{
    public class PrintSize : BaseEntity
    {
        PrintSize(decimal height, decimal width)
        {
            Name = height.ToString() + "×" + width.ToString();
            Height = height;
            Width = width;
        }

        public string Name { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }

        public ICollection<PrintOrder>? PrintOrders { get; set; }
    }
}
