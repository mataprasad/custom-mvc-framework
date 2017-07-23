using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MvcFramwork.MVC
{
    public static class NeoActionInvoker
    {
        public static void Invoke(NeoWebContext context)
        {
            var pathSegments = context.Inner.Request.Url.Segments;
            if (pathSegments != null && pathSegments.Length >= 3)
            {
                string controllerName = pathSegments[1];
                if (string.IsNullOrWhiteSpace(controllerName))
                {
                    throw new Exception("400");
                }
                string action = pathSegments[2];
                if (string.IsNullOrWhiteSpace(action))
                {
                    throw new Exception("400");
                }

                controllerName = controllerName.ToLower().Trim('/').Trim();
                action = action.ToLower().Trim('/').Trim();

                context.ActionName = action;
                context.ControllerName = controllerName;

                controllerName = controllerName + "controller";

                Type tController = AppDomain.CurrentDomain.GetAssemblies().Select
                    (
                    A =>
                    {
                        return A.GetTypes().Where(P => P.BaseType == typeof(NeoControllerBase) && string.Equals(controllerName, P.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    }
                    ).Where(P => P != null).FirstOrDefault();


                if (tController == null)
                {
                    throw new Exception("400");
                }

                object objController = Activator.CreateInstance(tController);

                MethodInfo mInit = tController.GetMethods().Where(P => string.Equals("Init", P.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                mInit.Invoke(objController, new object[] { context });


                MethodInfo mAction = tController.GetMethods().Where(P => string.Equals(action, P.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (mAction == null)
                {
                    throw new Exception("400");
                }

                var verbs = mAction.GetCustomAttributes();


                var actionParams = mAction.GetParameters();
                if (actionParams != null && actionParams.Count() > 0)
                {
                    var modelObj = actionParams.FirstOrDefault();
                    if (modelObj != null)
                    {
                        Type modelType = modelObj.ParameterType;
                        var obj = Activator.CreateInstance(modelType);
                        new ModelBinding.DefaultModelBinder(context).Populate(ref obj);
                        mAction.Invoke(objController, new object[] { obj });
                    }
                }
                else
                {
                    mAction.Invoke(objController, null);
                }

            }

        }
    }
}
