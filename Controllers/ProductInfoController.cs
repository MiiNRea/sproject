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
    public class ProductInfoController : Controller
    {
        private readonly MyDbContext _context;

        public ProductInfoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ProductInfo
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.ProductInfos.Include(p => p.supplierInfo);
            return View(await myDbContext.ToListAsync());
        }
        public async Task<IActionResult> Products()
        {
            var result = await _context.ProductInfos
             .Select(x => new
             {
                 product_id = x.product_id,
                 product_name = x.product_name,
                 product_series = x.product_series,
                 product_size = x.product_size,
                 supplier_id = x.supplierInfo.supplier_id,
                 supplier_name = x.supplierInfo.supplier_name
             })
             .ToListAsync();
             return Json(result);
        }

        // GET: ProductInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInfo = await _context.ProductInfos
                .Include(p => p.supplierInfo)
                .FirstOrDefaultAsync(m => m.product_id == id);
            if (productInfo == null)
            {
                return NotFound();
            }

            return View(productInfo);
        }

        // GET: ProductInfo/Create
        public IActionResult Create()
        {
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name");
            return View();
        }


        // POST: ProductInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("product_id,product_name,product_series,product_size,supplier_id")] ProductInfo productInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name", productInfo.supplier_id);
            return View(productInfo);
        }

        // GET: ProductInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInfo = await _context.ProductInfos
            .Include(x=>x.supplierInfo)
            .FirstOrDefaultAsync(x=>x.product_id == id);
            if (productInfo == null)
            {
                return NotFound();
            }
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name", productInfo.supplier_id);
            return View(productInfo);
        }

        // POST: ProductInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("product_id,product_name,product_series,product_size,supplier_id")] ProductInfo productInfo)
        {
            if (id != productInfo.product_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductInfoExists(productInfo.product_id))
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
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name", productInfo.supplier_id);
            return View(productInfo);
        }

        // GET: ProductInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInfo = await _context.ProductInfos
                .Include(p => p.supplierInfo)
                .FirstOrDefaultAsync(m => m.product_id == id);
            if (productInfo == null)
            {
                return NotFound();
            }

            return View(productInfo);
        }

        // POST: ProductInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productInfo = await _context.ProductInfos.FindAsync(id);
            _context.ProductInfos.Remove(productInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductInfoExists(int id)
        {
            return _context.ProductInfos.Any(e => e.product_id == id);
        }

    }
}
