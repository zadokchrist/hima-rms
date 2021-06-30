using HIMARMSLLOGIC.Logic;
using HIMARMSLLOGIC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HIMARMS.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            try
            {
                UserDepartments userDepartments = new UserDepartments();
                Processor processor = new Processor();
                userDepartments = processor.GetUserDepartments();
                if (userDepartments.IsSuccessful)
                {
                    ViewBag.UserDepartments = userDepartments.departments;
                }
                else
                {
                    ViewBag.Error = userDepartments.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection) 
        {
            try
            {
                GenericResponse response = new GenericResponse();
                SystemUser systemUser = new SystemUser();
                systemUser.fullname = Request["fullname"];
                systemUser.address = Request["address"];
                systemUser.username = Request["username"];
                systemUser.email = Request["email"];
                systemUser.department = Request["userdepartment"];
                systemUser.password= Request["username"];
                Processor processor = new Processor();
                response = processor.CreateSystemUser(systemUser);
                if (response.IsSuccessful)
                {
                    ViewBag.Message = response.ErrorMessage;
                }
                else
                {
                    ViewBag.Error = response.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }



        public ActionResult UserReport() 
        {
            try
            {
                SystemUsers systemUsers = new SystemUsers();
                Processor processor = new Processor();
                systemUsers = processor.GetSystemUsers();
                if (systemUsers.IsSuccessful)
                {
                    ViewBag.SystemUsers = systemUsers.systemUsers;
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