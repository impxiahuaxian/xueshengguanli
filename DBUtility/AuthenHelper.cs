using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;
using System.Web.UI;

namespace Maticsoft.DBUtility
{
    public class AuthenHelper
    {

        public static void CreateTicket(string UsersName)
        {
            FormsAuthentication.SetAuthCookie(UsersName, false);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UsersName">用户标识</param>
        /// <param name="UsersData">用户数据</param>
        /// <param name="stayLogin">是否记住</param>
        /// <param name="expireTime">过期时间</param>
        /// <param name="cookiePath">路径</param>
        public static void CreateTicket(string UsersName, string UsersData, bool stayLogin, DateTime expireTime, string cookiePath)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                 1,
                 UsersName,
                 DateTime.Now,
                 expireTime,
                 stayLogin,
                 UsersData,
                 cookiePath == "" ? FormsAuthentication.FormsCookiePath : cookiePath);

            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie authCookie = new HttpCookie(
                FormsAuthentication.FormsCookieName, encryptedTicket);
            if (ticket.IsPersistent)
                authCookie.Expires = ticket.Expiration;
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        public static string GetLoginUserName()
        {
            string UsersName = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
                UsersName = HttpContext.Current.User.Identity.Name;
            return UsersName;
        }

        public static string GetLoginUsersData()
        {
            string UsersData = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsIdentity formsIdentity = HttpContext.Current.User.Identity as FormsIdentity;
                UsersData = formsIdentity.Ticket.UserData;
            }
            return UsersData;
        }

        public static bool CheckLogin()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
