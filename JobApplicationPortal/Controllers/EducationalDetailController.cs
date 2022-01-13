using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApplicationPortal.DAL.Data;
using JobApplicationPortal.DAL.Model;

namespace JobApplicationPortal.Controllers
{
    public class EducationalDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducationalDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EducationalDetail
        public async Task<IActionResult> Index()
        {
            return View(await _context.EducationalDetails.ToListAsync());
        }

        // GET: EducationalDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalDetail = await _context.EducationalDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationalDetail == null)
            {
                return NotFound();
            }

            return View(educationalDetail);
        }

        // GET: EducationalDetail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationalDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserDetailId,SSCPassingYear,HSCPassingYear,GraduationPassingYear,PostGraduationPassingYear,IsYearGap,IsActiveBacklogs,AcademicProjects")] EducationalDetail educationalDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationalDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationalDetail);
        }

        // GET: EducationalDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalDetail = await _context.EducationalDetails.FindAsync(id);
            if (educationalDetail == null)
            {
                return NotFound();
            }
            return View(educationalDetail);
        }

        // POST: EducationalDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserDetailId,SSCPassingYear,HSCPassingYear,GraduationPassingYear,PostGraduationPassingYear,IsYearGap,IsActiveBacklogs,AcademicProjects")] EducationalDetail educationalDetail)
        {
            if (id != educationalDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationalDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationalDetailExists(educationalDetail.Id))
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
            return View(educationalDetail);
        }

        // GET: EducationalDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalDetail = await _context.EducationalDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationalDetail == null)
            {
                return NotFound();
            }

            return View(educationalDetail);
        }

        // POST: EducationalDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationalDetail = await _context.EducationalDetails.FindAsync(id);
            _context.EducationalDetails.Remove(educationalDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationalDetailExists(int id)
        {
            return _context.EducationalDetails.Any(e => e.Id == id);
        }
    }
}
