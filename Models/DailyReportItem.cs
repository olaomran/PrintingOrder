namespace PrintingOrder.Models
{
    public class DailyReportItem
    {
        public int Id { get; set; }
        public int DailyReportId { get; set; }
        public DailyReport DailyReport { get; set; }


        public int MachineId { get; set; }
        public Machine Machine { get; set; }


        public decimal? TotalHours { get; set; }
        public string? WorkedOrderNames { get; set; } // e.g. CSV or JSON of names
        public string? ProducedCopiesPerOrderJson { get; set; }
        public string? ExecutorsWithShiftsJson { get; set; }
        public string? AggregatedProductionNotes { get; set; }
        public string? MachineTechnicalStatus { get; set; }
    }
}
