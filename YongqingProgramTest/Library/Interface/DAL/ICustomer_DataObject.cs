using Library.Libray;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Interface.DAL
{
    public interface ICustomer_DataObject
    {
        List<Customer> GetAll();
        List<Customer> GetById(string Id);
        void Create(Customer item);
        void Update(Customer item);
        void Delete(Customer item);
    }
}
