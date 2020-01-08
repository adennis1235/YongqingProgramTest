using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YongqingProgramTest.Models.DTO;
using YongqingProgramTest.Repository.BLL;
using YongqingProgramTest.ViewModel.Out;

namespace YongqingProgramTest.WebApi
{
    [Route("api/[controller]/[action]")]
    public class CustomerController : Controller
    {
        private ICustomerBLO _BO = null;
        public CustomerController(ICustomerBLO BO)
        {
            _BO = BO;
        }
        [HttpGet]
        public Out_ApiResponse GetAll()
        {
            return new Out_ApiResponse(HttpStatusCode.OK, _BO.GetAll(), null);
        }
        //[HttpGet]
        //public DataSourceResult GetAll_Kendo([FromForm] DataSourceRequest args)
        //{
        //    try
        //    {
        //        return _BO.GetAll().ToDataSourceResult(args);
        //    }
        //    catch (Exception e)
        //    {
        //        var ex = e.Message;
        //        throw new NotImplementedException(e.Message);
        //    }
        //}
        [HttpPost]
        public Out_ApiResponse Create(Customer Item)
        {
            Out_ApiResponse result;
            try
            {
                _BO.Create(Item);
                result = new Out_ApiResponse(HttpStatusCode.OK, "Success", null);
                return result;
            }
            catch (Exception ex)
            {

                string err = this.ControllerContext.HttpContext.ToString() + "發生:" + ex.Message;
                result = new Out_ApiResponse(HttpStatusCode.BadRequest, null, err);
                return result;
            }
        }

        [HttpPost]
        public Out_ApiResponse Update(Customer Item)
        {
            Out_ApiResponse result;
            try
            {
                _BO.Update(Item);
                result = new Out_ApiResponse(HttpStatusCode.OK, "Success", null);
                return result;
            }
            catch (Exception ex)
            {

                string err = this.ControllerContext.HttpContext.ToString() + "發生:" + ex.Message;
                result = new Out_ApiResponse(HttpStatusCode.BadRequest, null, err);
                return result;
            }
        }

        [HttpPost]
        public Out_ApiResponse Delete(Customer Item)
        {
            Out_ApiResponse result;
            try
            {
                _BO.Delete(Item);
                result = new Out_ApiResponse(HttpStatusCode.OK, "Success", null);
                return result;
            }
            catch (Exception ex)
            {

                string err = this.ControllerContext.HttpContext.ToString() + "發生:" + ex.Message;
                result = new Out_ApiResponse(HttpStatusCode.BadRequest, null, err);
                return result;
            }
        }
    }
}
