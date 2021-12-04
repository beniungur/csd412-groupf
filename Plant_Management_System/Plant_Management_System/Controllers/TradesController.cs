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
    public class TradesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trade.ToListAsync());
        }

        // GET: Trades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trade = await _context.Trade
                .FirstOrDefaultAsync(m => m.TradeId == id);
            if (trade == null)
            {
                return NotFound();
            }

            return View(trade);
        }

        // GET: Trades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TradeId,ReceivingPlant")] Trade trade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trade);
        }

        // GET: Trades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trade = await _context.Trade.FindAsync(id);
            if (trade == null)
            {
                return NotFound();
            }
            return View(trade);
        }

        // POST: Trades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TradeId,ReceivingPlant")] Trade trade)
        {
            if (id != trade.TradeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TradeExists(trade.TradeId))
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
            return View(trade);
        }

        // GET: Trades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trade = await _context.Trade
                .FirstOrDefaultAsync(m => m.TradeId == id);
            if (trade == null)
            {
                return NotFound();
            }

            return View(trade);
        }

        // POST: Trades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trade = await _context.Trade.FindAsync(id);
            _context.Trade.Remove(trade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TradeExists(int id)
        {
            return _context.Trade.Any(e => e.TradeId == id);
        }
    }
}
