using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plant_Management_System.Data;
using Plant_Management_System.Models;

namespace Plant_Management_System.Controllers
{
    public class SaleEventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<AppUser> _userManager;

        public SaleEventsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: SaleEvents
        public async Task<IActionResult> Index()
        {
            // include plant object
            return View(await _context.SaleEvent.Include(r => r.PlantForSale).ToListAsync());
        }

        // GET: SaleEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleEvent = await _context.SaleEvent.Include(r => r.PlantForSale)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleEvent == null)
            {
                return NotFound();
            }

            return View(saleEvent);
        }

        // GET: SaleEvents/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            SaleEventView viewModel = new SaleEventView();

            viewModel.sale.Owner = await _userManager.GetUserAsync(User);

            viewModel.BuyerList = await _context.AppUser.Where(u => u.Id != viewModel.sale.Owner.Id).ToListAsync();
            viewModel.PlantList = await _context.Plant.Where(o => o.Owner.Id == viewModel.sale.Owner.Id).ToListAsync();
            

            return View(viewModel);
        }

        // POST: SaleEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalePlant,ListPrice,Listing,DateListed,DateSold,BuyerId,sale")] SaleEventView saleInfo)
        {
            if (ModelState.IsValid)
            {
                saleInfo.sale.PlantForSale = await _context.Plant.FindAsync(saleInfo.SalePlant);
                saleInfo.sale.Buyer = (AppUser)await _context.Users.FindAsync(saleInfo.BuyerId);
                saleInfo.sale.PlantForSale.Owner = saleInfo.sale.Buyer;
                _context.Add(saleInfo.sale);
                _context.Update(saleInfo.sale.PlantForSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleInfo);
        }

        // GET: SaleEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleEvent = await _context.SaleEvent.FindAsync(id);
            if (saleEvent == null)
            {
                return NotFound();
            }
            return View(saleEvent);
        }

        // POST: SaleEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListPrice,Listing,DateListed,DateSold,sale")] SaleEvent saleEvent)
        {
            if (id != saleEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleEventExists(saleEvent.Id))
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
            return View(saleEvent);
        }

        // GET: SaleEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleEvent = await _context.SaleEvent.Include(r => r.PlantForSale)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleEvent == null)
            {
                return NotFound();
            }

            return View(saleEvent);
        }

        // POST: SaleEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleEvent = await _context.SaleEvent.FindAsync(id);
            _context.SaleEvent.Remove(saleEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleEventExists(int id)
        {
            return _context.SaleEvent.Any(e => e.Id == id);
        }
    }
}
