//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace GXXT.Controllers
//{
//    public class WapController : Controller
//    {
//        //
//        // GET: /Wap/
//        Maticsoft.BLL.Users bll = new Maticsoft.BLL.Users();
//        Maticsoft.BLL.Goods gbll = new Maticsoft.BLL.Goods();
//        Maticsoft.BLL.Orders obll = new Maticsoft.BLL.Orders();
//        Maticsoft.BLL.Enjoys ebll = new Maticsoft.BLL.Enjoys();
       

//        //
//        // GET: /Wap/Details/5

//        public ActionResult Detail(string ID)
//        {
//            return View(gbll.GetModel(Convert.ToInt32(ID)));
//        }

//        public ActionResult Medit()
//        {
//            return View(bll.GetModel(Convert.ToInt32(Maticsoft.BLL.Users.GetNowUserID())));
//        }

//        //
//        // GET: /Wap/Create

//        public ActionResult Regist()
//        {
//            return View();
//        }

//        public ActionResult Category()
//        {
//            return View();
//        }

//        public PartialViewResult List(Maticsoft.ViewModel.GoodsSearch model)
//        {
//            return PartialView(gbll.Search(model));
//        }

//        public PartialViewResult Search(Maticsoft.ViewModel.GoodsSearch model)
//        {
//            return PartialView(model);
//        }

//        public ActionResult Index(Maticsoft.ViewModel.GoodsSearch model)
//        {
//            return View(model);
//        }

//        public ActionResult CZ()
//        {
//            return View();
//        }

//        public ActionResult Mindex()
//        {
//            if (Maticsoft.BLL.Users.GetNowUserID()=="")
//            {
//                return Redirect("/Wap/Regist");
//            }
//            return View(bll.GetModel(Convert.ToInt32(Maticsoft.BLL.Users.GetNowUserID())));
//        }

//        public ActionResult Gywm()
//        {
//            return View();
//        }

//        public ActionResult TX()
//        {
//            return View();
//        }

//        public ActionResult Create(string ID)
//        {
//            if (Maticsoft.BLL.Users.GetNowUserID() == "")
//            {
//                return Redirect("/Wap/Regist");
//            }
//            if (string.IsNullOrEmpty(ID))
//            {
//                Maticsoft.Model.Goods model = new Maticsoft.Model.Goods();
//                return View(model);
//            }
//            else
//            {
//                return View(gbll.GetModel(Convert.ToInt32(ID)));
//            }
//        }

//        public ActionResult OCreate(string ID)
//        {
//            if (string.IsNullOrEmpty(ID))
//            {
//                Maticsoft.Model.Goods model = new Maticsoft.Model.Goods();
//                return View(model);
//            }
//            else
//            {
//                return View(gbll.GetModel(Convert.ToInt32(ID)));
//            }
//        }

//        [HttpPost]
//        public JsonResult WYCZ(string je)
//        {
//            Maticsoft.Model.Users model = bll.GetModel(Convert.ToInt32(Maticsoft.BLL.Users.GetNowUserID()));
//            model.Balance = (Convert.ToInt32(model.Balance) + Convert.ToInt32(je)).ToString();

//            return Json(bll.Update(model));
//        }

//        [HttpPost]
//        public JsonResult WYTX(string je)
//        {
//            Maticsoft.Model.Users model = bll.GetModel(Convert.ToInt32(Maticsoft.BLL.Users.GetNowUserID()));
//            if (Convert.ToInt32(model.Balance)<Convert.ToInt32(je))
//            {
//                return Json(false);  
//            }
           
//            model.Balance = (Convert.ToInt32(model.Balance) - Convert.ToInt32(je)).ToString();

//            return Json(bll.Update(model));
//        }

//        [HttpPost]
//        public ActionResult GoodsEdit(Maticsoft.Model.Goods model)
//        {
//            if (model.ID==0)
//            {
//                model.UserID = Maticsoft.BLL.Users.GetNowUserID();
//                model.State = "待出租";
//                model.Str1 = DateTime.Now.ToString();
//                gbll.Add(model);
//            }
//            else
//            {
//                gbll.Update(model);   
//            }
//            return Redirect("/Wap/mmanage") ;
//        }

//        [HttpPost]
//        public JsonResult DelGoods(string ID)
//        {
//            Maticsoft.Model.Goods model = gbll.GetModel(Convert.ToInt32(ID));
//            if (model.State!="待出租")
//            {
//              return Json(false);  
//            }
//            else
//            {
//                return Json(gbll.Delete(Convert.ToInt32(ID)));
//            }
            
//        }

//        [HttpPost]
//        public JsonResult UpdateGoods(string ID)
//        {
//            Maticsoft.Model.Goods model = gbll.GetModel(Convert.ToInt32(ID));
//            model.Str1 = DateTime.Now.ToString();
//            return Json(gbll.Update(model));
         

//        }

//        //[HttpPost]
//        //public JsonResult regist(string Phone, string Password, string Code)
//        //{
//        //    if (Session["checkcode"].ToString() != Code)
//        //    {
//        //        return Json(false);
//        //    }
//        //    return Json(bll.register(Phone, Password));
//        //}

