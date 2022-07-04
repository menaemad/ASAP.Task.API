using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAPSystem.Assignment.Web.Models.Person
{
    public class SerarchPersonModel
    {
        public SerarchPersonModel()
        {
            PageSize = int.MaxValue;
        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
