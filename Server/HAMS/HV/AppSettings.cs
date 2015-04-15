using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HAMS.HV
{
    public static class AppSettings
    {
        public static Guid ApplicationId() { return (new Guid("48807f84-5c7f-4c29-ad45-ffeaf4e13058")); }

        public static string PlatformUrl() { return ("https://platform.healthvault-ppe.com/platform/"); }
    }
}