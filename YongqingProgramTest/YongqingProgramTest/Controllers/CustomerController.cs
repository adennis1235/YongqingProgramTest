using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult Index()
        {
            CustomerRVModel _CustomerRVModel = new CustomerRVModel();
            _CustomerRVModel.GetAllList = _BO.GetAll();
            return View(_CustomerRVModel);
        }
        [HttpPost]
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
    }
}