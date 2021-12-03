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
    public class PropogationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropogationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Propogations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Propogation.ToListAsync());
        }

        // GET: Propogations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propogation = await _context.Propogation
                .FirstOrDefaultAsync(m => m.PropogationId == id);
            if (propogation == null)
            {
                return NotFound();
            }

            return View(propogation);
        }

        // GET: Propogations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propogations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropogationId,ParentPlantId,Type,DateStarted,PropogationMedium")] Propagation propogation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propogation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propogation);
        }

        // GET: Propogations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propogation = await _context.Propogation.FindAsync(id);
            if (propogation == null)
            {
                return NotFound();
            }
            return View(propogation);
        }

        // POST: Propogations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropogationId,ParentPlantId,Type,DateStarted,PropogationMedium")] Propagation propogation)
        {
            if (id != propogation.PropogationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propogation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropogationExists(propogation.PropogationId))
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
            return View(propogation);
        }

        // GET: Propogations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propogation = await _context.Propogation
                .FirstOrDefaultAsync(m => m.PropogationId == id);
            if (propogation == null)
            {
                return NotFound();
            }

            return View(propogation);
        }

        // POST: Propogations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propogation = await _context.Propogation.FindAsync(id);
            _context.Propogation.Remove(propogation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropogationExists(int id)
        {
            return _context.Propogation.Any(e => e.PropogationId == id);
        }
    }
}
