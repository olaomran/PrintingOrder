using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrintingOrder.Data;
using PrintingOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PrintingOrder.Controllers
{
    public class MachineProductionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MachineProductionsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MachineProductions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MachineProductions.Include(m => m.Machine).Include(m => m.PrintOrder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MachineProductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineProduction = await _context.MachineProductions
                .Include(m => m.Machine)
                .Include(m => m.PrintOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (machineProduction == null)
            {
                return NotFound();
            }

            return View(machineProduction);
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewBag.Sections = Enum.GetValues(typeof(ProductionSection)).Cast<ProductionSection>();
            ViewBag.Machines = _context.Machines.ToList();
            ViewBag.Employees = _context.Employees.ToList();
            ViewBag.PrintOrders = _context.PrintOrders.ToList(); // سيتم فلترتها في JS حسب القسم
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MachineProduction production, string EmployeeDataJson)
        {
            var printOrder = await _context.PrintOrders.FindAsync(production.PrintOrderId);
            if (printOrder == null)
            {
                ModelState.AddModelError("PrintOrderId", "أمر الطباعة غير موجود");
                return View(production);
            }

            production.CreatorUserId = _userManager.GetUserId(User);

            if (production.Section == ProductionSection.Print)
            {
                // التحقق من الكبسات
                if (production.PressRuns > printOrder.RemainingPressRuns)
                {
                    ModelState.AddModelError("PressRuns", $"عدد الكبسات أكبر من المتبقي ({printOrder.RemainingPressRuns})");
                    return View(production);
                }

                // حساب عدد النسخ
                var machine = await _context.Machines.FindAsync(production.MachineId);
                if (machine.Name == "4 لون 70×100" || machine.Name == "4 لون 70×50")
                    production.ProducedCopies = (production.PressRuns * 8) / printOrder.PagesCount;
                else
                    production.ProducedCopies = (production.PressRuns * 16) / printOrder.PagesCount;

                // تحديث الكبسات المتبقية
                printOrder.RemainingPressRuns -= production.PressRuns;
                printOrder.CompletedPressRuns += production.PressRuns;
            }
            else if (production.Section == ProductionSection.Binding)
            {
                // التحقق من النسخ المجلدة
                var remaining = printOrder.CopiesCount - printOrder.FoldedCopies;
                if (production.ProducedCopies > remaining)
                {
                    ModelState.AddModelError("CopiesProduced", $"عدد النسخ أكبر من المتبقي ({remaining})");
                    ReloadViewBags();
                    return View(production);
                }

                // تحديث النسخ المجلدة
                printOrder.FoldedCopies += production.ProducedCopies;
            }

            _context.Add(production);
            await _context.SaveChangesAsync();

            // حفظ الموظفين المرتبطين
            if (!string.IsNullOrEmpty(EmployeeDataJson))
            {
                try
                {
                    var employees = JsonSerializer.Deserialize<List<EmployeeSelection>>(EmployeeDataJson);
                    if (employees != null)
                    {
                        foreach (var e in employees)
                        {
                            var ep = new EmployeeProduction
                            {
                                MachineProductionId = production.Id,
                                EmployeeId = e.EmployeeId,
                                ShiftsJson = string.Join(',', e.Shifts),
                                BookletNumbersJson = string.Join(',', e.Booklets)
                            };
                            _context.EmployeeProductions.Add(ep);

                        }
                        await _context.SaveChangesAsync();
                    }
                }

                catch (Exception ex)
                {
                    ModelState.AddModelError("", "خطأ في قراءة بيانات الموظفين: " + ex.Message);
                    ReloadViewBags();
                    return View(production);
                }
            }
            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// إعادة تحميل بيانات الـ ViewBag في حال حصل خطأ
        /// </summary>
        private void ReloadViewBags()
        {
            ViewBag.Sections = Enum.GetValues(typeof(ProductionSection)).Cast<ProductionSection>();
            ViewBag.Machines = _context.Machines.ToList();
            ViewBag.Employees = _context.Employees.ToList();
            ViewBag.PrintOrders = _context.PrintOrders.ToList();
        }
        // GET: MachineProductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineProduction = await _context.MachineProductions.FindAsync(id);
            if (machineProduction == null)
            {
                return NotFound();
            }
            ViewData["MachineId"] = new SelectList(_context.Machines, "Id", "Name", machineProduction.MachineId);
            ViewData["PrintOrderId"] = new SelectList(_context.PrintOrders, "Id", "ContractNumber", machineProduction.PrintOrderId);
            return View(machineProduction);
        }

        // POST: MachineProductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrintOrderId,MachineId,Section,ProductionDate,Hours,PressRuns,ProducedCopies,Notes,Id,CreatedAt,CreatorUserId")] MachineProduction machineProduction)
        {
            if (id != machineProduction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineProduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineProductionExists(machineProduction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MachineId"] = new SelectList(_context.Machines, "Id", "Name", machineProduction.MachineId);
            ViewData["PrintOrderId"] = new SelectList(_context.PrintOrders, "Id", "ContractNumber", machineProduction.PrintOrderId);
            return View(machineProduction);
        }

        // GET: MachineProductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineProduction = await _context.MachineProductions
                .Include(m => m.Machine)
                .Include(m => m.PrintOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (machineProduction == null)
            {
                return NotFound();
            }

            return View(machineProduction);
        }

        // POST: MachineProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machineProduction = await _context.MachineProductions.FindAsync(id);
            if (machineProduction != null)
            {
                _context.MachineProductions.Remove(machineProduction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineProductionExists(int id)
        {
            return _context.MachineProductions.Any(e => e.Id == id);
        }
    }


    public class EmployeeSelection
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public bool Selected { get; set; } // هل اختار الموظف
        public List<string> Shifts { get; set; } = new List<string>(); // الأولى، الثانية، الثالثة، إضافي
        public List<int> Booklets { get; set; } = new List<int>(); // أرقام الملازم التي عمل عليها
    }
}
