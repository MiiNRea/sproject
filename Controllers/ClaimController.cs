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
    public class ClaimController : Controller
    {
        private readonly MyDbContext _context;

        public ClaimController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Claim
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Claims
            .Include(c => c.customerInfo)
            .Include(c => c.customerOrder.Inventory)
            .Include(c => c.customerOrder);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Claim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims
                .Include(c => c.customerInfo)
                .Include(c => c.customerOrder)
                .FirstOrDefaultAsync(m => m.claim_id == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

        // GET: Claim/Create
        public IActionResult Create()
        {
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name");
            ViewData["customerOrder_id"] = new SelectList(_context.CustomerOrders, "customerOrder_id", "customerOrder_id");
            return View();
        }

        // POST: Claim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("claim_id,customerOrder_id,problem,claim_date,customerinfo_id")] Claim claim)
        {
            if (ModelState.IsValid)
            {
                var customerorder = _context.CustomerOrders
                .Where(x=>x.customerOrder_id == claim.customerOrder_id)
                .FirstOrDefault();

                DateTime today = DateTime.Now;
                TimeSpan timeDiff = today - customerorder.customerorder_date;
                double num_day = timeDiff.TotalDays;
                int warrantynum_day = (int)Math.Round(num_day);
                //int wdate = -1;
                if(warrantynum_day <= 365){
                        var i = new Claim{
                            customerOrder_id = claim.customerOrder_id,
                            problem          = claim.problem,
                            claim_date       = DateTime.Now,
                            customerinfo_id  = claim.customerinfo_id
                        }; 

                        ViewBag.error = 2;
                        _context.Claims.Add(i);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));                
                }   
                else{
                     ViewBag.error = 1;
                    return RedirectToAction("create");
                }   

            }
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name", claim.customerinfo_id);
            ViewData["customerOrder_id"] = new SelectList(_context.CustomerOrders, "customerOrder_id", "customerOrder_id", claim.customerOrder_id);
            return View(claim);
        }

        // GET: Claim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name", claim.customerinfo_id);
            ViewData["customerOrder_id"] = new SelectList(_context.CustomerOrders, "customerOrder_id", "customerOrder_id", claim.customerOrder_id);
            return View(claim);
        }

        // POST: Claim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("claim_id,customerOrder_id,problem,claim_date,customerinfo_id")] Claim claim)
        {
            if (id != claim.claim_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimExists(claim.claim_id))
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
            ViewData["customerinfo_id"] = new SelectList(_context.CustomerInfos, "customerinfo_id", "customer_name", claim.customerinfo_id);
            ViewData["customerOrder_id"] = new SelectList(_context.CustomerOrders, "customerOrder_id", "customerOrder_id", claim.customerOrder_id);
            return View(claim);
        }

        // GET: Claim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims
                .Include(c => c.customerInfo)
                .Include(c => c.customerOrder)
                .FirstOrDefaultAsync(m => m.claim_id == id);
            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }

        // POST: Claim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            _context.Claims.Remove(claim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaimExists(int id)
        {
            return _context.Claims.Any(e => e.claim_id == id);
        }
    }
}
