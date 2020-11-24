using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualHostManager.Models
{
    class VirtualHost
    {
        public string ServerName { set; get; }
        public string Port { set; get; }
        public string Directory { set; get; }
        public string DirectoryConfig { set; get; }
        public bool Status { set; get; }

    }
}
