using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YongqingProgramTest.Models.DTO;

namespace YongqingProgramTest.ViewModel.Out
{
    public class CustomerRVModel
    {
       public List<Customer> GetAllList { get; set; }
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string ActionType { get; set; }
    }
}
