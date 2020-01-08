using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YongqingProgramTest.Models.DTO;
using YongqingProgramTest.Repository.BLL;
using YongqingProgramTest.Repository.DAL;

namespace YongqingProgramTest.Models.BLL
{
    public class CustomerBLO : ICustomerBLO
    {
        private ICustomerDAO _DO = null;

        public CustomerBLO(ICustomerDAO DO)
        {
            this._DO = DO;
        }
        public List<Customer> GetAll()
        {
            try
            {
                return _DO.GetAll();
            }
            catch (Exception ex)
            {
                return null;
                //throw new Exception(ex.Message);
            }

        }
        public List<Customer> GetById(string Id)
        {
            try
            {
                return _DO.GetById(Id);

            }
            catch (Exception ex)
            {
                return null;
                //throw new Exception(ex.Message);
            }

        }
        public void Create(Customer item)
        {
            try
            {
                _DO.Create(item);
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
        }
        public void Update(Customer item)
        {
            try
            {
                _DO.Update(item);
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }

        }
        public void Delete(Customer item)
        {
            try
            {
                _DO.Delete(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
    }
}
