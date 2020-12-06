using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualHostManager.Models
{
    public class Hosts
    {
        public int LineNumber { set; get; }
        public bool Status { set; get; }
        public string IpAddress { set; get; }
        public string DomainName { set; get; }
        public string Comment { set; get; }
    }
}
