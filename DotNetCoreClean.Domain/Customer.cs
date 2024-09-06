using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreClean.Domain
{
    public class Customer
    {
        public int CustomerNumber { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
    }
}
