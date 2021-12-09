using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Plant_Management_System.Data;
using Plant_Management_System.Models;

namespace Plant_Management_System.Controllers
{
    public class PropagationEventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<AppUser> _userManager;

        public PropagationEventsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: PropagationEvents
        public async Task<IActionResult> Index()
        {
            //return View(await _context.CareLogEvent.Include(l => l.PlantName).Where(o => o.Owner == owner).ToListAsync());

            AppUser owner = await _userManager.GetUserAsync(User);
            List<PropagationEvent> list = await _context.PropagationEvent.Include(r => r.ParentPlant).Where(o => o.Owner == owner).ToListAsync();
            return View(list);
        }

        // GET: PropagationEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propagationEvent = await _context.PropagationEvent.Include(r => r.ParentPlant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propagationEvent == null)
            {
                return NotFound();
            }

            return View(propagationEvent);
        }

        // GET: PropagationEvents/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            PropEventView viewModel = new PropEventView();

            viewModel.prop.Owner = await _userManager.GetUserAsync(User);

            viewModel.plantList = await _context.Plant.Where(o => o.Owner.Id == viewModel.prop.Owner.Id).ToListAsync();

            return View(viewModel);
        }

        // POST: PropagationEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,PropDate")] PropagationEvent propagationEvent)
        public async Task<IActionResult> Create([Bind("ParentPlant,PropDate,prop")] PropEventView propInfo)
        {
            if (ModelState.IsValid)
            {
                propInfo.prop.ParentPlant = await _context.Plant.FindAsync(propInfo.ParentPlant);
                propInfo.prop.Owner = await _userManager.GetUserAsync(User);

                _context.Add(propInfo.prop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propInfo.prop);
        }

        // GET: PropagationEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var propagationEvent = await _context.PropagationEvent.FindAsync(id);
            var propagationEvent = await _context.PropagationEvent.Include(r => r.ParentPlant)
                 .FirstOrDefaultAsync(m => m.Id == id);

            if (propagationEvent == null)
            {
                return NotFound();
            }
            return View(propagationEvent);
        }

        // POST: PropagationEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParentPlant, Id,PropDate,prop")] PropagationEvent propagationEvent)
        {
            if (id != propagationEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propagationEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropagationEventExists(propagationEvent.Id))
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
            return View(propagationEvent);
        }

        // GET: PropagationEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propagationEvent = await _context.PropagationEvent.Include(r => r.ParentPlant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propagationEvent == null)
            {
                return NotFound();
            }

            return View(propagationEvent);
        }

        // POST: PropagationEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propagationEvent = await _context.PropagationEvent.FindAsync(id);
            _context.PropagationEvent.Remove(propagationEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropagationEventExists(int id)
        {
            return _context.PropagationEvent.Any(e => e.Id == id);
        }
    }
}
