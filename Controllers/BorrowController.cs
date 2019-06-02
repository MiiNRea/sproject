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
    public class BorrowController : Controller
    {
        private readonly MyDbContext _context;

        public BorrowController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Borrow
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Borrows.Include(b => b.productInfo).Include(b => b.supplierInfo);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Borrow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows
                .Include(b => b.productInfo)
                .Include(b => b.supplierInfo)
                .FirstOrDefaultAsync(m => m.borrow_id == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // GET: Borrow/Create
        public IActionResult Create()
        {
            var result1 = _context.SupplierInfos
            .Where(x=>x.supplier_type_id == 2)
            .Select(x=>x.supplier_id)  //select supplier id from type
            .ToArray();

            //query2: supplier id from the purchase table where the ids are 
            //in the query1

            var result2 = _context.SupplierInfos.Where(x=> result1.Contains(x.supplier_id));
            
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name");
            ViewData["supplier_id"] = new SelectList(result2, "supplier_id", "supplier_name");
            return View();
        }

        // POST: Borrow/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("borrow_id,supplier_id,product_id,borrow_qty,borrow_date")] Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                var borrowinfo = new Borrow{	
                    supplier_id    = borrow.supplier_id,
                    product_id	   = borrow.product_id,
                    borrow_qty	   = borrow.borrow_qty,    
                    borrow_date    = DateTime.Now                                 
                };
                _context.Borrows.Add(borrowinfo);
               
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", borrow.product_id);
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name", borrow.supplier_id);
            return View(borrow);
        }

        // GET: Borrow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow == null)
            {
                return NotFound();
            }
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", borrow.product_id);
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name", borrow.supplier_id);
            return View(borrow);
        }

        // POST: Borrow/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("borrow_id,supplier_id,product_id,borrow_qty,borrow_date")] Borrow borrow)
        {
            if (id != borrow.borrow_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowExists(borrow.borrow_id))
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
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", borrow.product_id);
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name", borrow.supplier_id);
            return View(borrow);
        }

        // GET: Borrow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows
                .Include(b => b.productInfo)
                .Include(b => b.supplierInfo)
                .FirstOrDefaultAsync(m => m.borrow_id == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // POST: Borrow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrow = await _context.Borrows.FindAsync(id);
            _context.Borrows.Remove(borrow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowExists(int id)
        {
            return _context.Borrows.Any(e => e.borrow_id == id);
        }
    }
}
