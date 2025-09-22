using PrintingOrder.Models;

namespace PrintingOrder.ViewModels
{
    public class PrintOrderIndexVM
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public string PrintName { get; set; }
        public PrintOrderType PrintType { get; set; } // School, Commercial
        public string CustomerName { get; set; }
        public string PrintSizeName { get; set; }
        public string DelegateName { get; set; }


        public int TotalPressRuns { get; set; }
        public int CompletedPressRuns { get; set; }
        public int RemainingPressRuns { get; set; }

        public int FoldedCopies { get; set; }
        public int DeliveriedCopiesToStore { get; set; }


        public PrintOrderLevel Levels { get; set; } 
    }
}
