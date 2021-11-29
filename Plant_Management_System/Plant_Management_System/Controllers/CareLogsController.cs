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
    public class CareLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CareLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CareLog.ToListAsync());
        }

        // GET: CareLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careLog = await _context.CareLog
                .FirstOrDefaultAsync(m => m.CareLogId == id);
            if (careLog == null)
            {
                return NotFound();
            }

            return View(careLog);
        }

        // GET: CareLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CareLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CareLogId,Date,CareDone")] CareLog careLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careLog);
        }

        // GET: CareLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careLog = await _context.CareLog.FindAsync(id);
            if (careLog == null)
            {
                return NotFound();
            }
            return View(careLog);
        }

        // POST: CareLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CareLogId,Date,CareDone")] CareLog careLog)
        {
            if (id != careLog.CareLogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareLogExists(careLog.CareLogId))
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
            return View(careLog);
        }

        // GET: CareLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careLog = await _context.CareLog
                .FirstOrDefaultAsync(m => m.CareLogId == id);
            if (careLog == null)
            {
                return NotFound();
            }

            return View(careLog);
        }

        // POST: CareLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var careLog = await _context.CareLog.FindAsync(id);
            _context.CareLog.Remove(careLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareLogExists(int id)
        {
            return _context.CareLog.Any(e => e.CareLogId == id);
        }
    }
}
