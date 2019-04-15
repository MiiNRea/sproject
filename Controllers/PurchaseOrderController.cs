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
    public class PurchaseOrderController : Controller
    {
        private readonly MyDbContext _context;

        public PurchaseOrderController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrder
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.PurchaseOrders.Include(p => p.productInfo).Include(p => p.purchaseorder_type).Include(p => p.supplierInfo);
            return View(await myDbContext.ToListAsync());
        }

        // GET: PurchaseOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrders
                .Include(p => p.productInfo)
                .Include(p => p.purchaseorder_type)
                .Include(p => p.supplierInfo)
                .FirstOrDefaultAsync(m => m.purchase_id == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // GET: PurchaseOrder/Create
        public IActionResult Create()
        {
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name");
            ViewData["purchase_type_id"] = new SelectList(_context.PurchaseOrderTypes, "Purchase_type_id", "Purchase_type_id");
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name");
            return View();
        }

        // POST: PurchaseOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("purchase_id,purchase_date,purchase_item,purchase_cost,purchase_type_id,product_id,supplier_id")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                purchaseOrder.purchase_date = DateTime.Now;
                purchaseOrder.purchase_type_id = 1;
                _context.Add(purchaseOrder);
                //create activity object
                //**** */
                var row = new PActivity{
                    purchase_type_id =   purchaseOrder.purchase_type_id,
                    purchase_id      =   purchaseOrder.purchase_id,
                    activity_date    =   DateTime.Now 
                };
                _context.PActivities.Add(row);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", purchaseOrder.product_id);
            ViewData["purchase_type_id"] = new SelectList(_context.PurchaseOrderTypes, "Purchase_type_id", "Purchase_type_id", purchaseOrder.purchase_type_id);
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name", purchaseOrder.supplier_id);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrders.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", purchaseOrder.product_id);
            ViewData["purchase_type_id"] = new SelectList(_context.PurchaseOrderTypes, "Purchase_type_id", "Purchase_type_id", purchaseOrder.purchase_type_id);
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name", purchaseOrder.supplier_id);
            return View(purchaseOrder);
        }

        // POST: PurchaseOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("purchase_id,purchase_date,purchase_item,purchase_cost,purchase_type_id,product_id,supplier_id")] PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.purchase_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderExists(purchaseOrder.purchase_id))
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
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", purchaseOrder.product_id);
            ViewData["purchase_type_id"] = new SelectList(_context.PurchaseOrderTypes, "Purchase_type_id", "Purchase_type_id", purchaseOrder.purchase_type_id);
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name", purchaseOrder.supplier_id);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrders
                .Include(p => p.productInfo)
                .Include(p => p.purchaseorder_type)
                .Include(p => p.supplierInfo)
                .FirstOrDefaultAsync(m => m.purchase_id == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // POST: PurchaseOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrder = await _context.PurchaseOrders.FindAsync(id);
            _context.PurchaseOrders.Remove(purchaseOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderExists(int id)
        {
            return _context.PurchaseOrders.Any(e => e.purchase_id == id);
        }
    }
}
