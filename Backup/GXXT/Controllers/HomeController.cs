using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GXPT.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Maticsoft.BLL.Admin bll = new Maticsoft.BLL.Admin();
        Maticsoft.BLL.Users sbll = new Maticsoft.BLL.Users();
        Maticsoft.BLL.Students stbll = new Maticsoft.BLL.Students();
        Maticsoft.BLL.NewsInfo nbll = new Maticsoft.BLL.NewsInfo();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CXXJ()
        {
            return View();
        }

        public ActionResult XJXX(string UserSFZ)
        {
            TempData["UserSFZ"] = UserSFZ;
            return View();
        }

        public ActionResult CJCX()
        {
            return View();
        }

        public ActionResult CJXX(string UserSFZ)
        {
            TempData["UserSFZ"] = UserSFZ;
            return View();
        }

        public ActionResult Regist()
        {
            return View();
        }

        public ActionResult List(Maticsoft.ViewModel.NewsInfoSearch model)
        {
            TempData["Category"] = model.Category;
            return View(nbll.Search(model));
        }

        public ActionResult Detail(string ID)
        {
            return View(nbll.GetModel(Convert.ToInt32(ID)));
        }

        public ActionResult Login()
        {
            int num;
            char code;
            string checkcode = String.Empty;
            System.Random random = new Random();

            //用i设置验证码的字数
            for (int i = 0; i < 4; i++)
            {
                num = random.Next();
                //num=偶数时，用数字表示；num=奇数时，用字母表示
                code = (char)('0' + (char)(num % 10));

                checkcode += code.ToString();
            }

            Session["checkcode"] = checkcode;
            TempData["checkcode"] = checkcode;
            return View();
        }

        [HttpPost]
        public JsonResult LogOff()
        {
            return Json(bll.LogOut());
        }

      
        [HttpPost]
        public JsonResult Login(string LoginName, string LoginPwd)
        {
            string UserType = "";
            bool IsLogin = bll.Login(LoginName, LoginPwd, false);
            if (!IsLogin)
            {
                IsLogin = sbll.Login(LoginName, LoginPwd);
                if (IsLogin)
                {
                    UserType = "用户"; 
                }
            }
            else
            {
                UserType = "管理员";
            }
            Session["UserType"] = UserType;
            return Json(IsLogin);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ContentResult uploadHead(string FormID, string TaskID)
        {
            try
            {
                HttpPostedFileBase httpFile = Request.Files["FileData"];
                if (httpFile != null)
                {
                    string NowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string fileName = NowTime + "_" + httpFile.FileName;
                    string uploadPath = Server.MapPath("\\Scripts/kindeditor/attached/image\\") + fileName;
                    httpFile.SaveAs(uploadPath);
                 return Content(fileName);
                }
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
            return Content("0");
        }

        [HttpPost]
        public JsonResult regist(string UsersName, string UserPSD, string Name,string QQ)
        {
            return Json(sbll.Regist(UsersName, UserPSD, Name,QQ));
        }

        [HttpPost]
        public JsonResult slogin(string UsersName, string StuPSD)
        {
            return Json(sbll.Login(UsersName, StuPSD));
        }
    }
}
