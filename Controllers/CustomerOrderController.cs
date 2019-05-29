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
    public class CustomerOrderController : Controller
    {
        private readonly MyDbContext _context;

        public CustomerOrderController(MyDbContext context)
        {
            _context = context;
        }

        // GET: CustomerOrder
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.CustomerOrders.Include(c => c.customerInfo).Include(c => c.productInfo);
            return View(await myDbContext.ToListAsync());
        }

        // GET: CustomerOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOrder = await _context.CustomerOrders
                .Include(c => c.customerInfo)
                .Include(c => c.productInfo)
                .FirstOrDefaultAsync(m => m.customerorder_id == id);
            if (customerOrder == null)
            {
                return NotFound();
            }

            return View(customerOrder);
        }

        // GET: CustomerOrder/Create
        public IActionResult Create()
        {
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name");
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name");
            return View();
        }

        // POST: CustomerOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("customerorder_id,customerorder_date,customerorder_qty,customerorder_price,product_id,customerinfo_id")] CustomerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name", customerOrder.customerinfo_id);
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", customerOrder.product_id);
            return View(customerOrder);
        }

        // GET: CustomerOrder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOrder = await _context.CustomerOrders.FindAsync(id);
            if (customerOrder == null)
            {
                return NotFound();
            }
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name", customerOrder.customerinfo_id);
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", customerOrder.product_id);
            return View(customerOrder);
        }

        // POST: CustomerOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("customerorder_id,customerorder_date,customerorder_qty,customerorder_price,product_id,customerinfo_id")] CustomerOrder customerOrder)
        {
            if (id != customerOrder.customerorder_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerOrderExists(customerOrder.customerorder_id))
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
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name", customerOrder.customerinfo_id);
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", customerOrder.product_id);
            return View(customerOrder);
        }

        // GET: CustomerOrder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerOrder = await _context.CustomerOrders
                .Include(c => c.customerInfo)
                .Include(c => c.productInfo)
                .FirstOrDefaultAsync(m => m.customerorder_id == id);
            if (customerOrder == null)
            {
                return NotFound();
            }

            return View(customerOrder);
        }

        // POST: CustomerOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerOrder = await _context.CustomerOrders.FindAsync(id);
            _context.CustomerOrders.Remove(customerOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerOrderExists(int id)
        {
            return _context.CustomerOrders.Any(e => e.customerorder_id == id);
        }
    }
}
