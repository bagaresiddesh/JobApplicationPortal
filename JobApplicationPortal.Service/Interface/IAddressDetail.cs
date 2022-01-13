using JobApplicationPortal.DAL.Model;
using System.Collections.Generic;

namespace JobApplicationPortal.Service.Interface
{
    public interface IAddressDetail
    {
        IEnumerable<AddressDetail> GetAll();
        AddressDetail GetById(int id);
        void Create(AddressDetail addressDetails);
        void Update(AddressDetail addressDetails);
        void Delete(int Id);
        bool Any(int Id);
    }
}
