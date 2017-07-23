using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcFramwork.MVC
{
    public class NeoControllerBase
    {
        protected NeoWebContext context = null;
        public void Init(NeoWebContext context)
        {
            this.context = context;
        }
        public INeoActionResult View(string view)
        {

          
            context.Inner.Server.Transfer("~/Views/" + context.ControllerName + "/" + view + ".aspx");
            //context.Inner.RewritePath(("~/app/Views/" + context.ControllerName + "/" + view + ".aspx"));

            return new EmptyNeoActionResult();
        }

        public INeoActionResult View(string view, object model)
        {
            context.Inner.Items.Add("Model", model);
            context.Inner.Server.Transfer("~/Views/" + context.ControllerName + "/" + view + ".aspx");

            return new EmptyNeoActionResult();
        }

        public INeoActionResult Json(object data)
        {


            return new EmptyNeoActionResult();
        }

    }
}
