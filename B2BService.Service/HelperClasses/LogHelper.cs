using B2BService.Repository.LogRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2BService.Service.HelperClasses
{
    public class LogHelper
    {
        LogRepository logengine;
        public LogHelper()
        {
            logengine = new LogRepository();
        }

        public static bool WriteLog(HttpRequest request,Exception ex,string UserId) {
            LogRepository log = new LogRepository();
            log.AddLogEntry(request.Path, request.PhysicalPath, ex.Message, ex.StackTrace, UserId ?? "52407f97-97b7-4dea-a550-8465bf811ec2", request.UserAgent, request.UserHostAddress);
            return true;
        }
    }
}