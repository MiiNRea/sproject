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
                //.Include(c => c.inventory)
                .Include(c => c.productInfo)
                .FirstOrDefaultAsync(m => m.customerOrder_id == id);
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
            //ViewData["inventory_id"] = new SelectList(_context.Inventories, "inventory_id", "inventory_id");
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name");
            return View();
        }

        // POST: CustomerOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("customerOrder_id,customerorder_date,customerorder_qty,product_id,inventory_id,customerinfo_id,phone_number,warranty_time")] CustomerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerOrder);

                var info = new CustomerOrder{
                    customerinfo_id     = customerOrder.customerinfo_id,
                    customerorder_date  = DateTime.Now,
                    customerorder_qty   = customerOrder.customerorder_qty,
                    warranty_time       = 365,
                    phone_number        = customerOrder.phone_number,
                    product_id          = customerOrder.product_id,
                };
                _context.CustomerOrders.Add(info);

                var found = await _context.Inventories
                .FirstOrDefaultAsync(x=>x.product_id == customerOrder.product_id);
                    found.invento_qty -= customerOrder.customerorder_qty;
                    _context.Inventories.Update(found);


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name", customerOrder.customerinfo_id);
            //ViewData["inventory_id"] = new SelectList(_context.Inventories, "inventory_id", "inventory_id", customerOrder.inventory_id);
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
            //ViewData["inventory_id"] = new SelectList(_context.Inventories, "inventory_id", "inventory_id", customerOrder.inventory_id);
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", customerOrder.product_id);
            return View(customerOrder);
        }

        // POST: CustomerOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("customerOrder_id,customerorder_date,customerorder_qty,product_id,inventory_id,customerinfo_id,phone_number,warranty_time")] CustomerOrder customerOrder)
        {
            if (id != customerOrder.customerOrder_id)
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
                    if (!CustomerOrderExists(customerOrder.customerOrder_id))
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
            //ViewData["inventory_id"] = new SelectList(_context.Inventories, "inventory_id", "inventory_id", customerOrder.inventory_id);
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
                //.Include(c => c.inventory)
                .Include(c => c.productInfo)
                .FirstOrDefaultAsync(m => m.customerOrder_id == id);
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
            return _context.CustomerOrders.Any(e => e.customerOrder_id == id);
        }
    }
}
