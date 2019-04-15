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
            return View(await _context.ProductInfos.ToListAsync());
        }

        // GET: ProductInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInfo = await _context.ProductInfos
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
            return View();
        }

        // POST: ProductInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("product_id,product_name,product_series,product_size")] ProductInfo productInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productInfo);
        }

        // GET: ProductInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInfo = await _context.ProductInfos.FindAsync(id);
            if (productInfo == null)
            {
                return NotFound();
            }
            return View(productInfo);
        }

        // POST: ProductInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("product_id,product_name,product_series,product_size")] ProductInfo productInfo)
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
