using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GXPT.Controllers
{
    public class WorkController : Controller
    {
        //
        // GET: /Work/
        Maticsoft.BLL.Admin bll = new Maticsoft.BLL.Admin();
        Maticsoft.BLL.Users ubll = new Maticsoft.BLL.Users();


        public ActionResult Index()
        {
            string UserID = Maticsoft.BLL.Admin.GetNowUserID();
            if (string.IsNullOrEmpty(UserID))
            {
                return Redirect("/Home/Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Top()
        {
            return View();
        }

    

        public ActionResult Left()
        {
            return View();
        }



        public ActionResult Footer()
        {
            return View();
        }

        public ActionResult EditPsd()
        {
            return View();
        }

        public ActionResult GRXX()
        {
            return View(ubll.GetModel(Convert.ToInt32(Maticsoft.BLL.Admin.GetNowUserID())));
        }

        public ActionResult Upload(string ID, string Name)
        {
            TempData["ID"] = ID;
            TempData["Name"] = Name;
            return View();
        }

      

        [HttpPost]
        public JsonResult EditMM(string UserPSD, string Name,string Age,string Sex,string Major,string Address,string Remark,string PicID,string QQ)
        {
            Maticsoft.Model.Users model = ubll.GetModel(Convert.ToInt32(Maticsoft.BLL.Admin.GetNowUserID()));
            if (!string.IsNullOrEmpty(model.UserPSD))
            {
                model.UserPSD = UserPSD;
            }
            model.UserName = Name;
            model.Age = Age;
            model.Sex = Sex;
            model.Major = Major;
            model.Address = Address;
            model.Remark = Remark;
            model.PicID = PicID;
            model.QQ = QQ;
            return Json(ubll.Update(model));
        }

      



    }
}
