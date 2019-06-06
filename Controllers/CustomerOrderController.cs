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
            var myDbContext = _context.CustomerOrders
            .Include(c => c.Inventory)
            .Include(c => c.customerInfo);
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
                .Include(c => c.Inventory)
                .Include(c => c.customerInfo)
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
            ViewData["inventory_id"] = new SelectList(_context.Inventories, "inventory_id", "inventory_id");
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name");
            return View();
        }

        // POST: CustomerOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerOrder customerOrder)
        {
            if (ModelState.IsValid)
            {
                var info = new CustomerOrder{
                    customerinfo_id     = customerOrder.customerinfo_id,
                    customerorder_date  = DateTime.Now,
                    customerorder_qty   = customerOrder.customerorder_qty,
                    warranty_time       = 365,
                    //phone_number      = customerOrder.phone_number,
                    inventory_id        = customerOrder.inventory_id

                };
                _context.CustomerOrders.Add(info);

                var pproduct = await _context.Inventories
                .Where(x=>x.inventory_id == customerOrder.inventory_id).FirstOrDefaultAsync();
                var found = await _context.Inventories
                .FirstOrDefaultAsync(x=>x.product_name == pproduct.product_name);
                var total = found.invento_qty -= customerOrder.customerorder_qty;
                // if(total < 0){
                //     return 
                // }
                _context.Inventories.Update(found);

                //todo alert
                

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["inventory_id"] = new SelectList(_context.Inventories, "inventory_id", "inventory_id", customerOrder.inventory_id);
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name", customerOrder.customerinfo_id);
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
            ViewData["inventory_id"] = new SelectList(_context.Inventories, "inventory_id", "inventory_id", customerOrder.inventory_id);
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name", customerOrder.customerinfo_id);
            return View(customerOrder);
        }

        // POST: CustomerOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("customerOrder_id,customerorder_date,customerorder_qty,inventory_id,customerinfo_id,warranty_time")] CustomerOrder customerOrder)
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
            ViewData["inventory_id"] = new SelectList(_context.Inventories, "inventory_id", "inventory_id", customerOrder.inventory_id);
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name", customerOrder.customerinfo_id);
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
                .Include(c => c.Inventory)
                .Include(c => c.customerInfo)
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

        public async Task<IActionResult> customerorder_by_COid (int id)
        {   var customerorder = await _context.CustomerOrders
            .Where(x =>x.customerOrder_id == id)
            .Include(x=>x.customerInfo)
            .Include(x=>x.Inventory)
            .FirstOrDefaultAsync();
            return Json(new{date = customerorder.customerorder_date.ToShortDateString(), 
            cid = customerorder.customerinfo_id, 
            name = customerorder.customerInfo.customer_name, 
            phone = customerorder.customerInfo.phone_number,
            pname = customerorder.Inventory.product_name, 
            });   

        }

        [HttpGet]
        public async Task<IActionResult> ReportPS (string d1, string d2){
            var set1 = _context.CustomerOrders
            .Include(x=>x.Inventory)
            .Select(x=>x);

            if(d1 != null && d2 != null){
                DateTime date1 = Convert.ToDateTime(d1);
                DateTime date2 = Convert.ToDateTime(d2);
                set1 = set1.Where(x => x.customerorder_date >= date1 && x.customerorder_date <= date2);
            }
            var result = set1

            .Select(x=> new COReport            
            {   id = x.customerOrder_id,
                date = x.customerorder_date,
                total = x.customerorder_qty,
                product_id = x.Inventory.product_name
                });       

            var data= set1
            .Select(x=> new
                {date= x.customerorder_date, //.ToShortDateString(), //note time is not included just date
                total = x.customerorder_qty
                })

            .GroupBy(x => x.date)

            .Select(g=> new {
                date = g.Key,
                total = g.Sum(x=>x.total)
            });

           var x_data = data.Select(x=>x.date).ToArray();
           var y_data = data.Select(x=>x.total).ToArray();
         
           ViewBag.x_data = string.Join(",", x_data);
           ViewBag.y_data = string.Join(",", y_data);
             
            //step26: open Index View (View>Cart>Index.cshtml) and attach result to the Model
           //return View("Index",result);

         
           return View("ReportPS",result);
        }


//COReport ทำหน้า Units sold
        public IActionResult COReport(DateTime day){
            var result = _context.CustomerOrders
            .Where(x=>x.customerorder_date <= day)
            .Include(x=>x.Inventory)
           .Select(x=> new { product_name = x.Inventory.product_name, qty = x.customerorder_qty}).Distinct();
            return Json(result);
    }



    }
}
