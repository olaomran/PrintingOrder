namespace PrintingOrder.Models
{
    public class DailyReport : BaseEntity
    {
        public DateTime? ReportDate { get; set; }
        public string? ProductionManagerNotes { get; set; }
        public ICollection<DailyReportItem>? Items { get; set; }
    }
}
