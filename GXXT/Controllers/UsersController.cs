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

      
    }
}
