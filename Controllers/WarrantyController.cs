using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sproject.Data;
using sproject.Models;

namespace sproject.Controllers
{
    public class WarrantyController : Controller
    {
        private readonly MyDbContext _context;

        public WarrantyController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Warranty
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Warranties.Include(w => w.customerOrder);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Warranty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warranty = await _context.Warranties
                .Include(w => w.customerOrder)
                .FirstOrDefaultAsync(m => m.warranty_id == id);
            if (warranty == null)
            {
                return NotFound();
            }

            return View(warranty);
        }

        // GET: Warranty/Create
        public IActionResult Create()
        {
            ViewData["customerOrder_id"] = new SelectList(_context.CustomerOrders, "customerOrder_id", "customerOrder_id");
            return View();
        }

        // POST: Warranty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("warranty_id,customerOrder_id,problem,claim_date")] Warranty warranty)
        {
            if (ModelState.IsValid)
            {
                var date = _context.CustomerOrders
                .Where(x=>x.customerOrder_id == warranty.customerOrder_id)
                .FirstOrDefault();
                DateTime today = DateTime.Now;
                TimeSpan timeDiff = today - date.customerorder_date;
                double num_day = timeDiff.TotalDays;
                int warrantynum_day = (int)Math.Round(num_day);
                int wdate = 0;
                if(warrantynum_day > 365){
                    wdate = 0;
                }
                if(wdate != 0){
                var i = new Warranty{
                    customerOrder_id = warranty.customerOrder_id,
                    problem          = warranty.problem,
                    claim_date       = DateTime.Now
                }; 
                _context.Warranties.Add(i);
                
                // else{
                //     alert("")
                //     };
                }                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["customerOrder_id"] = new SelectList(_context.CustomerOrders, "customerOrder_id", "customerOrder_id", warranty.customerOrder_id);
            return View(warranty);
        }

        // GET: Warranty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warranty = await _context.Warranties.FindAsync(id);
            if (warranty == null)
            {
                return NotFound();
            }
            ViewData["customerOrder_id"] = new SelectList(_context.CustomerOrders, "customerOrder_id", "customerOrder_id", warranty.customerOrder_id);
            return View(warranty);
        }

        // POST: Warranty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("warranty_id,customerOrder_id,problem,claim_date")] Warranty warranty)
        {
            if (id != warranty.warranty_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warranty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarrantyExists(warranty.warranty_id))
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
            ViewData["customerOrder_id"] = new SelectList(_context.CustomerOrders, "customerOrder_id", "customerOrder_id", warranty.customerOrder_id);
            return View(warranty);
        }

        // GET: Warranty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warranty = await _context.Warranties
                .Include(w => w.customerOrder)
                .FirstOrDefaultAsync(m => m.warranty_id == id);
            if (warranty == null)
            {
                return NotFound();
            }

            return View(warranty);
        }

        // POST: Warranty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var warranty = await _context.Warranties.FindAsync(id);
            _context.Warranties.Remove(warranty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarrantyExists(int id)
        {
            return _context.Warranties.Any(e => e.warranty_id == id);
        }
    }
}
