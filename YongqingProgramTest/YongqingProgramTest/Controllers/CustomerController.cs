using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YongqingProgramTest.Repository.BLL;
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
        public IActionResult Index()
        {
            CustomerRVModel _CustomerRVModel = new CustomerRVModel();
            _CustomerRVModel.GetAllList = _BO.GetAll();
            return View(_CustomerRVModel);
        }
    }
}