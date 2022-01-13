using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApplicationPortal.DAL.Data;
using JobApplicationPortal.DAL.Model;
using JobApplicationPortal.Service.Interface;

namespace JobApplicationPortal.Controllers
{
    public class AddressDetailController : Controller
    {
        private readonly IAddressDetail _addressDetail;
        public AddressDetailController(IAddressDetail addressDetail)
        {
            _addressDetail = addressDetail;
        }

        // GET: AddressDetail
        public IActionResult Index()
        {
            return View(_addressDetail.GetAll());
        }

        // GET: AddressDetail/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressDetail = _addressDetail.GetById(id);
            if (addressDetail == null)
            {
                return NotFound();
            }

            return View(addressDetail);
        }

        // GET: AddressDetail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddressDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,UserDetailsId,Country,State,City,PostalCode,AddressLine1,AddressLine2")] AddressDetail addressDetail)
        {
            if (ModelState.IsValid)
            {
                _addressDetail.Create(addressDetail);

                return RedirectToAction(nameof(Index));
            }
            return View(addressDetail);
        }

        // GET: AddressDetail/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressDetail = _addressDetail.GetById(id);
            if (addressDetail == null)
            {
                return NotFound();
            }
            return View(addressDetail);
        }

        // POST: AddressDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserDetailId,Country,State,City,PostalCode,AddressLine1,AddressLine2")] AddressDetail addressDetail)
        {
            if (id != addressDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _addressDetail.Update(addressDetail);
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!AddressDetailsExists(addressDetail.Id))
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
            return View(addressDetail);
        }

        // GET: AddressDetail/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressDetail = _addressDetail.GetById(id);
            if (addressDetail == null)
            {
                return NotFound();
            }

            return View(addressDetail);
        }

        // POST: AddressDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var addressDetail = _addressDetail.GetById(id);
            _addressDetail.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool AddressDetailsExists(int id)
        {
            return _addressDetail.Any(id);
        }
    }
}
