using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plant_Management_System.Data;
using Plant_Management_System.Models;
using TimeZoneConverter;

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
            // only want it to display your plants
            AppUser owner = await _userManager.GetUserAsync(User);
            return View(await _context.CareLogEvent.Include(l => l.PlantName)
                .Where(o => o.Owner == owner).ToListAsync());
        }

        // GET: CareLogEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CareLogEvent careLogEvent = await _context.CareLogEvent.Include(i => i.PlantName).FirstOrDefaultAsync(m => m.Id == id);

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

            // get user & filter by owner so only your care logs show up
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
        public async Task<IActionResult> Create([Bind("PlantId,CareDone,DateOfCare,care")] CareLogEventView careLogInfo, string hidden)
        {
            if (ModelState.IsValid)
            {
                // get current time zone and convert to IANA
                //TimeZoneInfo localZone = TimeZoneInfo.Local;
                string tz = TZConvert.WindowsToIana(hidden);

                // get json from api as a string
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                string response = client.GetStringAsync(new Uri($"https://www.timeapi.io/api/Time/current/zone?timeZone={tz}")).Result;

                // convert string to DateTimeObj
                DateTimeObj dateTime = JsonSerializer.Deserialize<DateTimeObj>(response);

                careLogInfo.care.DateOfCare = DateTime.Parse(dateTime.dateTime);

                // assign user as owner and assign existing plant object as plant
                careLogInfo.care.Owner = await _userManager.GetUserAsync(User);
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

            
            CareLogEvent careLogEvent = await _context.CareLogEvent.Include(r => r.PlantName)
                .FirstOrDefaultAsync(m => m.Id == id);
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

            CareLogEvent careLogEvent = await _context.CareLogEvent.Include(r => r.PlantName)
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
            CareLogEvent careLogEvent = await _context.CareLogEvent.FindAsync(id);
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
