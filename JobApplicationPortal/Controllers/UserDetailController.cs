using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApplicationPortal.DAL.Data;
using JobApplicationPortal.DAL.Model;

namespace JobApplicationPortal.Controllers
{
    public class UserDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserDetail
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserDetails.ToListAsync());
        }

        // GET: UserDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = await _context.UserDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDetail == null)
            {
                return NotFound();
            }

            return View(userDetail);
        }

        // GET: UserDetail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Gender,DateOfBirth,Email,Phone")] UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userDetail);
        }

        // GET: UserDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = await _context.UserDetails.FindAsync(id);
            if (userDetail == null)
            {
                return NotFound();
            }
            return View(userDetail);
        }

        // POST: UserDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Gender,DateOfBirth,Email,Phone")] UserDetail userDetail)
        {
            if (id != userDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDetailExists(userDetail.Id))
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
            return View(userDetail);
        }

        // GET: UserDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = await _context.UserDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDetail == null)
            {
                return NotFound();
            }

            return View(userDetail);
        }

        // POST: UserDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userDetail = await _context.UserDetails.FindAsync(id);
            _context.UserDetails.Remove(userDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDetailExists(int id)
        {
            return _context.UserDetails.Any(e => e.Id == id);
        }
    }
}
