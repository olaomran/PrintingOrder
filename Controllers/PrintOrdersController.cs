using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrintingOrder.Data;
using PrintingOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintingOrder.Controllers
{
    public class PrintOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        //  هنا يتم حقن UserManager تلقائياً من الـ services
        
        public PrintOrdersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: PrintOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrintOrders.ToListAsync());
        }

        // GET: PrintOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printOrder = await _context.PrintOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (printOrder == null)
            {
                return NotFound();
            }

            return View(printOrder);
        }

        // GET: PrintOrders/Create
        public IActionResult Create()
        {
            return View();
        }


        private void CalculateFields(PrintOrder order)
        {
           
            order.TotalBooklets = (order.PagesCount / 16) * order.CopiesCount;

            
            if (order.MachineType == MachineType.Offset4Color)
            {
                // Offset4Color
                order.TotalPressRuns = order.TotalBooklets / 2;
            }
            else
            {
                order.TotalPressRuns = order.TotalBooklets;
            }

            // initial values
            order.RemainingPressRuns = order.TotalPressRuns;
            order.CompletedPressRuns = 0;
        }

        // POST: PrintOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineType,PrintName,Date,ContractNumber,OrderNumber,CopiesCount,PagesCount,TotalBooklets,TotalPressRuns,RemainingPressRuns,CompletedPressRuns,Size,Notes,Details,Id,CreatedAt,CreatorUserId")] PrintOrder printOrder)
        {
            CalculateFields(printOrder);
            printOrder.CreatedAt = DateTime.UtcNow;
            printOrder.CreatorUserId = "0db47d90-f010-470a-b2b3-60193dac4396";// _userManager.GetUserId(User); 


            if (ModelState.IsValid)
            {
                _context.Add(printOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(printOrder);
        }

        // GET: PrintOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printOrder = await _context.PrintOrders.FindAsync(id);
            if (printOrder == null)
            {
                return NotFound();
            }
            return View(printOrder);
        }

        // POST: PrintOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineType,PrintName,Date,ContractNumber,OrderNumber,CopiesCount,PagesCount,TotalBooklets,TotalPressRuns,RemainingPressRuns,CompletedPressRuns,Size,Notes,Details,Id,CreatedAt,CreatorUserId")] PrintOrder printOrder)
        {
            if (id != printOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CalculateFields(printOrder);
                    _context.Update(printOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrintOrderExists(printOrder.Id))
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
            return View(printOrder);
        }

        // GET: PrintOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printOrder = await _context.PrintOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (printOrder == null)
            {
                return NotFound();
            }

            return View(printOrder);
        }

        // POST: PrintOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var printOrder = await _context.PrintOrders.FindAsync(id);
            if (printOrder != null)
            {
                _context.PrintOrders.Remove(printOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrintOrderExists(int id)
        {
            return _context.PrintOrders.Any(e => e.Id == id);
        }
    }
}
