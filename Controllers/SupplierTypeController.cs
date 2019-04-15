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
    public class SupplierTypeController : Controller
    {
        private readonly MyDbContext _context;

        public SupplierTypeController(MyDbContext context)
        {
            _context = context;
        }

        // GET: SupplierType
        public async Task<IActionResult> Index()
        {
            return View(await _context.SupplierTypes.ToListAsync());
        }

        // GET: SupplierType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierType = await _context.SupplierTypes
                .FirstOrDefaultAsync(m => m.supplier_type_id == id);
            if (supplierType == null)
            {
                return NotFound();
            }

            return View(supplierType);
        }

        // GET: SupplierType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupplierType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("supplier_type_id,supplier_type_name")] SupplierType supplierType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplierType);
        }

        // GET: SupplierType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierType = await _context.SupplierTypes.FindAsync(id);
            if (supplierType == null)
            {
                return NotFound();
            }
            return View(supplierType);
        }

        // POST: SupplierType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("supplier_type_id,supplier_type_name")] SupplierType supplierType)
        {
            if (id != supplierType.supplier_type_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierTypeExists(supplierType.supplier_type_id))
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
            return View(supplierType);
        }

        // GET: SupplierType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierType = await _context.SupplierTypes
                .FirstOrDefaultAsync(m => m.supplier_type_id == id);
            if (supplierType == null)
            {
                return NotFound();
            }

            return View(supplierType);
        }

        // POST: SupplierType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierType = await _context.SupplierTypes.FindAsync(id);
            _context.SupplierTypes.Remove(supplierType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierTypeExists(int id)
        {
            return _context.SupplierTypes.Any(e => e.supplier_type_id == id);
        }
    }
}
