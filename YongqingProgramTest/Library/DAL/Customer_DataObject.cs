using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Interface.DAL;
using Library.Libray;
using System.Linq;

namespace Library.DAL
{
    //class Customer_DataObject
    public class Customer_DataObject : ICustomer_DataObject, IDisposable
    {
        private DbContext _EF = null;
        public Customer_DataObject(DbContext EF)
        {
            try
            {
                if (this._EF == null)
                {
                    this._EF = EF;
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        public List<Customer> GetAll()
        {
            try
            {
                return _EF.Set<Customer>().ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public List<Customer> GetById(string Id)
        {
            try
            {
                if (Id == "")
                {
                    return _EF.Set<Customer>().Take(200).ToList();
                }
                return _EF.Set<Customer>().Where(x => x.CustomerId == Id).ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public void Create(Customer item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException("Item");
                }
                else
                {
                    _EF.Set<Customer>().Add(item);
                    _EF.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public void Update(Customer item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException("Item");
                }
                else
                {
                    _EF.Entry(item).State = EntityState.Modified;
                    _EF.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(Customer item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException("Item");
                }
                else
                {
                    _EF.Entry(item).State = EntityState.Deleted;
                    _EF.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _EF.Dispose();
                }
                disposed = true;
            }
        }
    }
}