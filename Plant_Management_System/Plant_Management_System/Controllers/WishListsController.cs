using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Plant_Management_System.Data;
using Plant_Management_System.Models;
using TimeZoneConverter;

namespace Plant_Management_System.Controllers
{
    public class WishListsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<AppUser> _userManager;

        public WishListsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: WishLists
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                ViewBag.currUserId = user.Id;
            }
            return View(await _context.WishList.Include(u => u.User).ToListAsync());
        }

        // GET: WishLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishList = await _context.WishList
                .FirstOrDefaultAsync(m => m.WishListId == id);
            if (wishList == null)
            {
                return NotFound();
            }

            return View(wishList);
        }

        [Authorize]
        // GET: WishLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WishLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WishListId,DateAdded,PlantName,Budget")] WishList wishList, string hidden)
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

                wishList.DateAdded = DateTime.Parse(dateTime.dateTime);

                wishList.User = await _userManager.GetUserAsync(User);

                _context.Add(wishList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wishList);
        }

        [Authorize]
        // GET: WishLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishList = await _context.WishList.FindAsync(id);
            if (wishList == null)
            {
                return NotFound();
            }
            return View(wishList);
        }

        // POST: WishLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WishListId,DateAdded,PlantName,Budget")] WishList wishList)
        {
            if (id != wishList.WishListId)
            {
                return NotFound();
            }

            //wishList.User = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wishList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishListExists(wishList.WishListId))
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
            return View(wishList);
        }

        [Authorize]
        // GET: WishLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                ViewBag.currUserId = user.Id;
            }

            var wishList = await _context.WishList.Include(u => u.User)
                .FirstOrDefaultAsync(m => m.WishListId == id);
            if (wishList == null)
            {
                return NotFound();
            }

            return View(wishList);
        }

        // POST: WishLists/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wishList = await _context.WishList.FindAsync(id);
            _context.WishList.Remove(wishList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WishListExists(int id)
        {
            return _context.WishList.Any(e => e.WishListId == id);
        }
    }
}
