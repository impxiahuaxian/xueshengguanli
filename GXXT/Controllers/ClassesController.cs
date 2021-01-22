using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GXPT.Controllers
{
    public class ClassesController : Controller
    {
        //
        // GET: /Classes/
        Maticsoft.BLL.Classes bll = new Maticsoft.BLL.Classes();
        public ActionResult Create(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                Maticsoft.Model.Classes model = new Maticsoft.Model.Classes();
                return View(model);
            }
            else
            {
                return View(bll.GetModel(Convert.ToInt32(ID)));
            }
        }

        public ActionResult Manage(Maticsoft.ViewModel.ClassesSearch model)
        {
            return View(model);
        }

        public PartialViewResult Search(Maticsoft.ViewModel.ClassesSearch model)
        {
            return PartialView(model);
        }

        public PartialViewResult List(Maticsoft.ViewModel.ClassesSearch model)
        {
            return PartialView(bll.Search(model));
        }

        [HttpPost]
        public ActionResult Edit(Maticsoft.Model.Classes model)
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
