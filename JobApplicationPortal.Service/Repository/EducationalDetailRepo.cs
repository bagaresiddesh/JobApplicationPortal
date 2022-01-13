using JobApplicationPortal.DAL.Data;
using JobApplicationPortal.DAL.Model;
using System.Collections.Generic;
using System.Linq;


namespace JobApplicationPortal.Service.Repository
{
    public class EducationalDetailRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EducationalDetailRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public bool Any(int id)
        {
            if (_applicationDbContext.EducationalDetails.Any(x => x.Id == id))
            {
                return true;
            }
            return false;
        }

        public void Create(EducationalDetail educationalDetails)
        {
            _applicationDbContext.EducationalDetails.Add(educationalDetails);
        }

        public void Delete(int id)
        {
            EducationalDetail temp = _applicationDbContext.EducationalDetails.Find(id);
            _applicationDbContext.EducationalDetails.Remove(temp);
        }

        public IEnumerable<EducationalDetail> GetAll()
        {
            return _applicationDbContext.EducationalDetails.ToList();
        }

        public EducationalDetail GetById(int id)
        {
            return _applicationDbContext.EducationalDetails.FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(EducationalDetail educationalDetails)
        {
            _applicationDbContext.Entry(educationalDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
