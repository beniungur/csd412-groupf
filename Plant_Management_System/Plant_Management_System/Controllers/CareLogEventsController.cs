﻿using System;
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
    public class CareLogEventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<AppUser> _userManager;

        public CareLogEventsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: CareLogEvents
        public async Task<IActionResult> Index()
        {

            return View(await _context.CareLogEvent.ToListAsync());
        }

        // GET: CareLogEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careLogEvent = await _context.CareLogEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (careLogEvent == null)
            {
                return NotFound();
            }

            return View(careLogEvent);
        }

        // GET: CareLogEvents/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            CareLogEventView viewModel = new CareLogEventView();

            viewModel.care.Owner = await _userManager.GetUserAsync(User);

            viewModel.PlantList = await _context.Plant.Where(o => o.Owner.Id == viewModel.care.Owner.Id).ToListAsync();
            
            return View(viewModel);
        }

        // POST: CareLogEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CareDone,DateOfCare")] CareLogEventView careLogInfo)
        {
            if (ModelState.IsValid)
            {
                careLogInfo.care.PlantName = await _context.Plant.FindAsync(careLogInfo.PlantId);
                _context.Add(careLogInfo.care);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careLogInfo.care);
        }

        // GET: CareLogEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careLogEvent = await _context.CareLogEvent.FindAsync(id);
            if (careLogEvent == null)
            {
                return NotFound();
            }
            return View(careLogEvent);
        }

        // POST: CareLogEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CareDone,DateOfCare")] CareLogEvent careLogEvent)
        {
            if (id != careLogEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careLogEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareLogEventExists(careLogEvent.Id))
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
            return View(careLogEvent);
        }

        // GET: CareLogEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careLogEvent = await _context.CareLogEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (careLogEvent == null)
            {
                return NotFound();
            }

            return View(careLogEvent);
        }

        // POST: CareLogEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var careLogEvent = await _context.CareLogEvent.FindAsync(id);
            _context.CareLogEvent.Remove(careLogEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareLogEventExists(int id)
        {
            return _context.CareLogEvent.Any(e => e.Id == id);
        }
    }
}