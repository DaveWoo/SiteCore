using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCore.WebApi.Utils
{
    public class AppSettings
    {
        public string token { get; set; }
        public bool EnableForwardHeader { get; set; }
    }
}
