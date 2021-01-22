using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code.Controllers
{
    public class StudentsController : Controller
    {
        //
        // GET: /Students/
        Maticsoft.BLL.Students bll = new Maticsoft.BLL.Students();
        public ActionResult Create(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                Maticsoft.Model.Students model = new Maticsoft.Model.Students();
                return View(model);
            }
            else
            {
                return View(bll.GetModel(Convert.ToInt32(ID)));
            }
        }

        public ActionResult KCreate(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                Maticsoft.Model.Students model = new Maticsoft.Model.Students();
                return View(model);
            }
            else
            {
                return View(bll.GetModel(Convert.ToInt32(ID)));
            }
        }

        public ActionResult Manage(Maticsoft.ViewModel.StudentsSearch model)
        {
            return View(model);
        }

        public PartialViewResult Search(Maticsoft.ViewModel.StudentsSearch model)
        {
            return PartialView(model);
        }

        public PartialViewResult List(Maticsoft.ViewModel.StudentsSearch model)
        {
            return PartialView(bll.Search(model));
        }

        [HttpPost]
        public ActionResult Edit(Maticsoft.Model.Students model)
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
        public JsonResult GetStu(string UserSFZ)
        {
            return Json(bll.GetModelList(" UserSFZ='"+UserSFZ+"'").FirstOrDefault());

        }
      
    }
}
