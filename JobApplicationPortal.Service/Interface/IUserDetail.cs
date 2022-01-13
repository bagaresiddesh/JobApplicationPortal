using JobApplicationPortal.DAL.Model;
using System.Collections.Generic;

namespace JobApplicationPortal.Service.Interface
{
    public interface IUserDetail
    {
        IEnumerable<UserDetail> GetAll();
        UserDetail GetById(int id);
        void Create(UserDetail userDetails);
        void Update(UserDetail userDetails);
        void Delete(int Id);
        bool Any(int Id);
    }
}
