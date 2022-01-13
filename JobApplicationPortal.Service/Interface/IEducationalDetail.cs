using JobApplicationPortal.DAL.Model;
using System.Collections.Generic;

namespace JobApplicationPortal.Service.Interface
{
    public interface IEducationalDetail
    {
        IEnumerable<EducationalDetail> GetAll();
        EducationalDetail GetById(int id);
        void Create(EducationalDetail educationalDetails);
        void Update(EducationalDetail educationalDetails);
        void Delete(int Id);
        void SaveChanges();
        bool Any(int Id);
    }
}
