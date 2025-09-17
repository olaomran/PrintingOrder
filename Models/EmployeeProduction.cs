namespace PrintingOrder.Models
{
    public class EmployeeProduction
    {
        public int Id { get; set; }
        public int MachineProductionId { get; set; }
        public MachineProduction MachineProduction { get; set; }


        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }


        // ممكن تخزين الوردية كقيمة مفصولة أو ككائن JSON
        public string? ShiftsJson { get; set; }
        // أرقام الملازم التي عمل عليها (قائمة أعداد صحيحة) نخزن كـ JSON
        public string? BookletNumbersJson { get; set; }


        public string? Notes { get; set; }
    }
}
