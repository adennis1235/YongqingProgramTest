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
                //_BOErr = BOErr;
            }
            public void Create(Customer item)
            {
                try
                {
                    _DO.Create(item);
                }
                catch (Exception ex)
                {
                    //if (EnumException.launchExp == true)
                    //    throw new Exception();

                    //ErrLogDMO.ErrorModel(GlobalObjs.errLog, GetType().Name, MethodBase.GetCurrentMethod().Name, ex);
                    //_BOErr.AddErrLogProc(GlobalObjs.errLog);

                    //EnumException.launchExp = true;
                    throw new Exception(ex.Message);
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
                    //if (EnumException.launchExp == true)
                    //    throw new Exception();

                    //ErrLogDMO.ErrorModel(GlobalObjs.errLog, GetType().Name, MethodBase.GetCurrentMethod().Name, ex);
                    //_BOErr.AddErrLogProc(GlobalObjs.errLog);

                    //EnumException.launchExp = true;
                    throw new Exception(ex.Message);
                }
            }

            public List<Customer> GetAll()
            {
                try
                {
                    return _DO.GetAll();
                }
                catch (Exception ex)
                {
                    //if (EnumException.launchExp == true)
                    //    throw new Exception();

                    //ErrLogDMO.ErrorModel(GlobalObjs.errLog, GetType().Name, MethodBase.GetCurrentMethod().Name, ex);
                    //_BOErr.AddErrLogProc(GlobalObjs.errLog);

                    //EnumException.launchExp = true;
                    throw new Exception(ex.Message);
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
                    //if (EnumException.launchExp == true)
                    //    throw new Exception();

                    //ErrLogDMO.ErrorModel(GlobalObjs.errLog, GetType().Name, MethodBase.GetCurrentMethod().Name, ex);
                    //_BOErr.AddErrLogProc(GlobalObjs.errLog);

                    //EnumException.launchExp = true;
                    throw new Exception(ex.Message);
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
                    //if (EnumException.launchExp == true)
                    //    throw new Exception();

                    //ErrLogDMO.ErrorModel(GlobalObjs.errLog, GetType().Name, MethodBase.GetCurrentMethod().Name, ex);
                    //_BOErr.AddErrLogProc(GlobalObjs.errLog);

                    //EnumException.launchExp = true;
                    throw new Exception(ex.Message);
                }

            }
        }
    }
