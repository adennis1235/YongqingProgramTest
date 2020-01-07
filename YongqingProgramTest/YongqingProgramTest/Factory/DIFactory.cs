using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YongqingProgramTest.Models.BLL;
using YongqingProgramTest.Models.DAL;
using YongqingProgramTest.Models.DTO;
using YongqingProgramTest.Repository.BLL;
using YongqingProgramTest.Repository.DAL;

namespace YongqingProgramTest.Factory
{
    public class DIFactory :  Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            SetUpRegistration(builder);
            //builder.Register(c => new Admin_Object(c.Resolve<IAdmin_DataObject>())).As<IAdmin_Object>();
        }
        private static void SetUpRegistration(ContainerBuilder builder)
        {
            builder.RegisterType<NorthwindContext>().As<NorthwindContext>();

            builder.RegisterType<CustomerDAO>().As<ICustomerDAO>();
            builder.RegisterType<CustomerBLO>().As<ICustomerBLO>();
        }
    }
}
