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

            return View("Index",await _context.PurchaseOrders.ToListAsync());
        }

        // GET: PurchaseOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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

        // GET: PurchaseOrder/Create
        public IActionResult Create()
        {
          return View();
        }

        // POST: PurchaseOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //public async Task<IActionResult> Create(CartItem[] items)
        public async Task<IActionResult> Create(Cart cart)
        {
        
            List<CartItem> items = cart.items;
            
            if(items !=null && items.Count >0){
                //step1: create purchase order object
                PurchaseOrder new_order = new PurchaseOrder();
                new_order.purchase_date = DateTime.Now;

                _context.Add(new_order);
               await _context.SaveChangesAsync();  //this call creates a new object with purchase id

                List<PurchaseItem> list1 = new List<PurchaseItem>();

                //loop throught each item in the items list
                foreach (CartItem item in items)
                {
                    //create a new object with the structure based on Model>CartItem.cs 
                    var new_purchase_item = new PurchaseItem
                    {
                       purchase_id      = new_order.purchase_id,
                       supplier_id      = item.supplier_id,
                       product_id       = item.id,
                       purchase_type_id = 1,
                       purchase_cost    = item.total,
                       selling_price    = item.selling_price,
                       qty              = item.qty
                    };
                    list1.Add(new_purchase_item);
                    
                    //todo
                    //check type of supplier , if supplier type == part then also add borrow item in borrow table  
                    var supplier = await _context.SupplierInfos.Where(x=>x.supplier_id == item.supplier_id).FirstOrDefaultAsync(); 
                    if(supplier.supplier_type_id == 2){
                        //create borrow object and add it here 
                         var borrow = new Borrow{
                             supplier_id = supplier.supplier_id,
                             product_id = item.id,
                             borrow_qty = item.qty,
                             borrow_date = DateTime.Now,
                             purchase_id = new_order.purchase_id
                             
                         };  
                         _context.Borrows.Add(borrow);                       
                    }
                }//end loop
                //assign cartitem list 
                new_order.purchase_items = list1;
                await _context.SaveChangesAsync(); //save cart first

                foreach( PurchaseItem purchase_item in new_order.purchase_items){
                    var new_activity = new PActivity
                {
                    //purchase_type_id =   purchaseOrder.purchase_type_id,
                    //purchase_id = new_order.purchase_id,
                    purchase_type_id = 1,
                    activity_date = DateTime.Now,
                    purchaseItem_id = purchase_item.purchaseItem_id
                    };
                    _context.Add(new_activity);
                }

                await _context.SaveChangesAsync();
                return Json(new {
                    newUrl = "/purchaseorder/index"
                });
            }               
            
            return View();
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
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name");
            ViewData["purchase_type_id"] = new SelectList(_context.PurchaseOrderTypes, "Purchase_type_id", "Purchase_type_id");
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name");
            return View(purchaseOrder);
        }

        // POST: PurchaseOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("purchase_id,purchase_date")] PurchaseOrder purchaseOrder)
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
            ViewData["product_id"] = new SelectList(_context.ProductInfos, "product_id", "product_name");
            ViewData["purchase_type_id"] = new SelectList(_context.PurchaseOrderTypes, "Purchase_type_id", "Purchase_type_id");
            ViewData["supplier_id"] = new SelectList(_context.SupplierInfos, "supplier_id", "supplier_name");
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
                
                .Where(m => m.purchase_id == id)
                .Select(x=> new PDV{
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
            // var purchaseOrder = await _context.PurchaseOrders
            //     .FirstOrDefaultAsync(m => m.purchase_id == id);
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



        public IActionResult purchases(){
            // var result = _context.PurchaseOrders
            // .Select(x=> new { purchase_id= x.purchase_id})
            // .ToList();
            var result = _context.PurchaseItems.Where(x=>x.purchase_type_id != 3).Select(x=> new { purchase_id= x.purchase_id}).Distinct();
            return Json(result);
        }

        public async Task<IActionResult> purchaseItems(int id){
            //get all pact that purchas_type_id = 3. as array
             var result1 = _context.PActivities
            .Where(x=>x.purchase_type_id == 3)
            .Select(x=>x.purchaseItem_id)  //select purchase id from Purchase
            .ToArray();

               var result = await _context.PurchaseOrders
               .Where(x=>x.purchase_id == id)
               .Select(x=> new ProductView{
                   purchase_id = x.purchase_id,
                   //filter purchase_items not having 3 as purchase_type_id in pactivity

                   purchaseItems = x.purchase_items
                        .Where(o =>! result1.Contains(o.purchaseItem_id))
                        .Select(y=>new PurchaseItemView{                  
                       product_id =  y.product_id,
                       product_name = y.productInfo.product_name               
                   })
                
                   .ToList()
               })
               .FirstAsync();            
               return Json(result);
        }
        [HttpGet]
        public IActionResult getpurchaseitem(int d1, int d2){
               var purchaseitem =  _context.PurchaseItems.Where(x=>x.purchase_id == d1)
                .Where(x=>x.product_id == d2)
                .FirstOrDefault();
        return Json(new {purchase_item_id = purchaseitem.purchaseItem_id, qty = purchaseitem.qty, supplier = purchaseitem.supplier_id, product_id = purchaseitem.product_id});		
        }        

    }
}
