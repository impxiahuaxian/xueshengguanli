using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
namespace MVC
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FormActionSelectorAttribute : ActionNameSelectorAttribute
    {
        private readonly string[] _formName;

        public FormActionSelectorAttribute(params string[] formName)
        {
            if (formName == null)
                throw new ArgumentNullException("formName");

            _formName = formName;
        }

        public string[] FormName
        {
            get { return _formName; }
        }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, System.Reflection.MethodInfo methodInfo)
        {
            return _formName.Contains(controllerContext.RequestContext.HttpContext.Request.Form["n.__formName"]);
        }
    }
}
