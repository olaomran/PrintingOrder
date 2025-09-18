namespace PrintingOrder.Models
{
    public class PrintSize : BaseEntity
    {
        PrintSize(int height, int width)
        {
            Name = height.ToString() + "×" + width.ToString();
            Height = height;
            Width = width;
        }

        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public ICollection<PrintOrder>? PrintOrders { get; set; }
    }
}