//        //[HttpPost]
//        //public JsonResult getpassword(string Phone, string Password, string Code)
//        //{
//        //    if (Session["checkcode"].ToString() != Code)
//        //    {
//        //        return Json(false);
//        //    }
//        //    return Json(bll.getpassword(Phone, Password));
//        //}

//        [HttpPost]
//        public JsonResult EditPassword(string Major, string Class, string Sex, string Age, string Name, string Phone, string StuPSD)
//        {
//            Maticsoft.Model.Users model = bll.GetModel(Convert.ToInt32(Maticsoft.BLL.Users.GetNowUserID()));
//            if (!string.IsNullOrEmpty(StuPSD))
//            {
//                model.StuPSD = StuPSD;
//            }
//            model.Major = Major;
//            model.Class = Class;
//            model.Sex = Sex;
//            model.Age = Age;
//            model.Name = Name;
//            model.Phone = Phone;
//            return Json(bll.Update(model));
//        }



//        [HttpPost]
//        public JsonResult GetStu()
//        {
//            return Json(bll.GetModel(Convert.ToInt32(Maticsoft.BLL.Users.GetNowUserID())));
//        }

//        public PartialViewResult msearch(Maticsoft.ViewModel.GoodsSearch model)
//        {
//            return PartialView(model);
//        }

//        public PartialViewResult mlist(Maticsoft.ViewModel.GoodsSearch model)
//        {
//            return PartialView(gbll.MSearch(model));
//        }

//        public ActionResult mmanage(Maticsoft.ViewModel.GoodsSearch model)
//        {
//            return View(model);
//        }

//        [HttpPost]
//        public ActionResult OrderEdit(Maticsoft.Model.Goods model)
//        {
//            Maticsoft.Model.Users student = bll.GetModel(Convert.ToInt32(Maticsoft.BLL.Users.GetNowUserID()));
//            if (Convert.ToInt32(student.Balance)<Convert.ToInt32(model.Price))
//            {
//                return  Redirect("/Wap/CZ");
//            }
//            else
//            {
//                student.Balance = (Convert.ToInt32(student.Balance) - Convert.ToInt32(model.Price)).ToString();
//                student.Deposit = (Convert.ToInt32(student.Deposit) + Convert.ToInt32(model.Price)).ToString();
//                bll.Update(student);
//            }
//            Maticsoft.Model.Goods goods = gbll.GetModel(model.ID);
//            goods.PurchaserType = model.PurchaserType;
//            goods.Str2 = model.Str2;
//            goods.PurchaserName = model.PurchaserName;
//            goods.PurchaserPhone = model.PurchaserPhone;
//            goods.YJ = model.YJ;
//            goods.PurchaserID = Maticsoft.BLL.Users.GetNowUserID();
//            if ( goods.PurchaserName=="日租")
//            {
//                goods.TotalPrice = (Convert.ToInt32(goods.RPrice) * Convert.ToInt32(goods.Str2)).ToString();
//                goods.StartTime = DateTime.Now.ToString();
//                goods.EndTime = DateTime.Now.AddDays(Convert.ToInt32(goods.Str2)).ToString();
//            }
//            else
//            {
//                goods.TotalPrice = goods.YPrice;
//                goods.StartTime = DateTime.Now.ToString();
//                goods.EndTime = DateTime.Now.AddMonths(1).ToString();    
//            }
//            goods.State = "出租中";
//            gbll.Update(goods);

//            Maticsoft.Model.Orders orders = new Maticsoft.Model.Orders();
//            orders.UserName = goods.Contacts;
//            orders.UsersPhone = goods.Phone;
//            orders.UserID = goods.UserID;
//            orders.PUserID = Maticsoft.BLL.Users.GetNowUserID();
//            orders.PPhone = goods.PurchaserPhone;
//            orders.PName = goods.PurchaserName;
//            orders.PType = goods.PurchaserType;
//            orders.StartTime = goods.StartTime;
//            orders.EndTime = goods.EndTime;
//            orders.TotalPrice = goods.TotalPrice;
//            orders.YJ = goods.Price;
//            orders.UID = goods.ID.ToString();
//            orders.GoodName = goods.Name;
//            orders.Str1 ="已付款";
//            orders.Str2 = goods.YJ;
//            orders.Str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
//            obll.Add(orders);
//            return Redirect("/Wap/omanage?PUserID="+Maticsoft.BLL.Users.GetNowUserID()); 
//        }

//        public PartialViewResult osearch(Maticsoft.ViewModel.OrdersSearch model)
//        {
//            return PartialView(model);
//        }

//        public PartialViewResult olist(Maticsoft.ViewModel.OrdersSearch model)
//        {
//            return PartialView(obll.Search(model));
//        }

//        public ActionResult omanage(Maticsoft.ViewModel.OrdersSearch model)
//        {
//            return View(model);
//        }

