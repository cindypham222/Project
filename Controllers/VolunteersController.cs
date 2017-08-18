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
    public class VolunteersController : Controller
    {
        private readonly ProjectContext _context;

        public VolunteersController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: Volunteers
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task<IActionResult> Index(string approvalStatus, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> statusQuery = from m in _context.Volunteer
                                            orderby m.ApprovalStatus
                                            select m.ApprovalStatus;

            var volunteers = from m in _context.Volunteer
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                volunteers = volunteers.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
            }


            if (!String.IsNullOrEmpty(approvalStatus))
            {
                volunteers = volunteers.Where(x => x.ApprovalStatus == approvalStatus);
            }

            var approvalStatusVM = new ApprovalStatusViewModel();
            approvalStatusVM.status = new SelectList(await statusQuery.Distinct().ToListAsync());
            approvalStatusVM.volunteer = await volunteers.ToListAsync();

            return View(approvalStatusVM);
        }

        // GET: Volunteers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer
                .SingleOrDefaultAsync(m => m.VolunteerID == id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer);
        }

        // GET: Volunteers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Volunteers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VolunteerID,LastName,FirstName,UserName,Availability,Address,PhoneNumber,Email,Education,DriverLicense,SocialSecurity,ApprovalStatus")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(volunteer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(volunteer);
        }

        // GET: Volunteers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer.SingleOrDefaultAsync(m => m.VolunteerID == id);
            if (volunteer == null)
            {
                return NotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VolunteerID,LastName,FirstName,UserName,Availability,Address,PhoneNumber,Email,Education,DriverLicense,SocialSecurity,ApprovalStatus")] Volunteer volunteer)
        {
            if (id != volunteer.VolunteerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volunteer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolunteerExists(volunteer.VolunteerID))
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
            return View(volunteer);
        }

        // GET: Volunteers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer
                .SingleOrDefaultAsync(m => m.VolunteerID == id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer);
        }

        // POST: Volunteers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volunteer = await _context.Volunteer.SingleOrDefaultAsync(m => m.VolunteerID == id);
            _context.Volunteer.Remove(volunteer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VolunteerExists(int id)
        {
            return _context.Volunteer.Any(e => e.VolunteerID == id);
        }
    }
}
