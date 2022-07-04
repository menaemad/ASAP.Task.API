using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ASAPSystem.Assignment.Web.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            IsSuccessed = true;
            StatusCode = (int)HttpStatusCode.OK;
        }
        public object Data { get; set; }
        public bool IsSuccessed { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        
    }
}