//        public PartialViewResult elist(Maticsoft.ViewModel.GoodsSearch model)
//        {
//            string IDs = "";
//            List<Maticsoft.Model.Enjoys> list = ebll.GetModelList(" UserID='" + Maticsoft.BLL.Users.GetNowUserID() + "'");
//            foreach (var item in list)
//            {
//                if (IDs == "")
//                {
//                     IDs = IDs +item.UID;
//                }
//                else
//                {
//                    IDs = IDs + "," + item.UID;
//                }
              
//            }
//            if (IDs=="")
//            {
//                 return PartialView(null);
//            }
//            else
//    {
//                 return PartialView(gbll.GetModelList(" ID in("+IDs+")"));
//    }
           
//        }

//        public ActionResult emanage(Maticsoft.ViewModel.GoodsSearch model)
//        {
//            return View(model);
//        }

//        [HttpPost]
//        public JsonResult DelOrder(string ID)
//        {
//            Maticsoft.Model.Orders order = obll.GetModel(Convert.ToInt32(ID));
//            order.Str1 = "已取消";
//            obll.Update(order);
//            Maticsoft.Model.Goods goods = gbll.GetModel(Convert.ToInt32(order.UID));
//            goods.PurchaserType ="";
//            goods.Str2 = "";
//            goods.PurchaserName = "";
//            goods.PurchaserPhone = "";
//            goods.YJ = "";
//            goods.PurchaserID = "";
//                goods.TotalPrice = "";
//                goods.StartTime = "";
//                goods.EndTime = "";
//                goods.State = "待出租";
//                gbll.Update(goods);

//                Maticsoft.Model.Users smodel = bll.GetModel(Convert.ToInt32(order.PUserID));
//                smodel.Balance = (Convert.ToInt32(smodel.Balance) + Convert.ToInt32(order.YJ)).ToString();
//                smodel.Deposit = (Convert.ToInt32(smodel.Deposit) - Convert.ToInt32(order.YJ)).ToString();
//                bll.Update(smodel);
//                return Json(true);
//        }

//        [HttpPost]
//        public JsonResult FHOrder(string ID)
//        {
//            Maticsoft.Model.Orders order = obll.GetModel(Convert.ToInt32(ID));
//            order.Str1 = "已发货";
//            obll.Update(order);
//            return Json(true);
//        }

//        [HttpPost]
//        public JsonResult DY(string ID)
//        {
//            Maticsoft.Model.Enjoys model = ebll.GetModelList(" UserID='"+Maticsoft.BLL.Users.GetNowUserID()+"'").FirstOrDefault();
//            if (model!=null)
//            {
//               return Json(ebll.Delete(model.ID));
//            }
//            else
//            {
//                model = new Maticsoft.Model.Enjoys();
//                model.UserID = Maticsoft.BLL.Users.GetNowUserID();
//                model.UID = ID;
//                return Json(ebll.Add(model));
//            }
//        }

//        [HttpPost]
//        public JsonResult GetSC(string ID)
//        {
//            Maticsoft.Model.Enjoys model = ebll.GetModelList(" UserID='" + Maticsoft.BLL.Users.GetNowUserID() + "'").FirstOrDefault();
//            if (model != null)
//            {
//                return Json(true);
//            }
//            else
//            {
//                return Json(false);
//            }
//        }

//        [HttpPost]
//        public JsonResult SHOrder(string ID)
//        {
//            Maticsoft.Model.Orders order = obll.GetModel(Convert.ToInt32(ID));
//            order.Str1 = "已收货";
//            obll.Update(order);
//            return Json(true);
//        }

//        [HttpPost]
//        public JsonResult WCOrder(string ID)
//        {
            
//            Maticsoft.Model.Orders orders = obll.GetModel(Convert.ToInt32(ID)); ;
//            orders.Str1 = "共享完成";
//            obll.Update(orders);

//            Maticsoft.Model.Goods goods = gbll.GetModel(Convert.ToInt32(orders.UID));
//            goods.PurchaserType = "";
//            goods.Str2 = "";
//            goods.PurchaserName = "";
//            goods.PurchaserPhone = "";
//            goods.YJ = "";
//            goods.PurchaserID = "";
//            goods.TotalPrice = "";
//            goods.StartTime = "";
//            goods.EndTime = "";
//            goods.State = "待出租";
//            gbll.Update(goods);

//            Maticsoft.Model.Users student1 = bll.GetModel(Convert.ToInt32(Maticsoft.BLL.Users.GetNowUserID()));
//            student1.Deposit = (Convert.ToInt32(student1.Deposit) - Convert.ToInt32(goods.Price)).ToString();
//            student1.Balance = (Convert.ToInt32(student1.Balance) + Convert.ToInt32(goods.Price) - Convert.ToInt32(orders.TotalPrice)).ToString();
//            bll.Update(student1);

//            Maticsoft.Model.Users student2 = bll.GetModel(Convert.ToInt32(orders.UserID));
//            student2.Balance = (Convert.ToInt32(student2.Balance) +  Convert.ToInt32(orders.TotalPrice)).ToString();
//            bll.Update(student2);
//            return Json(true);
//        }
//    }
//}
