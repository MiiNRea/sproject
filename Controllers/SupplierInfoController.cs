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
    public class SupplierInfoController : Controller
    {
        private readonly MyDbContext _context;

        public SupplierInfoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: SupplierInfo
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.SupplierInfos.Include(s => s.supplier_type);
            return View(await myDbContext.ToListAsync());
        }

        public async Task<IActionResult> SDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierInfo = await _context.SupplierInfos
                .Include(s => s.supplier_type)
                .FirstOrDefaultAsync(m => m.supplier_id == id);
            if (supplierInfo == null)
            {
                return NotFound();
            }

            return View(supplierInfo);
        }

        // GET: SupplierInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierInfo = await _context.SupplierInfos
                .Include(s => s.supplier_type)
                .FirstOrDefaultAsync(m => m.supplier_id == id);
               
            if (supplierInfo == null)
            {
                return NotFound();
            }

            return View(supplierInfo);
        }

        // GET: SupplierInfo/Create
        public IActionResult Create()
        {
            ViewData["supplier_type_id"] = new SelectList(_context.SupplierTypes, "supplier_type_id", "supplier_type_name");
            return View();
        }

        // POST: SupplierInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
         
        public async Task<IActionResult> Create( SupplierInfo supplierInfo)
        {
            //no need to validate this variable 
            ModelState.Clear();

            if (ModelState.IsValid)
            {
                _context.Add(supplierInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["supplier_type_id"] = new SelectList(_context.SupplierTypes, "supplier_type_id", "supplier_type_name");
            return View(supplierInfo);
        }

        // GET: SupplierInfo/Edit/5
      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierInfo = await _context.SupplierInfos
            .Include(x=>x.supplier_type)
            .FirstOrDefaultAsync(x=>x.supplier_id == id);
            
            if (supplierInfo == null)
            {
                return NotFound();
            }
            ViewData["supplier_type_id"] = new SelectList(_context.SupplierTypes, "supplier_type_id", "supplier_type_name");
            return View(supplierInfo);
        }

        // POST: SupplierInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("supplier_id,supplier_name,supplier_person,supplier_phone,supplier_address,supplier_type_id")] SupplierInfo supplierInfo)
        {
            if (id != supplierInfo.supplier_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierInfoExists(supplierInfo.supplier_id))
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
            ViewData["supplier_type_id"] = new SelectList(_context.SupplierTypes, "supplier_type_id", "supplier_type_name");
            return View(supplierInfo);
        }

        // GET: SupplierInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierInfo = await _context.SupplierInfos
                .Include(s => s.supplier_type)
                .FirstOrDefaultAsync(m => m.supplier_id == id);
            if (supplierInfo == null)
            {
                return NotFound();
            }

            return View(supplierInfo);
        }

        // POST: SupplierInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierInfo = await _context.SupplierInfos.FindAsync(id);
            _context.SupplierInfos.Remove(supplierInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierInfoExists(int id)
        {
            return _context.SupplierInfos.Any(e => e.supplier_id == id);
        }

        public IActionResult Suppliers(){
            return Json(_context.SupplierInfos.Select(x=> new {supplier_id= x.supplier_id}).ToList());
        }
    }
}
