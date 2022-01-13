using JobApplicationPortal.DAL.Data;
using JobApplicationPortal.DAL.Model;
using JobApplicationPortal.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace JobApplicationPortal.Service.Repository
{
    public class UserDetailRepo : IUserDetail
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public int Count()
        {
            return _applicationDbContext.UserDetails.Count();
        }
        public UserDetailRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Create(UserDetail userDetails)
        {
            _applicationDbContext.UserDetails.Add(userDetails);
        }

        public void Delete(int id)
        {
            UserDetail temp = _applicationDbContext.UserDetails.Find(id);
            _applicationDbContext.UserDetails.Remove(temp);
        }

        public IEnumerable<UserDetail> GetAll()
        {
            return _applicationDbContext.UserDetails.ToList();
        }

        public UserDetail GetById(int id)
        {
            return _applicationDbContext.UserDetails.FirstOrDefault(x => x.Id == id);
        }

        public void Update(UserDetail userDetails)
        {
            _applicationDbContext.Entry(userDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public bool Any(int id)
        {
            if (_applicationDbContext.UserDetails.Any(x => x.Id == id))
            {
                return true;
            }
            return false;
        }
    }
}
