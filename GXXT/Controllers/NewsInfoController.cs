using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class NewsInfoController : Controller
    {
        //
        // GET: /NewsInfo/
        Maticsoft.BLL.NewsInfo bll = new Maticsoft.BLL.NewsInfo();
     
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                Maticsoft.Model.NewsInfo model = new Maticsoft.Model.NewsInfo();

                return View(model);
            }
            else
            {
                return View(bll.GetModel(Convert.ToInt32(ID)));
            }
        }

        public ActionResult NewsDetail(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                Maticsoft.Model.NewsInfo model = new Maticsoft.Model.NewsInfo();

                return View(model);
            }
            else
            {
                return View(bll.GetModel(Convert.ToInt32(ID)));
            }
        }



        public ActionResult Manage(Maticsoft.ViewModel.NewsInfoSearch model)
        {
            return View(model);
        }

        public PartialViewResult Search(Maticsoft.ViewModel.NewsInfoSearch model)
        {
            return PartialView(model);
        }

        public PartialViewResult List(Maticsoft.ViewModel.NewsInfoSearch model)
        {
            if (Session["UserType"]=="用户")
            {
                model.UserID = Maticsoft.BLL.Admin.GetNowUserID();
            }
            return PartialView(bll.Search(model));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Maticsoft.Model.NewsInfo model)
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
        public JsonResult GetIndexNews(string Category, string flag)
        {
            return Json(bll.GetModelList(" Str1='" + Category + "'"));

        }
    }
}
