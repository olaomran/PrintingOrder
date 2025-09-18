using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrintingOrder.Data;
using PrintingOrder.Models;

namespace PrintingOrder.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ======================
        // تقرير قسم الطبع اليومي
        // ======================
        public async Task<IActionResult> Generate(DateTime? date)
        {
            var reportDate = date ?? DateTime.Today;

            
            // استرجاع الإنتاج لقسم الطبع لليوم
            var productions = await _context.MachineProductions
                .Include(p => p.Machine)
                .Include(p => p.PrintOrder)
                .Include(p => p.EmployeeProductions)
                    .ThenInclude(ep => ep.Employee)
                .Where(p => p.Section == ProductionSection.Print && p.ProductionDate.Date == reportDate.Date)
                .ToListAsync();

            var report = new DailyReport
            {
                ReportDate = reportDate,
                Items = productions
                    .GroupBy(p => p.Machine)
                    .Select(g => new DailyReportItem
                    {
                        MachineId = g.Key.Id,
                        Machine = g.Key,
                        TotalHours = (decimal?)g.Sum(p => p.Hours),
                        WorkedOrderNames = string.Join(", ", g.Select(p => p.PrintOrder.PrintName).Distinct()),
                        //ProducedCopiesPerOrderJson = System.Text.Json.JsonSerializer.Serialize(
                        //    g.GroupBy(p => p.PrintOrder.PrintName)
                        //     .ToDictionary(x => x.Key, x => x.Sum(p => p.ProducedCopies))
                        //)
                        //,
                        //ExecutorsWithShiftsJson = System.Text.Json.JsonSerializer.Serialize(
                        //    g.SelectMany(p => p.EmployeeProductions)
                        //     .Select(ep => new ExecutorViewModel
                        //     {
                        //         Employee = ep.Employee.FirstName + " " + ep.Employee.Nickname,
                        //         Shifts = ep.ShiftsJson,
                        //         Booklets = ep.BookletNumbersJson
                        //     }).ToList()
                        //),
                        AggregatedProductionNotes = string.Join(" | ", g.Where(p => !string.IsNullOrEmpty(p.Notes)).Select(p => p.Notes))
                    }).ToList()
            };

            _context.DailyReports.Add(report);
            await _context.SaveChangesAsync();

            return View("DailyReportTable", report);
        }

        // ======================
        // تقرير قسم التجليد اليومي
        // ======================
        public async Task<IActionResult> GenerateFoldingReport(DateTime? date)
        {
            var reportDate = date ?? DateTime.Today;

            // استرجاع الإنتاج لقسم التجليد لليوم 
            var productions = await _context.MachineProductions
                .Include(p => p.Machine)
                .Include(p => p.PrintOrder)
                .Include(p => p.EmployeeProductions)
                    .ThenInclude(ep => ep.Employee)
                .Where(p => p.Section == ProductionSection.Binding
                            && p.ProductionDate.Date == reportDate.Date
                            )
                .ToListAsync();

            var report = new DailyReport
            {
                ReportDate = reportDate,
                Items = productions
                    .GroupBy(p => p.Machine)
                    .Select(g => new DailyReportItem
                    {
                        MachineId = g.Key.Id,
                        Machine = g.Key,
                        TotalHours = (decimal?)g.Sum(p => p.Hours),
                        WorkedOrderNames = string.Join(", ", g.Select(p => p.PrintOrder.PrintName).Distinct()),
                        //ProducedCopiesPerOrderJson = System.Text.Json.JsonSerializer.Serialize(
                        //    g.GroupBy(p => p.PrintOrder.PrintName)
                        //     .ToDictionary(x => x.Key, x => x.Sum(p => p.ProducedCopies))
                        //),
                        //ExecutorsWithShiftsJson = System.Text.Json.JsonSerializer.Serialize(
                        //    g.SelectMany(p => p.EmployeeProductions)
                        //     .Select(ep => new ExecutorViewModel
                        //     {
                        //         Employee = ep.Employee.FirstName + " " + ep.Employee.Nickname,
                        //         Shifts = ep.ShiftsJson,
                        //         Booklets = ep.BookletNumbersJson
                        //     }).ToList()
                        //),
                        AggregatedProductionNotes = string.Join(" | ", g.Where(p => !string.IsNullOrEmpty(p.Notes)).Select(p => p.Notes))
                    }).ToList()
            };

            return View("DailyFoldingReportTable", report);
        }

        // ======================
        // حفظ ملاحظات مدير الإنتاج والحالة الفنية للآلة
        // ======================
        [HttpPost]
        public async Task<IActionResult> SaveManagerNotes(int reportId, string notes, Dictionary<int, string> machineStatuses)
        {
            var report = await _context.DailyReports
                .Include(r => r.Items)
                .FirstOrDefaultAsync(r => r.Id == reportId);

            if (report == null) return NotFound();

            report.ProductionManagerNotes = notes;

            foreach (var item in report.Items)
            {
                if (machineStatuses.ContainsKey(item.Id))
                {
                    item.MachineTechnicalStatus = machineStatuses[item.Id];
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Generate", new { date = report.ReportDate });
        }

        [HttpPost]
        public async Task<IActionResult> SaveManagerNotes2(int reportId, string notes, Dictionary<int, string> machineStatuses)
        {
            var report = await _context.DailyReports
                .Include(r => r.Items)
                .FirstOrDefaultAsync(r => r.Id == reportId);

            if (report == null) return NotFound();

            report.ProductionManagerNotes = notes;

            foreach (var item in report.Items)
            {
                if (machineStatuses.ContainsKey(item.Id))
                {
                    item.MachineTechnicalStatus = machineStatuses[item.Id];
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("GenerateFoldingReport", new { date = report.ReportDate });
        }
    }

    // ======================
    // Class لتسهيل التعامل مع JSON للمنفذين
    // ======================
    public class ExecutorViewModel
    {
        public string Employee { get; set; }
        public string Shifts { get; set; }
        public string Booklets { get; set; }
    }
}

