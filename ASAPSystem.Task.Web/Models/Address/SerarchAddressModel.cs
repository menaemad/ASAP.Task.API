using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAPSystem.Assignment.Web.Models.Address
{
    public class SerarchAddressModel
    {
        public SerarchAddressModel()
        {
            PageSize = int.MaxValue;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
