using EvidencijaRadnogVremena.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EvidencijaRadnogVremena.Controllers
{
    [System.Web.Mvc.Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewModel.ManagerDashboardViewModel model = new ViewModel.ManagerDashboardViewModel(User);
                return View(model);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Markets()
        {
            ViewBag.Message = "Lista marketa";

            return View();
        }
        public PartialViewResult _GetPartialView()
        {
            return PartialView("~/Views/Home/_Partial.cshtml");
        }

        // POST: /Home/GoToBrake
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        public JsonResult GoToBrake([FromBody] UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    System.Threading.Thread.Sleep(2000);
                    var resultCheckUser = RadnikManager.CheckPassword(model);
                    if (!resultCheckUser.Success)
                    {
                        model.IsValid = false;
                        model.Message = resultCheckUser.Message;
                        return Json(model, JsonRequestBehavior.AllowGet);
                    }

                    var result = RadnikManager.GoToBrake(model);
                    model.IsValid = true;
                    if (!result.Success)
                    {
                        model.Message = result.Message;
                    }
                }
                catch (Exception e)
                {
                    model.IsValid = false;
                    model.Message = e.Message;
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        // POST: /Home/BackFromBreak
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        public JsonResult BackFromBreak([FromBody] UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    System.Threading.Thread.Sleep(2000);
                    var resultCheckUser = RadnikManager.CheckPassword(model);
                    if (!resultCheckUser.Success)
                    {
                        model.IsValid = false;
                        model.Message = resultCheckUser.Message;
                        return Json(model, JsonRequestBehavior.AllowGet);
                    }

                    var result = RadnikManager.BackFromBreak(model);
                    if (!result.Success)
                    {
                        model.Message = result.Message;
                    }
                    else
                    {
                        model.IsValid = true;
                    }
                }
                catch (Exception e)
                {
                    model.IsValid = false;
                    model.Message = e.Message;
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // POST: /Home/CheckOut
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        public JsonResult CheckOut([FromBody] UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    System.Threading.Thread.Sleep(2000);
                    var resultCheckUser = RadnikManager.CheckPassword(model);
                    if (!resultCheckUser.Success)
                    {
                        model.IsValid = false;
                        model.Message = resultCheckUser.Message;
                        return Json(model, JsonRequestBehavior.AllowGet);
                    }

                    var result = RadnikManager.RadnikCheckOut(model);
                    model.IsValid = true;
                    if (!result.Success)
                    {
                        model.Message = result.Message;
                    }
                }
                catch (Exception e)
                {
                    model.IsValid = false;
                    model.Message = e.Message;
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // POST: /Home/CheckIn
        [System.Web.Http.HttpPost]
        [System.Web.Http.Authorize]
        public JsonResult CheckIn(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    System.Threading.Thread.Sleep(2000);
                    var resultCheckUser = RadnikManager.CheckPassword(model);
                    if (!resultCheckUser.Success)
                    {
                        model.IsValid = false;
                        model.Message = resultCheckUser.Message;
                        return Json(model, JsonRequestBehavior.AllowGet);
                    }

                    var result = RadnikManager.RadnikCheckIn(model);
                    model.IsValid = true;
                    if (!result.Success)
                    {
                        model.Message = result.Message;
                    }
                }
                catch (Exception e)
                {
                    model.IsValid = false;
                    model.Message = e.Message;
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public class UserViewModel
        {
            public int RadnikId { set; get; }
            public string LocalMachine { set; get; }
            public string Password { get; set; }
            public bool IsValid { get; set; }
            public string Message { get; set; }
        }
    }
}