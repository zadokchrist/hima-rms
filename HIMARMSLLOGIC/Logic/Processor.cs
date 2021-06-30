using HIMARMSLLOGIC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMARMSLLOGIC.Logic
{
    public class Processor
    {
        DatabaseHandler dh = new DatabaseHandler();
        DataTable table;

        public GenericResponse CreateSystemUser(SystemUser user) 
        {
            GenericResponse response = new GenericResponse();
            try
            {
                dh.RegisterUser(user.fullname, user.address, user.username, user.email, user.department, user.password);
                response.IsSuccessful = true;
                response.ErrorMessage = "SYSTEM USER CREATED SUCCESSFULLY";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public SystemUsers GetUserByUsernameAndPwd(SystemUser sysyser)
        {
            SystemUsers systemUsers = new SystemUsers();
            try
            {
                table = dh.GetUserByUsernameAndPwd(sysyser.username, sysyser.password);
                if (table.Rows.Count > 0)
                {
                    List<SystemUser> users = new List<SystemUser>();
                    foreach (DataRow dr in table.Rows)
                    {
                        SystemUser systemUser = new SystemUser();
                        systemUser.RecordId = dr["RecordId"].ToString();
                        systemUser.Active = bool.Parse(dr["Active"].ToString());
                        systemUser.address = dr["address"].ToString();
                        systemUser.department = dr["department"].ToString();
                        systemUser.email = dr["email"].ToString();
                        systemUser.fullname = dr["fullname"].ToString();
                        systemUser.password = dr["password"].ToString();
                        systemUser.username = dr["username"].ToString();
                        users.Add(systemUser);
                    }
                    systemUsers.IsSuccessful = true;
                    systemUsers.ErrorMessage = "SUCCESS";
                    systemUsers.systemUsers = users;
                }
                else
                {
                    systemUsers.IsSuccessful = false;
                    systemUsers.ErrorMessage = "INVALID USERNAME OR PASSWORD";
                }
            }
            catch (Exception ex)
            {
                systemUsers.IsSuccessful = false;
                systemUsers.ErrorMessage = ex.Message;
            }
            return systemUsers;
        }

        public SystemUsers GetSystemUsers() 
        {
            SystemUsers systemUsers = new SystemUsers();
            try
            {
                table = dh.GetSystemUsers();
                if (table.Rows.Count>0)
                {
                    List<SystemUser> users = new List<SystemUser>();
                    foreach (DataRow dr in table.Rows)
                    {
                        SystemUser systemUser = new SystemUser();
                        systemUser.Active = bool.Parse(dr["Active"].ToString());
                        systemUser.address = dr["address"].ToString();
                        systemUser.department = dr["department"].ToString();
                        systemUser.email = dr["email"].ToString();
                        systemUser.fullname = dr["fullname"].ToString();
                        systemUser.password = dr["password"].ToString();
                        systemUser.username = dr["username"].ToString();
                        users.Add(systemUser);
                    }
                    systemUsers.IsSuccessful = true;
                    systemUsers.ErrorMessage = "SUCCESS";
                    systemUsers.systemUsers = users;
                }
                else
                {
                    systemUsers.IsSuccessful = false;
                    systemUsers.ErrorMessage = "NO USER DEPARTMENTS FOUND";
                }
            }
            catch (Exception ex)
            {
                systemUsers.IsSuccessful = true;
                systemUsers.ErrorMessage = ex.Message;
            }
            return systemUsers;
        }

        public GenericResponse CreateUserDepartment(Department department) 
        {
            GenericResponse response = new GenericResponse();
            try
            {
                dh.CreateUserDepartment(department.departmentname, department.departmenthead);
                response.IsSuccessful = true;
                response.ErrorMessage = "USER DEPARTMENT CREATED SUCCESSFULLY";
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccessful = false;
            }
            return response;
        }

        public UserDepartments GetUserDepartments() 
        {
            UserDepartments departments = new UserDepartments();
            try
            {
                table = dh.GetUserDepartments();
                List<Department> departments1 = new List<Department>();
                if (table.Rows.Count>0)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        Department department = new Department();
                        department.RecordId = dr["RecordId"].ToString();
                        department.Active = bool.Parse(dr["Active"].ToString());
                        //department.departmenthead = dr["departmenthead"].ToString();
                        department.departmentname = dr["departmentname"].ToString();
                        department.RecordDate = dr["RecordDate"].ToString();

                        departments1.Add(department);
                    }
                    departments.departments = departments1;
                    departments.ErrorMessage = "SUCCESS";
                    departments.IsSuccessful = true;
                }
                else
                {
                    departments.IsSuccessful = false;
                    departments.ErrorMessage = "NO USER DEPARTMENTS FOUND";
                }
            }
            catch (Exception ex)
            {
                departments.ErrorMessage = ex.Message;
                departments.IsSuccessful = false;
            }
            return departments;
        }

        public GenericResponse CreateLicence(Licence licence) 
        {
            GenericResponse response = new GenericResponse();
            try
            {
                dh.CreateLicence(licence.leasetype, licence.referencenum, licence.issuingauthority,
                    licence.technicalscope, licence.geographicalscope, licence.issuedate, licence.dateofexpiry,
                    licence.LicenceAcquisitionCost, licence.RenewalCost, licence.OtherRelatedCost,
                    licence.ResponsibleDepartment, licence.ImpactedDepartments, licence.averagerenewal, licence.TermsAndConditions,licence.AverageRenewalTime,
                    licence.RemarksAndComments) ;
                response.ErrorMessage = "LICENCE REGISTERED SUCCESSFULLY";
                response.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccessful = false;
            }
            return response;
        }

        public Licences GetLicences() 
        {
            Licences licences = new Licences();
            try
            {
                table = dh.GetLicences();
                if (table.Rows.Count>0)
                {
                    List<Licence> licences1 = new List<Licence>();
                    foreach (DataRow dr in table.Rows)
                    {
                        Licence licence = new Licence();
                        licence.RecordId = dr["RecordId"].ToString();
                        licence.averagerenewal = dr["AverageRenewalTime"].ToString();
                        licence.dateofexpiry = dr["ExpiryDate"].ToString();
                        licence.geographicalscope = dr["geographicalscope"].ToString();
                        licence.ImpactedDepartments = dr["ImpactedDepartments"].ToString();
                        licence.issuedate = dr["issuedate"].ToString();
                        licence.issuingauthority = dr["IssuingRegulator"].ToString();
                        licence.leasetype = dr["TypeofLicence"].ToString();
                        licence.LicenceAcquisitionCost = dr["LicenceAcquisitionCost"].ToString();
                        licence.OtherRelatedCost = dr["OtherRelatedCost"].ToString();
                        licence.RecordDate = dr["RecordDate"].ToString();
                        licence.referencenum = dr["ReferenceNumber"].ToString();
                        licence.RemarksAndComments = dr["RemarksAndComments"].ToString();
                        licence.RenewalCost = dr["RenewalCost"].ToString();
                        licence.ResponsibleDepartment = dr["ResponsibleDepartment"].ToString();
                        licence.technicalscope = dr["technicalscope"].ToString();
                        licence.TermsAndConditions = dr["TermsAndConditions"].ToString();                                                                    
                        licences1.Add(licence);
                    }
                    licences.IsSuccessful = true;
                    licences.licences = licences1;
                    licences.ErrorMessage = "SUCCESS";
                }
                else
                {
                    licences.IsSuccessful = false;
                    licences.ErrorMessage = "NO LICENCE FOUND";
                }
            }
            catch (Exception ex)
            {
                licences.IsSuccessful = false;
                licences.ErrorMessage = ex.Message;
            }
            return licences;
        }
    }
}
