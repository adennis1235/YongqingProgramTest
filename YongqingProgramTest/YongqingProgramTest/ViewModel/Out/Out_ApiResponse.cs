using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace YongqingProgramTest.ViewModel.Out
{
    public class Out_ApiResponse
    {
        public Out_ApiResponse(HttpStatusCode code, object data, object err)
        {
            StatusCode = code;
            Result = data;
            Error = err;
        }
        public HttpStatusCode StatusCode { get; set; }
        public object Result { get; set; }
        public object Error { get; set; }
    }
}
