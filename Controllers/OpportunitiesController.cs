using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    public class OpportunitiesController : Controller
    {
        private readonly ProjectContext _context;

        public OpportunitiesController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: Opportunities
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Opportunity.Include(o => o.Center);
            return View(await projectContext.ToListAsync());
        }

        // GET: Opportunities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunity
                .Include(o => o.Center)
                .SingleOrDefaultAsync(m => m.OpportunityID == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }

        // GET: Opportunities/Create
        public IActionResult Create()
        {
            ViewData["CenterID"] = new SelectList(_context.Center, "CenterID", "CenterID");
            return View();
        }

        // POST: Opportunities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OpportunityID,CenterID,Name,Date")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opportunity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CenterID"] = new SelectList(_context.Center, "CenterID", "CenterID", opportunity.CenterID);
            return View(opportunity);
        }

        // GET: Opportunities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunity.SingleOrDefaultAsync(m => m.OpportunityID == id);
            if (opportunity == null)
            {
                return NotFound();
            }
            ViewData["CenterID"] = new SelectList(_context.Center, "CenterID", "CenterID", opportunity.CenterID);
            return View(opportunity);
        }

        // POST: Opportunities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OpportunityID,CenterID,Name,Date")] Opportunity opportunity)
        {
            if (id != opportunity.OpportunityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opportunity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpportunityExists(opportunity.OpportunityID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CenterID"] = new SelectList(_context.Center, "CenterID", "CenterID", opportunity.CenterID);
            return View(opportunity);
        }

        // GET: Opportunities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunity = await _context.Opportunity
                .Include(o => o.Center)
                .SingleOrDefaultAsync(m => m.OpportunityID == id);
            if (opportunity == null)
            {
                return NotFound();
            }

            return View(opportunity);
        }

        // POST: Opportunities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opportunity = await _context.Opportunity.SingleOrDefaultAsync(m => m.OpportunityID == id);
            _context.Opportunity.Remove(opportunity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OpportunityExists(int id)
        {
            return _context.Opportunity.Any(e => e.OpportunityID == id);
        }
    }
}
