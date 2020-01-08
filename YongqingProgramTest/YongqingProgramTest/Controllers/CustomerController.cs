using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YongqingProgramTest.Models.DTO;
using YongqingProgramTest.Repository.BLL;
using YongqingProgramTest.ViewModel.In;
using YongqingProgramTest.ViewModel.Out;

namespace YongqingProgramTest.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBLO _BO = null;
        public CustomerController(ICustomerBLO BO)
        {
            _BO = BO;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    CustomerRVModel _CustomerRVModel = new CustomerRVModel();
        //    _CustomerRVModel.GetAllList = _BO.GetAll();
        //    return View(_CustomerRVModel);
        //}
        //[HttpPost]
        public IActionResult Index(CustomerVModel model)
        {
            CustomerRVModel _CustomerRVModel = new CustomerRVModel();
            if (string.IsNullOrEmpty(model.CustomerId))
            {
                _CustomerRVModel.GetAllList = _BO.GetAll();
            }
            else
            {
                _CustomerRVModel.GetAllList = _BO.GetById(model.CustomerId);
            }
            _CustomerRVModel.CustomerId = model.CustomerId;
            return View(_CustomerRVModel);
        }
        [HttpPost]
        public IActionResult Edit(CustomerVModel model)
        {
            CustomerRVModel _CustomerRVModel = new CustomerRVModel();
            if (!string.IsNullOrEmpty(model.CustomerId) && model.ActionType == "U")
            {
                _CustomerRVModel.GetAllList = _BO.GetById(model.CustomerId);
                if (_CustomerRVModel.GetAllList.Any())
                {
                    _CustomerRVModel.CustomerId = _CustomerRVModel.GetAllList[0].CustomerId;
                    _CustomerRVModel.CompanyName = _CustomerRVModel.GetAllList[0].CompanyName;
                    _CustomerRVModel.ContactName = _CustomerRVModel.GetAllList[0].ContactName;
                    _CustomerRVModel.Phone = _CustomerRVModel.GetAllList[0].Phone;
                }               
            }
            _CustomerRVModel.ActionType = model.ActionType;
            return View(_CustomerRVModel);
        }
        [HttpPost]
        public IActionResult SaveEdit(CustomerVModel model)
        {
            CustomerRVModel _CustomerRVModel = new CustomerRVModel();
            Customer item = new Customer()
            {
                CustomerId= model.CustomerId,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName,
                Phone = model.Phone,
            };
            if (model.ActionType == "A")
            {
                _BO.Create(item);
            }
            else if (model.ActionType == "U")
            {
               _BO.Update(item);
            }
            else if (model.ActionType == "D")
            {
                _BO.Delete(item);
            }
            return RedirectToAction("Index",new  { CustomerId= model.CustomerId });
        }
    }
}