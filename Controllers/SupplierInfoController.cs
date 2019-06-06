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

         public async Task<IActionResult> BDetails(int? id)
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
            ViewData["supplier_type_id"] = new SelectList(_context.SupplierTypes, "supplier_type_id", "supplier_type_name", supplierInfo.supplier_type_id);
            return View(supplierInfo);
        }

        // POST: SupplierInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("supplier_id,supplier_name,supplier_person,supplier_phone,supplier_address,supplier_type_id")] SupplierInfo supplierInfo)
        {
            //return Json(supplierInfo);
            if (id != supplierInfo.supplier_id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    
                    _context.Update(supplierInfo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                         
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
            //}
            ViewData["supplier_type_id"] = new SelectList(_context.SupplierTypes, "supplier_type_id", "supplier_type_name");
           var result = await  _context.SupplierInfos.Include(x=>x.supplier_type).Where(x=>x.supplier_id ==id).FirstOrDefaultAsync();
            return View(result);
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
            // var supplierinfo = _context.SupplierInfos.Where(x=>x.supplier_type_id == 2)
            // .FirstOrDefault();
            return Json(_context.SupplierInfos.Select(x=> new {supplier_id= x.supplier_id, x.supplier_name,x.supplier_person,x.supplier_phone, x.supplier_type_id}).ToList());
        }

        [HttpGet]
        public IActionResult Partners(int id){
            var supplierinfo = _context.SupplierInfos.Where(x=>x.supplier_type_id == id);
            // .FirstOrDefault();
            return Json(_context.SupplierInfos.Select(x=> new {supplier_id= x.supplier_id, x.supplier_name, x.supplier_type_id}).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> ReportPFM (string d1, string d2){
            var set1 = _context.SupplierPerformances
            .Include(x=>x.supplierInfo)
            .Select(x=>x);

            if(d1 != null && d2 != null){
                DateTime date1 = Convert.ToDateTime(d1);
                DateTime date2 = Convert.ToDateTime(d2);
                set1 = set1.Where(x => x.deliver_date >= date1 && x.deliver_date <= date2);
            }
            var result = set1

            .Select(x=> new PFMReport{   
                date = x.deliver_date,
                supplier_name = x.supplierInfo.supplier_name,
                leadtime = x.leadTime,
                backorder = x.backOrder
                });       

            var data= set1
            .Select(x=> new
                {date= x.deliver_date, //.ToShortDateString(), //note time is not included just date
                total = x.leadTime + x.backOrder
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

         
           return View("ReportPFM",result);
        }
        public IActionResult PFMReport(DateTime day){
            var result = _context.SupplierPerformances
            .Where(x=>x.deliver_date <= day)
            .Include(x=>x.supplierInfo)
           .Select(x=> new { product_name = x.supplierInfo.supplier_name, leadtime = x.leadTime, backorder=x.backOrder,total = x.leadTime+x.backOrder }).Distinct();
            return Json(result);
    }

        
    }
}
