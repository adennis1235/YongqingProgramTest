using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YongqingProgramTest.Models.DTO;
using YongqingProgramTest.Repository.DAL;

namespace YongqingProgramTest.Models.DAL
{
    public class CustomerDAO : ICustomerDAO, IDisposable
    {
        private NorthwindContext _EF = null;

        public CustomerDAO(NorthwindContext EF)
        {
            try
            {
                if (this._EF == null)
                {
                    this._EF = EF;
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public void Create(Customer item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    //item.CustomerID = Guid.NewGuid().ToString();
                    _EF.Set<Customer>().Add(item);
                    _EF.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public void Delete(Customer item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _EF.Entry(item).State = EntityState.Deleted;
                    _EF.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        public List<Customer> GetAll()
        {
            try
            {
                return _EF.Set<Customer>().ToList();
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<Customer> GetById(string Id)
        {
            try
            {
                if (Id == String.Empty)
                {
                    return _EF.Set<Customer>().ToList();
                }
                return _EF.Set<Customer>().Where(x => x.CustomerId == Id).ToList();
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public void Update(Customer item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _EF.Entry(item).State = EntityState.Modified;
                    _EF.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
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
                if (disposed)
                {
                    _EF.Dispose();
                }
                disposed = true;
            }
        }
    }
}
