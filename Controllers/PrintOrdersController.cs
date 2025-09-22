using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PrintingOrder.Data;
using PrintingOrder.Helper;
using PrintingOrder.Models;
using PrintingOrder.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrintingOrder.Controllers
{
    public class PrintOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        private const string DefaultSchoolCustomerName = "المؤسسة العامة للطباعة";

        //  هنا يتم حقن UserManager تلقائياً من الـ services

        public PrintOrdersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //// GET: PrintOrders
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.PrintOrders.ToListAsync());
        //}

        public IActionResult Index(
            string printType,
            int? customerId,
            int? printSizeId,
            int? delegateId,
            string level,
            string printName,
            string orderNumber,
            DateTime? fromDate,
            DateTime? toDate,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var statuses = Enum.GetValues(typeof(PrintOrderLevel))
                   .Cast<PrintOrderLevel>()
                   .Select(e => new SelectListItem
                   {
                       Value = e.ToString(),
                       Text = e.GetDisplayName()
                   })
                   .ToList();

            ViewBag.Statuses = statuses;

            var query = _context.PrintOrders
                               .Include(p => p.Customer)
                               .Include(p => p.Delegate)
                               .Include(p => p.Size)
                .AsQueryable();


            if (!string.IsNullOrEmpty(printType))
            {
                if (Enum.TryParse<PrintOrderType>(printType, out var typeValue))
                {
                    query = query.Where(o => o.PrintOrderType == typeValue);
                }
                else
                {
                    query = query.Where(o => o.PrintOrderType == typeValue);
                }
            }

            if (customerId.HasValue)
                query = query.Where(o => o.CustomerId == customerId);

            if (printSizeId.HasValue)
                query = query.Where(o => o.PrintSizeId == printSizeId);

            if (delegateId.HasValue)
                query = query.Where(o => o.DelegateId == delegateId);

            if (!string.IsNullOrEmpty(level))
            {
                if (Enum.TryParse<PrintOrderLevel>(level, out var levelValue))
                {
                    query = query.Where(o => o.PrintOrderLevel == levelValue);
                }
            }

            if (!string.IsNullOrEmpty(printName))
                query = query.Where(o => o.PrintName.Contains(printName));


            if (!string.IsNullOrEmpty(orderNumber))
                query = query.Where(o => o.OrderNumber.Contains(orderNumber));

            if (fromDate.HasValue)
                query = query.Where(o => o.Date >= fromDate);

            if (toDate.HasValue)
                query = query.Where(o => o.Date <= toDate);

            var result = query
         .OrderByDescending(o => o.Date)
         .Select(o => new PrintOrderIndexVM
         {
             Id = o.Id,
             OrderNumber = o.OrderNumber,
             Date = o.Date,
             PrintName = o.PrintName,
             PrintType = o.PrintOrderType,
             CustomerName = o.Customer != null ? o.Customer.Name : "",
             PrintSizeName = o.PrintSizeId != null ? o.Size.Name : "",
             DelegateName = o.DelegateId != null ? o.Delegate.FirstName + " " + o.Delegate.Nickname : "",
             Levels = o.PrintOrderLevel,
             TotalPressRuns = o.TotalPressRuns,
             RemainingPressRuns = o.RemainingPressRuns,
             CompletedPressRuns = o.CompletedPressRuns,
             FoldedCopies = o.FoldedCopies,
             DeliveriedCopiesToStore = o.DeliveriedCopiesToStore
         }).ToList();

            var pagedResult = PaginatedList<PrintOrderIndexVM>.Create(result, pageNumber, pageSize);

            ViewBag.Customers = new SelectList(_context.Customers, "Id", "Name");
            ViewBag.PrintSizes = new SelectList(_context.PrintSizes, "Id", "Name");
            ViewBag.Delegates = new SelectList(_context.Delegates, "Id", "FirstName");

            return View(pagedResult);
        }


        // GET: PrintOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var printOrder = await _context.PrintOrders
                               .Include(p => p.Customer)
                               .Include(p => p.Delegate)
                               .Include(p => p.Size)
                               .Include(p => p.PrintSignatures)
                               .Include(p => p.RequiredItems)
                                   .ThenInclude(ri => ri.Item)
                                       .ThenInclude(i => i.Category)
                                           .ThenInclude(c => c.Store)
                               .FirstOrDefaultAsync(p => p.Id == id);

            if (printOrder == null)
            {
                return NotFound();
            }

            return View(printOrder);
        }

        [HttpGet]
        public IActionResult CreateSchool()
        {
            // جلب قياسات النموذج من قاعدة البيانات
            var sizes = _context.PrintSizes.ToList();

            ViewBag.PrintSizes = sizes;

            ViewBag.Stores = new SelectList(_context.Stores, "Id", "Name");

            return View(new SchoolPrintOrderCreateVM());


        }

        [HttpGet]
        public IActionResult Create()
        {
            // جلب قياسات النموذج من قاعدة البيانات
            var sizes = _context.PrintSizes.ToList();

            ViewBag.PrintSizes = sizes;

            ViewBag.Stores = new SelectList(_context.Stores, "Id", "Name");
            ViewBag.Customers = new SelectList(_context.Customers, "Id", "Name");
            ViewBag.Delegates = new SelectList(_context.Delegates, "Id", "FirstName");

            return View(new SchoolPrintOrderCreateVM());


        }



        [HttpPost]
        public async Task<IActionResult> CreateSchoolAsync(SchoolPrintOrderCreateVM vm, string RequiredItemsJson)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Stores = new SelectList(_context.Stores, "Id", "Name");
                return View(vm);
            }
            else
            {
                // التأكد من وجود "المؤسسة العامة للطباعة"
                var customer = _context.Customers
                    .FirstOrDefault(c => c.Name == "المؤسسة العامة للطباعة");
                if (customer == null)
                {
                    customer = new Customer { Name = "المؤسسة العامة للطباعة" };
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                }

                // الحسابات
                vm.PrintSignatureCount = Math.Round((decimal)vm.PagesCount / 16, 2);
                vm.TotalPrintSignatureCount = Math.Round(vm.PrintSignatureCount * vm.CopiesCount, 2);
                vm.TotalPressRuns = (int)Math.Ceiling(vm.TotalPrintSignatureCount);

                // توليد جدول الملازم
                vm.Signatures = GenerateSignatures(vm.PrintSignatureCount, vm.CopiesCount);

                // إنشاء PrintOrder
                var order = new PrintOrder
                {
                    PrintOrderType = PrintOrderType.School,
                    OrderNumber = vm.OrderNumber,
                    PrintName = vm.PrintName,
                    Date = vm.Date,
                    ContractNumber = vm.ContractNumber,
                    OrderYear = vm.OrderYear,
                    IntryNumber = vm.IntryNumber,
                    IntryDate = vm.IntryDate,
                    PartyBookNumber = vm.PartyBookNumber,
                    PartyBookDate = vm.PartyBookDate,
                    AgreedDeliveryDate = vm.AgreedDeliveryDate,
                    CustomerId = customer.Id,
                    DelegateId = vm.DelegateId,
                    CopiesCount = vm.CopiesCount,
                    PagesCount = vm.PagesCount,
                    PrintSignatureCount = vm.PrintSignatureCount,
                    TotalPrintSignatureCount = vm.TotalPrintSignatureCount,
                    TotalPressRuns = vm.TotalPressRuns,
                    RemainingPressRuns = vm.TotalPressRuns,
                    CompletedPressRuns = 0,
                    PrintSizeId = vm.PrintSizeId
                };

                order.PrintSignatures = vm.Signatures.Select(s => new PrintSignature
                {
                    SignatureOrder = s.SignatureOrder,
                    WholeSignature = s.WholeSignature,
                    SignaturePart = s.SignaturePart,
                    RequiredQuantity = s.RequiredQuantity,
                    RemainingQuantity = s.RequiredQuantity
                }).ToList();

                _context.PrintOrders.Add(order);
                await _context.SaveChangesAsync();


                var items = JsonConvert.DeserializeObject<List<RequiredItemVM>>(RequiredItemsJson);

                // حفظ المواد المطلوبة
                foreach (var it in items)
                {
                    _context.PrintOrderRequiredItems.Add(new PrintOrderRequiredItem
                    {
                        PrintOrderId = order.Id,
                        ItemId = it.ItemId,
                        RequiredAmount = it.RequiredAmount
                    });
                }
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { id = order.Id });
            }

        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(SchoolPrintOrderCreateVM vm, string RequiredItemsJson)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Stores = new SelectList(_context.Stores, "Id", "Name");
                return View(vm);
            }
            else
            {

                // الحسابات
                vm.PrintSignatureCount = Math.Round((decimal)vm.PagesCount / 16, 2);
                vm.TotalPrintSignatureCount = Math.Round(vm.PrintSignatureCount * vm.CopiesCount, 2);
                vm.TotalPressRuns = (int)Math.Ceiling(vm.TotalPrintSignatureCount);

                // توليد جدول الملازم
                vm.Signatures = GenerateSignatures(vm.PrintSignatureCount, vm.CopiesCount);

                // إنشاء PrintOrder
                var order = new PrintOrder
                {
                    PrintOrderType = PrintOrderType.School,
                    OrderNumber = vm.OrderNumber,
                    PrintName = vm.PrintName,
                    Date = vm.Date,
                    ContractNumber = vm.ContractNumber,
                    OrderYear = vm.OrderYear,
                    IntryNumber = vm.IntryNumber,
                    IntryDate = vm.IntryDate,
                    PartyBookNumber = vm.PartyBookNumber,
                    PartyBookDate = vm.PartyBookDate,
                    AgreedDeliveryDate = vm.AgreedDeliveryDate,
                    CustomerId = vm.CustomerId,
                    DelegateId = vm.DelegateId,
                    CopiesCount = vm.CopiesCount,
                    PagesCount = vm.PagesCount,
                    PrintSignatureCount = vm.PrintSignatureCount,
                    TotalPrintSignatureCount = vm.TotalPrintSignatureCount,
                    TotalPressRuns = vm.TotalPressRuns,
                    RemainingPressRuns = vm.TotalPressRuns,
                    CompletedPressRuns = 0,
                    PrintSizeId = vm.PrintSizeId
                };

                order.PrintSignatures = vm.Signatures.Select(s => new PrintSignature
                {
                    SignatureOrder = s.SignatureOrder,
                    WholeSignature = s.WholeSignature,
                    SignaturePart = s.SignaturePart,
                    RequiredQuantity = s.RequiredQuantity,
                    RemainingQuantity = s.RequiredQuantity
                }).ToList();

                _context.PrintOrders.Add(order);
                await _context.SaveChangesAsync();


                var items = JsonConvert.DeserializeObject<List<RequiredItemVM>>(RequiredItemsJson);

                // حفظ المواد المطلوبة
                foreach (var it in items)
                {
                    _context.PrintOrderRequiredItems.Add(new PrintOrderRequiredItem
                    {
                        PrintOrderId = order.Id,
                        ItemId = it.ItemId,
                        RequiredAmount = it.RequiredAmount
                    });
                }
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { id = order.Id });
            }

        }

        private List<SignatureRowVM> GenerateSignatures(decimal signatureCount, int copies)
        {
            var rows = new List<SignatureRowVM>();
            int full = (int)Math.Floor(signatureCount);
            decimal fraction = signatureCount - full;

            for (int i = 1; i <= full; i++)
            {
                rows.Add(new SignatureRowVM
                {
                    SignatureOrder = i,
                    WholeSignature = true,
                    SignaturePart = 1,
                    RequiredQuantity = copies
                });
            }

            if (fraction > 0)
            {
                rows.Add(new SignatureRowVM
                {
                    SignatureOrder = full + 1,
                    WholeSignature = false,
                    SignaturePart = fraction,
                    RequiredQuantity = copies
                });
            }
            return rows;
        }

        [HttpPost]
        public IActionResult CalculateSignatures([FromBody] SchoolPrintOrderCreateVM vm)
        {
            if (vm.CopiesCount <= 0 || vm.PagesCount <= 0)
                return Json(new { success = false, message = "الرجاء إدخال عدد الصفحات والنسخ" });

            // إذا المستخدم لم يُدخل قيمة يدوية → نحسب تلقائياً
            decimal signatureCount = vm.ManualSignatureCount ?? Math.Round((decimal)vm.PagesCount / 16, 2);

            var totalSignatures = signatureCount * vm.CopiesCount;
            var totalPress = (int)Math.Ceiling(totalSignatures);

            var signatures = GenerateSignatures(signatureCount, vm.CopiesCount);

            return Json(new
            {
                success = true,
                signatureCount,
                totalSignatures,
                totalPress,
                signatures
            });
        }


        // GET: Create page
        //public async Task<IActionResult> CreateSchoolPO()
        //{
        //    var vm = new CreatePrintOrderViewModel
        //    {
        //        Date = DateTime.Today,
        //    };

        //    // populate selects
        //    vm.Sizes = await _context.PrintSizes
        //                  .Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = s.Id.ToString(), Text = s.Name })
        //                  .ToListAsync();

        //    vm.Delegates = await _context.Delegates
        //                     .Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = d.Id.ToString(), Text = d.FirstName +" "+ d.Nickname })
        //                     .ToListAsync();

        //    vm.Stores = await _context.Stores
        //                   .Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = s.Id.ToString(), Text = s.Name })
        //                   .ToListAsync();

        //    vm.Categoris = await _context.Categories
        //                .Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = i.Id.ToString(), Text = i.Name })
        //                .ToListAsync();

        //    vm.Items = await _context.Items
        //                 .Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = i.Id.ToString(), Text = i.Name })
        //                 .ToListAsync();

        //    return View(vm);
        //}

        // POST: Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateSchoolPO(CreatePrintOrderViewModel vm)
        //{
        //    var errors = ModelState.Values.SelectMany(v => v.Errors);

        //    if (!ModelState.IsValid)
        //    {
        //        // re-populate selects
        //        vm.Sizes = await _context.PrintSizes.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToListAsync();
        //        vm.Delegates = await _context.Delegates.Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = d.Id.ToString(), Text = d.FirstName+" "+ d.Nickname }).ToListAsync();
        //        vm.Stores = await _context.Stores.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToListAsync();
        //        vm.Categoris = await _context.Categories.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToListAsync();
        //        vm.Items = await _context.Items.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToListAsync();
        //        return View(vm);
        //    }

        //    using var tx = await _context.Database.BeginTransactionAsync();
        //    try
        //    {
        //        // ensure customer exists
        //        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Name == DefaultSchoolCustomerName);
        //        if (customer == null)
        //        {
        //            customer = new Customer { Name = DefaultSchoolCustomerName };
        //            _context.Customers.Add(customer);
        //            await _context.SaveChangesAsync();
        //        }

        //        // Build PrintOrder
        //        var po = new PrintOrder
        //        {
        //            OrderNumber = vm.OrderNumber.ToString(),
        //            Date = vm.Date,
        //            PrintName = vm.PrintName,
        //            ContractNumber = vm.ContractNumber,
        //            OrderYear = vm.Date.Year.ToString(),
        //            CustomerId = customer.Id,
        //            DelegateId = vm.DelegateId,
        //            CopiesCount = vm.CopiesCount,
        //            PagesCount = vm.PagesCount,
        //            PrintSizeId = vm.PrintSizeId,
        //            IntryNumber = vm.IntryNumber,
        //            IntryDate = vm.IntryDate,
        //            PartyBookNumber = vm.PartyBookNumber,
        //            PartyBookDate = vm.PartyBookDate,
        //            AgreedDeliveryDate = vm.AgreedDeliveryDate,
        //            PrintSignatureCount = vm.PrintSignatureCount,
        //            TotalPrintSignatureCount = vm.TotalPrintSignatureCount,
        //            TotalPressRuns = vm.TotalPressRuns,
        //            RemainingPressRuns = vm.TotalPressRuns,
        //            CompletedPressRuns = 0,
        //            FoldedCopies = 0,
        //            DeliveriedCopiesToStore = 0,
        //            PrintOrderLevel = PrintOrderLevel.NotStarted,
        //            Notes = "" // optional
        //        };

        //        _context.PrintOrders.Add(po);
        //        await _context.SaveChangesAsync();

        //        // Create PrintSignature rows according to vm.SignatureRows
        //        if (vm.SignatureRows != null)
        //        {
        //            foreach (var row in vm.SignatureRows)
        //            {
        //                var sig = new PrintSignature
        //                {
        //                    PrintOrderId = po.Id,
        //                    SignatureOrder = row.SignatureOrder,
        //                    WholeSignature = row.WholeSignature,
        //                    SignaturePart = row.SignaturePart,
        //                    PagesCount = row.PagesCount,
        //                    RequiredQuantity = row.RequiredQuantity,
        //                    CompletedQuantity = 0,
        //                    RemainingQuantity = row.RequiredQuantity,
        //                    SignatureStatus = SignatureStatus.NotStarted
        //                };
        //                _context.PrintSignatures.Add(sig);
        //            }
        //            await _context.SaveChangesAsync();
        //        }

        //        // Save required items (TempConsumedItems) as PrintOrderRequiredItem
        //        if (vm.TempConsumedItems != null && vm.TempConsumedItems.Any())
        //        {
        //            foreach (var t in vm.TempConsumedItems)
        //            {
        //                if (t.ItemId.HasValue)
        //                {
        //                    var req = new PrintOrderRequiredItem
        //                    {
        //                        PrintOrderId = po.Id,
        //                        ItemId = t.ItemId.Value,
        //                        RequiredAmount = t.Amount
        //                    };
        //                    _context.PrintOrderRequiredItems.Add(req);
        //                }
        //            }
        //            await _context.SaveChangesAsync();
        //        }

        //        await tx.CommitAsync();
        //        return RedirectToAction("Details", new { id = po.Id });
        //    }
        //    catch (Exception ex)
        //    {
        //        await tx.RollbackAsync();
        //        ModelState.AddModelError("", "حدث خطأ أثناء الحفظ: " + ex.Message);
        //        // re-populate selects
        //        vm.Sizes = await _context.PrintSizes.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToListAsync();
        //        vm.Delegates = await _context.Delegates.Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = d.Id.ToString(), Text = d.Nickname }).ToListAsync();
        //        vm.Stores = await _context.Stores.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToListAsync();
        //        vm.Categoris = await _context.Items.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToListAsync();
        //        vm.Items = await _context.Items.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToListAsync();
        //        return View(vm);
        //    }
        //}



        /// <summary>
        /// تحميل القوائم المنسدلة
        /// </summary>
        private void LoadDropDowns()
        {
            ViewBag.Sizes = new SelectList(_context.PrintSizes, "Id", "Name");
            ViewBag.Delegates = new SelectList(_context.Delegates, "Id", "FullName");
            // مستودعات + أقسام + مواد + واحدات
            ViewBag.Stores = new SelectList(_context.Stores, "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.Items = new SelectList(_context.Items, "Id", "Name");
            ViewBag.Units = new SelectList(_context.Units, "Id", "Name");
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesByStore(int storeId)
        {

            var categories = await _context.Categories
                .Where(c => c.StoreId == storeId)
                .Select(c => new { id = c.Id, name = c.Name })
                .ToListAsync();

            return Json(categories);
        }

        [HttpGet]
        public async Task<IActionResult> GetItemsByCategory(int categoryId)
        {
            var items = await _context.Items
                .Where(i => i.CategoryId == categoryId)
                .Select(i => new { id = i.Id, name = i.Name })
                .ToListAsync();

            return Json(items);
        }

        //public IActionResult Details(int id)
        //{
        //    var order = _context.PrintOrders
        //        .Where(o => o.Id == id)
        //        .Select(o => o) // include nav props as needed
        //        .FirstOrDefault();

        //    if (order == null) return NotFound();
        //    return View(order);
        //}

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
                    //CalculateFields(printOrder);
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


        public IActionResult ExportToExcel(
            string printType,
            int? customerId,
            int? printSizeId,
            int? delegateId,
            string level,
            string printName,
            string orderNumber,
            DateTime? fromDate,
            DateTime? toDate)
        {
            // نفس الفلترة الموجودة في Index
            var query = _context.PrintOrders
                                .Include(p => p.Customer)
                                .Include(p => p.Delegate)
                                .Include(p => p.Size)
                                .AsQueryable();


            if (!string.IsNullOrEmpty(printType))
            {
                if (Enum.TryParse<PrintOrderType>(printType, out var parsedType))
                {
                    query = query.Where(o => o.PrintOrderType == parsedType);
                }
                else
                {
                    query = query.Where(o => o.PrintOrderType == parsedType);
                }
            }

            if (customerId.HasValue)
                query = query.Where(o => o.CustomerId == customerId);

            if (printSizeId.HasValue)
                query = query.Where(o => o.PrintSizeId == printSizeId);

            if (delegateId.HasValue)
                query = query.Where(o => o.DelegateId == delegateId);

            if (!string.IsNullOrEmpty(level))
            {
                if (Enum.TryParse<PrintOrderLevel>(level, out var parsedLevel))
                    query = query.Where(o => o.PrintOrderLevel == parsedLevel);
            }

            if (!string.IsNullOrEmpty(printName))
                query = query.Where(o => o.PrintName.Contains(printName));

            if (!string.IsNullOrEmpty(orderNumber))
                query = query.Where(o => o.OrderNumber.Contains(orderNumber));

            if (fromDate.HasValue)
                query = query.Where(o => o.Date >= fromDate);

            if (toDate.HasValue)
                query = query.Where(o => o.Date <= toDate);

            var orders = query.OrderByDescending(o => o.Date).ToList();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("أوامر التشغيل");
            var currentRow = 1;

            // الهيدر
            worksheet.Cell(currentRow, 1).Value = "رقم الأمر";
            worksheet.Cell(currentRow, 2).Value = "التاريخ";
            worksheet.Cell(currentRow, 3).Value = "اسم المطبوعة";
            worksheet.Cell(currentRow, 4).Value = "نوع المطبوعة";
            worksheet.Cell(currentRow, 5).Value = "العائدية";
            worksheet.Cell(currentRow, 6).Value = "القياس";
            worksheet.Cell(currentRow, 7).Value = "المندوب";
            worksheet.Cell(currentRow, 8).Value = "المرحلة";
            worksheet.Cell(currentRow, 9).Value = "الكبسات المطلوبة";
            worksheet.Cell(currentRow, 10).Value = "الكبسات المنجزة";
            worksheet.Cell(currentRow, 11).Value = "الكبسات المتبقية";
            worksheet.Cell(currentRow, 12).Value = "النسخ المجلدة";
            worksheet.Cell(currentRow, 13).Value = "المسلمة للمستودع";

            // البيانات
            foreach (var o in orders)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = o.OrderNumber;
                worksheet.Cell(currentRow, 2).Value = o.Date.ToString("yyyy-MM-dd");
                worksheet.Cell(currentRow, 3).Value = o.PrintName;
                worksheet.Cell(currentRow, 4).Value = o.PrintOrderType == PrintOrderType.School ? "مدرسي" : "تجاري";
                worksheet.Cell(currentRow, 5).Value = o.Customer?.Name;
                worksheet.Cell(currentRow, 6).Value = o.Size?.Name;
                worksheet.Cell(currentRow, 7).Value = o.Delegate?.FirstName + " " + o.Delegate?.Nickname;
                worksheet.Cell(currentRow, 8).Value = o.PrintOrderLevel.GetDisplayName();

                // 🔹 القيم الجديدة
                worksheet.Cell(currentRow, 9).Value = o.TotalPressRuns;
                worksheet.Cell(currentRow, 10).Value = o.CompletedPressRuns;
                worksheet.Cell(currentRow, 11).Value = o.RemainingPressRuns;
                worksheet.Cell(currentRow, 12).Value = o.FoldedCopies;
                worksheet.Cell(currentRow, 13).Value = o.DeliveriedCopiesToStore;


            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();
            return File(content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"PrintOrders_{DateTime.Now:yyyyMMddHHmmss}.xlsx");
        }

    }
}
