using JobApplicationPortal.DAL.Data;
using JobApplicationPortal.DAL.Model;
using JobApplicationPortal.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace JobApplicationPortal.Service.Repository
{
    public class AddressDetailRepo:IAddressDetail
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AddressDetailRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public bool Any(int id)
        {
            if (_applicationDbContext.AddressDetails.Any(x => x.Id == id))
            {
                return true;
            }
            return false;
        }

        public void Create(AddressDetail addressDetails)
        {
            _applicationDbContext.AddressDetails.Add(addressDetails);
        }

        public void Delete(int id)
        {
            AddressDetail temp = _applicationDbContext.AddressDetails.Find(id);
            _applicationDbContext.Remove(temp);
        }

        public IEnumerable<AddressDetail> GetAll()
        {
            return _applicationDbContext.AddressDetails.ToList();
        }

        public AddressDetail GetById(int id)
        {
            return _applicationDbContext.AddressDetails.FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(AddressDetail addressDetails)
        {
            _applicationDbContext.Entry(addressDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
