using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcFramwork.Routing
{
    public class NeoRouteHandler : System.Web.IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(System.Web.HttpContext context)
        {
            MvcFramwork.MVC.NeoActionInvoker.Invoke(new MVC.NeoWebContext(context));
        }
    }
}
