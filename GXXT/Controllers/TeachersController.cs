using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GXPT.Controllers
{
    public class TeachersController : Controller
    {
        //
        // GET: /Teachers/
        Maticsoft.BLL.Teachers bll = new Maticsoft.BLL.Teachers();
        public ActionResult Create(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                Maticsoft.Model.Teachers model = new Maticsoft.Model.Teachers();
                return View(model);
            }
            else
            {
                return View(bll.GetModel(Convert.ToInt32(ID)));
            }
        }

        public ActionResult Manage(Maticsoft.ViewModel.TeachersSearch model)
        {
            return View(model);
        }

        public PartialViewResult Search(Maticsoft.ViewModel.TeachersSearch model)
        {
            return PartialView(model);
        }

        public PartialViewResult List(Maticsoft.ViewModel.TeachersSearch model)
        {
            return PartialView(bll.Search(model));
        }

        [HttpPost]
        public ActionResult Edit(Maticsoft.Model.Teachers model)
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
