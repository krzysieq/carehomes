using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class2
/// </summary>
public static class AppSettings
{
    public static Guid ApplicationId() { return (new Guid("84556336-bca6-41d0-b65a-ec7c173df523")); }

    public static string PlatformUrl() { return ("https://platform.healthvault-ppe.com/platform/"); }
}