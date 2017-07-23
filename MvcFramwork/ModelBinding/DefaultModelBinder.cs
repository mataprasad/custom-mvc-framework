using MvcFramwork.MVC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MvcFramwork.ModelBinding
{
    public class DefaultModelBinder
    {
        private NeoWebContext context = null;
        public DefaultModelBinder(NeoWebContext context)
        {
            this.context = context;
        }
        public void Populate(ref object model)
        {
            Type t = model.GetType();
            if (!(model is ValueType))
            {
                var postedData = ParseQueryString();
                postedData.Concat(ParseForm());
                //object objModel = Activator.CreateInstance(t);
                PropertyInfo[] properties = t.GetProperties();
                foreach (PropertyInfo item in properties)
                {
                    if (postedData.ContainsKey(item.Name))
                    {
                        item.SetValue(model, postedData[item.Name]);
                    }
                }
            }
        }


        private Dictionary<string, string> ParseQueryString()
        {
            var query = context.Inner.Request.QueryString;
            return query.AllKeys.Select(P =>
            {
                return new KeyValuePair<string,string>(P, query[P]);
            }).ToDictionary(P => P.Key, P => P.Value);
        }

        private Dictionary<string, string> ParseForm()
        {
            var query = context.Inner.Request.Form;
            return query.AllKeys.Select(P =>
            {
                return new KeyValuePair<string, string>(P, query[P]);
            }).ToDictionary(P => P.Key, P => P.Value);
        }
    }


}
