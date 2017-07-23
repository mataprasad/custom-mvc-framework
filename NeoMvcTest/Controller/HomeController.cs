using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcFramwork.MVC;
using System.Collections;

namespace NeoMvcTest
{
    public class HomeController : NeoControllerBase
    {
        [NeoActionVerb.GET]
        public INeoActionResult Index(Person p)
        {
            var data = new ArrayList();
            for (int i = 0; i < 100; i++)
            {
                data.Add(new System.Web.UI.WebControls.ListItem { Text = "Mata" + i, Value = i.ToString() });
            }
            return View("Index", data);
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}
