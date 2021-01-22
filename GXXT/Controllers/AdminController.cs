using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GXPT.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        Maticsoft.BLL.Admin bll = new Maticsoft.BLL.Admin();
        public ActionResult Create(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                Maticsoft.Model.Admin model = new Maticsoft.Model.Admin();
                return View(model);
            }
            else
            {
                return View(bll.GetModel(Convert.ToInt32(ID)));
            }
        }

        public ActionResult Manage(Maticsoft.ViewModel.AdminSearch model)
        {
            return View(model);
        }

        public PartialViewResult Search(Maticsoft.ViewModel.AdminSearch model)
        {
            return PartialView(model);
        }

        public PartialViewResult List(Maticsoft.ViewModel.AdminSearch model)
        {
            return PartialView(bll.Search(model));
        }

        [HttpPost]
        public ActionResult Edit(Maticsoft.Model.Admin model)
        {
            bll.Edit(model);
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public JsonResult Del(string ID)
        {
            return Json(bll.Delete(Convert.ToInt32(ID)));

        }
    }
}
