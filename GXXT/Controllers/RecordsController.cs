using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 家政.Controllers
{
    public class RecordsController : Controller
    {
        //
        // GET: /Records/
        Maticsoft.BLL.Records bll = new Maticsoft.BLL.Records();
        public ActionResult Create(string ID, string OrderID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                Maticsoft.Model.Records model = new Maticsoft.Model.Records();
                return View(model);
            }
            else
            {
                return View(bll.GetModel(Convert.ToInt32(ID)));
            }
        }

        public ActionResult Manage(Maticsoft.ViewModel.RecordsSearch model)
        {
            return View(model);
        }

        public PartialViewResult Search(Maticsoft.ViewModel.RecordsSearch model)
        {
            return PartialView(model);
        }

        public PartialViewResult List(Maticsoft.ViewModel.RecordsSearch model)
        {
            return PartialView(bll.Search(model));
        }

        [HttpPost]
        public ActionResult Edit(Maticsoft.Model.Records model)
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
