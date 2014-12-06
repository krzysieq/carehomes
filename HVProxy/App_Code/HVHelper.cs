using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Health;
using Microsoft.Health.Web;
using Microsoft.Health.PatientConnect;
using Microsoft.Health.Web.Authentication;


/// <summary>
/// HVHelper contains methods used to communicate with HealthVault
/// </summary>
public static class HVHelper
{
    public static string ApplicationId
    {
        get
        {
            if (System.Configuration.ConfigurationManager.AppSettings["ApplicationId"] != null)
                return System.Configuration.ConfigurationManager.AppSettings["ApplicationId"].ToString();

            return "";
        }
    }

    /// <summary>
    /// Creates Offline Web Application Connection
    /// </summary>
    /// <param name="applicationId">Application Id used for creating the offline connection</param>
    /// <param name="personId">Person Id who granted permission to perform operation</param>
    /// <returns>Returns authentication connection</returns>
    public static OfflineWebApplicationConnection CreateConnection(Guid applicationId,
                                                                   Guid personId)
    {
        OfflineWebApplicationConnection offlineConn = new OfflineWebApplicationConnection(applicationId,
            WebApplicationConfiguration.HealthServiceUrl, personId);
        offlineConn.Authenticate();
        return offlineConn;
    }

    /// <summary>
    /// Create Offline Web Application Connection
    /// </summary>
    /// <param name="applicationId">Application ID used for creating the offline connection</param>
    /// <returns>reference to OfflineWebApplicationConnection </returns>
    public static OfflineWebApplicationConnection CreateConnection(Guid applicationId)
    {
        OfflineWebApplicationConnection offlineConn = new OfflineWebApplicationConnection(applicationId,
            WebApplicationConfiguration.HealthServiceUrl, Guid.Empty);
        offlineConn.Authenticate();
        return offlineConn;
    }

    /// <summary>
    /// Create a participant code. A participant can authorize this application by entering this code 
    /// on HealthVault and answering the security question
    /// </summary>
    /// <param name="friendlyName">Participant's Name</param>
    /// <param name="securityQuestion">Security question</param>
    /// <param name="securityAnswer">Security Answer</param>
    /// <param name="applicationPatientId">Application Specific ID for Participant</param>
    /// <returns>Returns 20 digit identity code</returns>
    public static string CreateParticipantIdentityCode(string friendlyName,
                                string securityQuestion,
                                string securityAnswer,
                                string applicationPatientId)
    {
        Guid applicationId = new Guid(ApplicationId);
        OfflineWebApplicationConnection offlineConnection = CreateConnection(applicationId);
        string identityCode = string.Empty;
        identityCode = PatientConnection.Create(offlineConnection, friendlyName, securityQuestion, securityAnswer, null, applicationPatientId);
        return identityCode;
    }

    /// <summary>
    /// Get all the application authorizatons that happend in last n days as specified by the pastDays parameter.
    /// pastDays is set to 0, this function gets ALL the validatations that has happend to date.
    /// </summary>
    /// <param name="pastDays">Specify the last number of days since when the validations needs to be fetched. Specify 0 to fetch all validations</param>
    /// <returns></returns>
    public static Collection<ValidatedPatientConnection> GetValidatedConnectionsInPastDays(int pastDays)
    {
        Guid appId = new Guid(ApplicationId);
        OfflineWebApplicationConnection offlineConnection = CreateConnection(appId);


        if (pastDays > 0)
        {
            DateTime dtSince = DateTime.Now.AddDays(-1 * pastDays);
            return PatientConnection.GetValidatedConnections(offlineConnection, dtSince);
        }

        return PatientConnection.GetValidatedConnections(offlineConnection);
    }

}