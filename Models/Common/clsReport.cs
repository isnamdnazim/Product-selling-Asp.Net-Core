using System.Collections.Generic;

namespace TestProject.Models.Common
{
    class clsReport
    {
        public static string strReportPathMain = "";
        public static string strDSNMain = "";
        public static string strQueryMain = "";

        public static List<subReport> rptList = new List<subReport>();
    }

    //Sub Report Class
    public class subReport
    {
        public string strRptPathSub { get; set; } // Sub Report Path name
        public string strRFNSub { get; set; }   // Relational Field Name 
        public string strDSNSub { get; set; }   // DSN Name Sub Report
        public string strQuerySub { get; set; } // Query string Sub Report


        public subReport(string strRptPath, string strRFN, string strDSN, string strQuery)
        {
            strRptPathSub = strRptPath;
            strRFNSub = strRFN;
            strDSNSub = strDSN;
            strQuerySub = strQuery;
        }
    }
}
