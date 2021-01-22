using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GXPT.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/
        Maticsoft.BLL.Users bll = new Maticsoft.BLL.Users();
        Maticsoft.BLL.Enjoys ebll = new Maticsoft.BLL.Enjoys();

        [HttpPost]
        public JsonResult DY(string ID)
        {
            if (Maticsoft.BLL.Users.GetNowUserID()=="")
            {
                 return Json(false);
            }
            Maticsoft.Model.Enjoys model = ebll.GetModelList(" UserID='" + Maticsoft.BLL.Users.GetNowUserID() + "'").FirstOrDefault();
            if (model != null)
            {
                return Json(ebll.Delete(model.ID));
            }
            else
            {
                model = new Maticsoft.Model.Enjoys();
                model.UserID = Maticsoft.BLL.Users.GetNowUserID();
                model.UID = ID;
                return Json(ebll.Add(model));
            }
        }

        [HttpPost]
        public JsonResult GetSC(string ID)
        {
            Maticsoft.Model.Enjoys model = ebll.GetModelList(" UserID='" + Maticsoft.BLL.Users.GetNowUserID() + "' and UID='" + ID + "'").FirstOrDefault();
            if (model != null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public ActionResult Create(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                Maticsoft.Model.Users model = new Maticsoft.Model.Users();
                return View(model);
            }
            else
            {
                return View(bll.GetModel(Convert.ToInt32(ID)));
            }
        }

        public ActionResult Manage(Maticsoft.ViewModel.Usersearch model)
        {
            return View(model);
        }

        public PartialViewResult Search(Maticsoft.ViewModel.Usersearch model)
        {
            return PartialView(model);
        }

        public PartialViewResult List(Maticsoft.ViewModel.Usersearch model)
        {
            return PartialView(bll.Search(model));
        }

        [HttpPost]
        public ActionResult Edit(Maticsoft.Model.Users model)
        {
            bll.Edit(model);
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public JsonResult Del(string ID)
        {
         
            return Json(bll.Delete(Convert.ToInt32(ID)));

        }

        [HttpPost]
        public JsonResult DelEnjoy(string ID)
        {

            return Json(ebll.Delete(Convert.ToInt32(ID)));

        }
    }
}
