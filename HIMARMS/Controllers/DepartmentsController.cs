using HIMARMSLLOGIC.Logic;
using HIMARMSLLOGIC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HIMARMS.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments
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
                Department department = new Department();
                department.departmentname = Request["departmentname"];
                department.departmenthead = "";
                Processor processor = new Processor();
                response = processor.CreateUserDepartment(department);
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

        public ActionResult DepartmentReport() 
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
    }
}