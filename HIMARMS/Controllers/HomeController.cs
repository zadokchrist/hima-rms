using HIMARMSLLOGIC.Logic;
using HIMARMSLLOGIC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HIMARMS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form) 
        {
            try
            {
                SystemUsers systemUsers = new SystemUsers();
                SystemUser systemUser = new SystemUser();
                systemUser.username = Request["username"];
                systemUser.password = Request["password"];
                Processor processor = new Processor();
                systemUsers = processor.GetUserByUsernameAndPwd(systemUser);
                if (systemUsers.IsSuccessful)
                {
                    Session["Uid"] = systemUsers.systemUsers[0].RecordId;
                    Session["Uname"] = systemUsers.systemUsers[0].username;
                    Session["FullName"] = systemUsers.systemUsers[0].fullname;
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.Error = systemUsers.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
    }
}