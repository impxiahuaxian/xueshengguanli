using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using System.Web.Mvc;

namespace MVC
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// 拓展方法，多表单
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="formName">提交表单名</param>
        /// <returns></returns>
        public static MvcForm BeginForm(this HtmlHelper htmlHelper, string formName)
        {
            return BeginForm(htmlHelper, null, formName);
        }
        /// <summary>
        /// 拓展方法，多表单
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="form">form</param>
        /// <param name="formName">formName</param>
        /// <returns></returns>
        public static MvcForm BeginForm(this HtmlHelper htmlHelper, MvcForm form, string formName)
        {
            if (String.IsNullOrEmpty(formName))
                throw new ArgumentNullException("formName");

            if (form == null)
                form = htmlHelper.BeginForm();

            htmlHelper.ViewContext.Writer.WriteLine("<input name=\"n.__formName\" type=\"hidden\" value=\"" + formName + "\" />");

            return form;
        }
        /// <summary>
        /// 拓展方法，多表单
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="FormName">表单名</param>
        /// <param name="Action">ActionName</param>
        /// <param name="Controller">ControllerName</param>
        /// <returns></returns>
        public static MvcForm BeginForm(this HtmlHelper htmlHelper, string FormName,string Action,string Controller)
        {
            MvcForm form = htmlHelper.BeginForm(Action, Controller);
            return BeginForm(htmlHelper, form, FormName);
        }
    }
}