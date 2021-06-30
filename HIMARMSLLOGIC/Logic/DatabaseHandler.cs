using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMARMSLLOGIC.Logic
{
    public class DatabaseHandler
    {
        DbCommand command;
        Database DbConnection;
        DataTable returntable;
        internal DatabaseHandler()
        {
            try
            {
                DbConnection = DatabaseFactory.CreateDatabase("connectionstring");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void RegisterUser(string fullname,string address, string username,string email,string department,string password) 
        {
            command = DbConnection.GetStoredProcCommand("RegisterUser", fullname, address, username, email, department, password);
            DbConnection.ExecuteNonQuery(command);
        }

        internal DataTable GetSystemUsers()
        {
            command = DbConnection.GetStoredProcCommand("GetSystemUsers");
            returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            return returntable;
        }

        internal DataTable GetUserByUsernameAndPwd(string username, string password)
        {
            command = DbConnection.GetStoredProcCommand("GetUserByUsernameAndPwd", username, password);
            returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            return returntable;
        }

        internal void CreateUserDepartment(string departmentname, string departmenthead)
        {
            command = DbConnection.GetStoredProcCommand("CreateUserDepartment", departmentname, departmenthead);
            DbConnection.ExecuteNonQuery(command);
        }

        internal DataTable GetUserDepartments()
        {
            command = DbConnection.GetStoredProcCommand("GetUserDepartments");
            returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            return returntable;
        }

        internal DataTable GetLicences()
        {
            command = DbConnection.GetStoredProcCommand("GetLicences");
            returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            return returntable;
        }

        internal void CreateLicence(string leasetype, string referencenum, string issuingauthority, string technicalscope, string geographicalscope, string issuedate, string dateofexpiry, string licenceAcquisitionCost, string renewalCost, string otherRelatedCost, string responsibleDepartment, string impactedDepartments, string averagerenewal, string termsAndConditions,string AverageRenewalTime, string remarksAndComments)
        {
            command = DbConnection.GetStoredProcCommand("CreateLicence", 
                leasetype,
                referencenum,
                issuingauthority,
                technicalscope,
                geographicalscope,
                 issuedate,
                 dateofexpiry,
                 licenceAcquisitionCost,
                 renewalCost,
                 otherRelatedCost,
                 responsibleDepartment,
                 impactedDepartments,
                 averagerenewal,
                 termsAndConditions,
                 AverageRenewalTime,
                 remarksAndComments);
            DbConnection.ExecuteNonQuery(command);
        }
    }
}
