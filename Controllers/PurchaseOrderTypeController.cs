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
    public class PurchaseOrderTypeController : Controller
    {
        private readonly MyDbContext _context;

        public PurchaseOrderTypeController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrderType
        public async Task<IActionResult> Index()
        {
            return View(await _context.PurchaseOrderTypes.ToListAsync());
        }

        // GET: PurchaseOrderType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderType = await _context.PurchaseOrderTypes
                .FirstOrDefaultAsync(m => m.Purchase_type_id == id);
            if (purchaseOrderType == null)
            {
                return NotFound();
            }

            return View(purchaseOrderType);
        }

        // GET: PurchaseOrderType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseOrderType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Purchase_type_id,Purchase_type_name")] PurchaseOrderType purchaseOrderType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseOrderType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseOrderType);
        }

        // GET: PurchaseOrderType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderType = await _context.PurchaseOrderTypes.FindAsync(id);
            if (purchaseOrderType == null)
            {
                return NotFound();
            }
            return View(purchaseOrderType);
        }

        // POST: PurchaseOrderType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Purchase_type_id,Purchase_type_name")] PurchaseOrderType purchaseOrderType)
        {
            if (id != purchaseOrderType.Purchase_type_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrderType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderTypeExists(purchaseOrderType.Purchase_type_id))
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
            return View(purchaseOrderType);
        }

        // GET: PurchaseOrderType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderType = await _context.PurchaseOrderTypes
                .FirstOrDefaultAsync(m => m.Purchase_type_id == id);
            if (purchaseOrderType == null)
            {
                return NotFound();
            }

            return View(purchaseOrderType);
        }

        // POST: PurchaseOrderType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrderType = await _context.PurchaseOrderTypes.FindAsync(id);
            _context.PurchaseOrderTypes.Remove(purchaseOrderType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderTypeExists(int id)
        {
            return _context.PurchaseOrderTypes.Any(e => e.Purchase_type_id == id);
        }

        public IActionResult purchaseOrderStatuss(){
            return Json(_context.PurchaseOrderTypes.Select(x=> new {Purchase_type_id= x.Purchase_type_id}).ToList());
        }

    }
}
