using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcFramwork.MVC
{
    public class NeoWebContext
    {
        public NeoWebContext(System.Web.HttpContext inner)
        {
            this.Inner = inner;
        }
        public System.Web.HttpContext Inner{get;set;}

        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
