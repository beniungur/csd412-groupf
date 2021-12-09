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
    public class TradeEventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<AppUser> _userManager;

        public TradeEventsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TradeEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.TradeEvent.Include(o => o.PlantToTrade).Include(e => e.PlantToReceive).Include(p => p.TradeTo).ToListAsync());
        }

        // GET: TradeEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradeEvent = await _context.TradeEvent.Include(o => o.PlantToTrade).Include(e => e.PlantToReceive).Include(p => p.TradeTo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tradeEvent == null)
            {
                return NotFound();
            }

            return View(tradeEvent);
        }

        [Authorize]
        // GET: TradeEvents/Create
        public async Task<IActionResult> Create()
        {
            TradeEventView viewModel = new TradeEventView();

            viewModel.trade.Owner = await _userManager.GetUserAsync(User);

            viewModel.TraderList = await _context.AppUser.Where(u => u.Id != viewModel.trade.Owner.Id).ToListAsync();
            viewModel.PlantList = await _context.Plant.Where(o => o.Owner.Id == viewModel.trade.Owner.Id).ToListAsync();
            viewModel.ReceivingPlantList = await _context.Plant.Where(o => o.Owner.Id != viewModel.trade.Owner.Id).ToListAsync();


            return View(viewModel);
        }

        // POST: TradeEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TradeDate, TradePlant, ReceivePlant, trade, TraderId")] TradeEventView tradeInfo)
        {
            if (ModelState.IsValid)
            {
                tradeInfo.trade.PlantToTrade = await _context.Plant.FindAsync(tradeInfo.TradePlant);
                tradeInfo.trade.TradeTo = await _context.AppUser.FindAsync(tradeInfo.TraderId);
                tradeInfo.trade.PlantToReceive = await _context.Plant.FindAsync(tradeInfo.ReceivePlant);
                _context.Add(tradeInfo.trade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tradeInfo);
        }

        // GET: TradeEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradeEvent = await _context.TradeEvent.FindAsync(id);
            if (tradeEvent == null)
            {
                return NotFound();
            }
            return View(tradeEvent);
        }

        // POST: TradeEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TradeDate")] TradeEvent tradeEvent)
        {
            if (id != tradeEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tradeEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TradeEventExists(tradeEvent.Id))
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
            return View(tradeEvent);
        }

        // GET: TradeEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradeEvent = await _context.TradeEvent.Include(o => o.PlantToTrade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tradeEvent == null)
            {
                return NotFound();
            }

            return View(tradeEvent);
        }

        // POST: TradeEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tradeEvent = await _context.TradeEvent.FindAsync(id);
            _context.TradeEvent.Remove(tradeEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TradeEventExists(int id)
        {
            return _context.TradeEvent.Any(e => e.Id == id);
        }
    }
}
