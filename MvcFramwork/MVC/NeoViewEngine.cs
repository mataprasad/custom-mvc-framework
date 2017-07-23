using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcFramwork.MVC
{
    public class NeoViewEngine : System.Web.UI.Page
    {
        public ViewBag ViewBag = null;
        public object Model = null;
        public NeoViewEngine()
        {
            this.ViewBag = new ViewBag(Context);
            this.Model = ViewBag["Model"];
        }
        
    }

    public class ViewBag
    {
        private System.Web.HttpContext context = null;
        public ViewBag(System.Web.HttpContext context)
        {
            this.context = context;
        }
        public  void Add(string key, object value)
        {
            context.Items.Add(key, value);
        }


        public  object this[string key]
        {
            get
            {
                return context.Items[key];
            }
            set
            {
                 context.Items[key] = value;
            }
        }

     
       
    }
}
