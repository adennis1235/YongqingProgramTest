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
        public IActionResult CreateCustomer(CustomerVModel model)
        {
            CustomerRVModel _CustomerRVModel = new CustomerRVModel();
            Customer item = new Customer()
            {
                CustomerId = model.CustomerId,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName,
                Phone = model.Phone,
            };
                _BO.Create(item);
            return RedirectToAction("Index", new { CustomerId = model.CustomerId });
        }
        [HttpPost]
        public IActionResult UpdateCustomer(CustomerVModel model)
        {
            CustomerRVModel _CustomerRVModel = new CustomerRVModel();
            Customer item = new Customer()
            {
                CustomerId = model.CustomerId,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName,
                Phone = model.Phone,
            };
            _BO.Update(item);
            return RedirectToAction("Index", new { CustomerId = model.CustomerId });
        }
        [HttpPost]
        public IActionResult DeleteCustomer(string CustomerId)
        {
            CustomerRVModel _CustomerRVModel = new CustomerRVModel();
            Customer item = new Customer()
            {
                CustomerId = CustomerId,
            };
            _BO.Delete(item);
            return RedirectToAction("Index");
        }
    }
}