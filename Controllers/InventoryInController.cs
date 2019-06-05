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
    public class InventoryInController : Controller
    {
        private readonly MyDbContext _context;

        public InventoryInController(MyDbContext context)
        {
            _context = context;
        }

        // GET: InventoryIn
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.InventoryIns.Include(i => i.productinfo)
            .Include(i => i.purchaseorder);
            return View(await myDbContext.ToListAsync());
        }

        // GET: InventoryIn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryIn = await _context.InventoryIns
                .Include(i => i.productinfo)
                .Include(i => i.purchaseorder)
                .FirstOrDefaultAsync(m => m.inventoryin_id == id);
            if (inventoryIn == null)
            {
                return NotFound();
            }

            return View(inventoryIn);
        }

        // GET: InventoryIn/Create
        

        public IActionResult Create()
        { 
            //query1: order id with status = completed from activity table

            var result1 = _context.PActivities
            .Where(x=>x.purchase_type_id == 3)
            .Select(x=>x.purchaseItem_id)  //select purchase id from Purchase
            .ToArray();

            //query2: purchase order id from the purchase table where the ids are not
            //in the query1

            var result2 = _context.PurchaseOrders.Where(x=>! result1.Contains(x.purchase_id));            
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name");
            ViewData["purchase_id"] = new SelectList(result2, "purchase_id", "purchase_id");
            ViewData["purchase_type_id"] = new SelectList(_context.PurchaseOrderTypes, "Purchase_type_id", "Purchase_type_name");
            return View();
        }

        // POST: InventoryIn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryInView inventoryInView)
        {
            //return Json(inventoryInView);
            //กรณีที่เป็น Complete
            //if (inventoryInView.purchase_type_id == 3)
            if (ModelState.IsValid)
            { 
                //return Content("yes");
                if (inventoryInView.purchase_type_id == 3){
                    var obj = new InventoryIn{	
                        purchase_id	        = inventoryInView.purchase_id,
                        product_id	        = inventoryInView.product_id,
                        inventoryin_qty	    = inventoryInView.inventoryin_qty,    
                        manufacturer_week   = inventoryInView.manufacturer_week,
                        manufacturer_year   = inventoryInView.manufacturer_year,
                        purchaseItem_id     = inventoryInView.purchaseItem_id,
                        CompleteDate        = DateTime.Now              
                    };
                    _context.InventoryIn.Add(obj);
                    //return Json(obj);
                    var row = new PActivity{
                        purchase_type_id =   inventoryInView.purchase_type_id,
                        purchaseItem_id  =   inventoryInView.purchaseItem_id,
                        activity_date    =   DateTime.Now 
                    };
                    _context.PActivities.Add(row);  

                    //update purchase_type_id into purchase_items table
                    var found = await _context.PurchaseItems.FirstOrDefaultAsync(x=>x.purchaseItem_id == inventoryInView.purchaseItem_id);
                    found.purchase_type_id =3;
                    _context.PurchaseItems.Update(found);

                    var pproduct = await _context.ProductInfos.Where(x=>x.product_id == inventoryInView.product_id).FirstOrDefaultAsync();
                    var found2 = await _context.Inventories
                    .FirstOrDefaultAsync(x=>x.product_name == pproduct.product_name);
                    found2.invento_qty += inventoryInView.inventoryin_qty;
                    _context.Inventories.Update(found2);
                    
                    var po = _context.PurchaseOrders
                    .Where(x=>x.purchase_id == inventoryInView.purchase_id)
		             .FirstOrDefault();
                        DateTime today = DateTime.Now;
                        TimeSpan timeDiff = today - po.purchase_date;
                        double num_day = timeDiff.TotalDays;
                        int i_num_day =(int) Math.Round(num_day);
                        int kpi = 0;
                        if(i_num_day >5){
                            kpi = 1;
		                }

                        //use kip to update performance table
                        var new_kpi = new SupplierPerformance{
                            leadTime = kpi,
                            deliver_date = today,
                            supplier_id = inventoryInView.supplier_id,
                            purchaseItem_id = inventoryInView.purchaseItem_id,
                            backOrder = 0
                        };
                    _context.SupplierPerformances.Add(new_kpi);

                        
                    await _context.SaveChangesAsync();   
                    return RedirectToAction(nameof(Index));          
                }
                
            //กรณีที่เป็น BackOrder
            if(inventoryInView.purchase_type_id == 2){
                    var bo = new SupplierPerformance{
                        supplier_id = inventoryInView.supplier_id,
                        purchaseItem_id = inventoryInView.purchaseItem_id,
                        deliver_date = DateTime.Now,
                        leadTime = 0,
                        backOrder = 1
                    };
                    _context.SupplierPerformances.Add(bo);

                    var bol = new BackOrder{
                        purchaseItem_id = inventoryInView.purchaseItem_id
                    };
                    _context.BackOrders.Add(bol);

                    var found = await _context.PurchaseItems.FirstOrDefaultAsync(x=>x.purchaseItem_id == inventoryInView.purchaseItem_id);
                    found.purchase_type_id =2;
                    _context.PurchaseItems.Update(found);

                    await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));  
                }
            }

            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", inventoryInView.product_id);
            ViewData["purchase_id"] = new SelectList(_context.PurchaseOrders, "purchase_id", "purchase_id", inventoryInView.purchase_id);
            ViewData["purchase_type_id"] = new SelectList(_context.PurchaseOrderTypes, "Purchase_type_id", "Purchase_type_name");
            return View();
        }

        // GET: InventoryIn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryIn = await _context.InventoryIns.FindAsync(id);
            if (inventoryIn == null)
            {
                return NotFound();
            }
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", inventoryIn.product_id);
            ViewData["purchase_id"] = new SelectList(_context.PurchaseOrders, "purchase_id", "purchase_id", inventoryIn.purchase_id);
            return View(inventoryIn);
        }

        // POST: InventoryIn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("inventoryin_id,purchase_id,product_id,inventoryin_qty,manufacturer_date")] InventoryIn inventoryIn)
        {
            if (id != inventoryIn.inventoryin_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryIn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryInExists(inventoryIn.inventoryin_id))
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
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name", inventoryIn.product_id);
            ViewData["purchase_id"] = new SelectList(_context.PurchaseOrders, "purchase_id", "purchase_id", inventoryIn.purchase_id);
            return View(inventoryIn);
        }

        // GET: InventoryIn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryIn = await _context.InventoryIns
                .Include(i => i.productinfo)
                .Include(i => i.purchaseorder)
                .FirstOrDefaultAsync(m => m.inventoryin_id == id);
            if (inventoryIn == null)
            {
                return NotFound();
            }

            return View(inventoryIn);
        }

        // POST: InventoryIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryIn = await _context.InventoryIns.FindAsync(id);
            _context.InventoryIns.Remove(inventoryIn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryInExists(int id)
        {
            return _context.InventoryIns.Any(e => e.inventoryin_id == id);
        }       

        public async Task<IActionResult> IDetail(int? id)
        { //todo
            if (id == null)
            {
                return NotFound();
            }
            var inventoryIn = await _context.InventoryIns
                .Include(i => i.productinfo)
                .Include(i => i.purchaseorder)
                .FirstOrDefaultAsync(m => m.inventoryin_id == id);

            var purchaseOrder = await _context.PurchaseOrders
                
                 .Where(m => m.purchase_id == id)
                .Select(x=> new PurchaseDetailView{
                    purchase_id = x.purchase_id,
                    purchase_date = x.purchase_date,
                    purchaseItems = x.purchase_items.Select(y => new PurchaseItemDetailView{
                                        supplier_name = y.supplierInfo.supplier_name,
                                        product_name = y.productInfo.product_name,
                                        status = y.purchaseorder_type.Purchase_type_name,
                                        product_qty  = y.qty,
                                        selling_price = y.selling_price,
                                        total = y.purchase_cost,
                    }).ToList()    
                })
                .FirstOrDefaultAsync();
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            return View(purchaseOrder);
        }

       
    }
}
