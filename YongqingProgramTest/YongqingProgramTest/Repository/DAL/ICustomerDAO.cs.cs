using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YongqingProgramTest.Models.DTO;

namespace YongqingProgramTest.Repository.DAL
{
    public interface ICustomerDAO
    {
        List<Customer> GetAll();
        List<Customer> GetById(string Id);
        void Create(Customer item);
        void Update(Customer item);
        void Delete(Customer item);
    }
}
