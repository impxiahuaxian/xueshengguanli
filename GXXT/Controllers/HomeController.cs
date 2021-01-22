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
        Maticsoft.BLL.Teachers tbll = new Maticsoft.BLL.Teachers();
        Maticsoft.BLL.NewsInfo nbll = new Maticsoft.BLL.NewsInfo();
        Maticsoft.BLL.LeaveMessage lbll = new Maticsoft.BLL.LeaveMessage();
        public ActionResult Index()
        {
            return View();
        }/// <summary>
         /// 留言板
         /// </summary>
         /// <returns></returns>
        public ActionResult LeaveMessage(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                Maticsoft.Model.LeaveMessage model = new Maticsoft.Model.LeaveMessage();
                return View(model);
            }
            else 
            { 
            return View();
            }
        }/// <summary>
         /// 留言板添加
         /// </summary>
         /// <returns></returns>
        public ActionResult Add(Maticsoft.Model.LeaveMessage model)
        {
            lbll.Add(model);
            return RedirectToAction("Manage");
        }
        /// <summary>
        ///留言板Manage模块 
        /// </summary>
        /// <returns></returns>
        public ActionResult Manage()
        {
            return View();
        }/// <summary>
        /// 留言板的查找功能
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Search()
        {
            return PartialView();
        }
        public PartialViewResult List2(Maticsoft.ViewModel.LeaveMessageSearch model)
        {
            return PartialView(lbll.Search(model));
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
            //判断是不是管理员
            bool IsLogin = bll.Login(LoginName, LoginPwd, false);
            if (!IsLogin)
            {
                //判断是不是学生
                IsLogin = sbll.Login(LoginName, LoginPwd);
                if (IsLogin)
                {
                    UserType = "用户"; 
                }
                else
                {
                    IsLogin = tbll.Login(LoginName, LoginPwd);
                    if (IsLogin)
                    {
                         UserType = "教师"; 
                    }
                }
            }
            else
            {
                UserType = "管理员";
            }
            Session["UserType"] = UserType;
            var result = Json(IsLogin);
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
