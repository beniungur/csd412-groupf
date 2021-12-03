using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Plant_Management_System.Data;
using Plant_Management_System.Models;

namespace Plant_Management_System.Controllers
{
    public class PropagationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropagationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Propagations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Propagation.ToListAsync());
        }

        // GET: Propagations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propagation = await _context.Propagation
                .FirstOrDefaultAsync(m => m.PropagationId == id);
            if (propagation == null)
            {
                return NotFound();
            }

            return View(propagation);
        }

        // GET: Propagations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propagations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropagationId,ParentPlantId,Type,DateStarted,PropagationMedium")] Propagation propagation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propagation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propagation);
        }

        // GET: Propagations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propagation = await _context.Propagation.FindAsync(id);
            if (propagation == null)
            {
                return NotFound();
            }
            return View(propagation);
        }

        // POST: Propagations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropagationId,ParentPlantId,Type,DateStarted,PropagationMedium")] Propagation propagation)
        {
            if (id != propagation.PropagationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propagation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropagationExists(propagation.PropagationId))
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
            return View(propagation);
        }

        // GET: Propagations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propagation = await _context.Propagation
                .FirstOrDefaultAsync(m => m.PropagationId == id);
            if (propagation == null)
            {
                return NotFound();
            }

            return View(propagation);
        }

        // POST: Propagations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propagation = await _context.Propagation.FindAsync(id);
            _context.Propagation.Remove(propagation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropagationExists(int id)
        {
            return _context.Propagation.Any(e => e.PropagationId == id);
        }
    }
}
