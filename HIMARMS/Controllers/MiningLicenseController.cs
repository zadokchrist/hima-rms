using HIMARMSLLOGIC.Logic;
using HIMARMSLLOGIC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HIMARMS.Controllers
{
    public class MiningLicenseController : Controller
    {
        // GET: MiningLicense
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
                Licence licence = new Licence();
                GenericResponse response = new GenericResponse();
                Processor processor = new Processor();
                licence.leasetype = Request["leasetype"];
                licence.referencenum = Request["referencenum"];
                licence.issuingauthority = Request["issuingauthority"];
                licence.technicalscope = Request["technicalscope"];
                licence.geographicalscope = Request["geographicalscope"];
                licence.issuedate = Request["issuedate"];
                licence.dateofexpiry = Request["dateofexpiry"].ToString();
                licence.LicenceAcquisitionCost = Request["LicenceAcquisitionCost"];
                licence.RenewalCost = Request["RenewalCost"];
                licence.OtherRelatedCost = Request["OtherRelatedCost"];
                licence.ResponsibleDepartment = Request["ResponsibleDepartment"];
                licence.ImpactedDepartments = Request["ImpactedDepartments"];
                licence.averagerenewal = Request["averagerenewal"];
                licence.TermsAndConditions = Request["TermsAndConditions"];
                licence.AverageRenewalTime = Request["AverageRenewalTime"];
                licence.RemarksAndComments = Request["RemarksAndComments"];
                response = processor.CreateLicence(licence);
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

        public ActionResult ViewLicenses() 
        {
            try
            {
                Licences licences = new Licences();
                Processor processor = new Processor();
                licences = processor.GetLicences();
                if (licences.IsSuccessful)
                {
                    ViewBag.Licences = licences.licences;
                }
                else
                {
                    ViewBag.Error = licences.ErrorMessage;
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