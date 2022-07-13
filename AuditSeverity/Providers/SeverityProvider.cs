using AuditSeverityModule.Models;
using AuditSeverityModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityModule.Providers
{
    public class SeverityProvider : ISeverityProvider
    {
        ISeverityRepo obj;
        public SeverityProvider(ISeverityRepo _obj)
        {
            obj = _obj;
        }
        //Severity obj = new Severity();

        public AuditResponse SeverityResponse(AuditRequest Req)
        {
            if (Req == null)
                return null;
            try
            {
                var ls = obj.Response();
                if (ls == null)
                {
                    return null;
                }
                int count = 0, acceptableNo = 0;

                if (Req.Question1 == false)
                    count++;
                if (Req.Question2 == false)
                    count++;
                if (Req.Question3 == false)
                    count++;
                if (Req.Question4 == false)
                    count++;
                if (Req.Question5 == false)
                    count++;

                if (Req.Type == ls[0].AuditType)
                    acceptableNo = ls[0].BenchmarkNoAnswers;
                else if (Req.Type == ls[1].AuditType)
                    acceptableNo = ls[1].BenchmarkNoAnswers;
                else
                    return null;

                Random r = new Random();

                AuditResponse res = new AuditResponse();

                if (Req.Type == "Internal" && count <= acceptableNo)
                {
                    res.AuditId = r.Next();
                    res.ProjectExexutionStatus = "GREEN";
                    res.RemedialActionDuration = "No Action Needed";
                }
                else if (Req.Type == "Internal" && count > acceptableNo)
                {
                    res.AuditId = r.Next();
                    res.ProjectExexutionStatus = "RED";
                    res.RemedialActionDuration = "Action to be taken in 2 weeks";
                }
                else if (Req.Type == "SOX" && count <= acceptableNo)
                {
                    res.AuditId = r.Next();
                    res.ProjectExexutionStatus = "GREEN";
                    res.RemedialActionDuration = "No Action Needed";
                }
                else if (Req.Type == "SOX" && count > acceptableNo)
                {
                    res.AuditId = r.Next();
                    res.ProjectExexutionStatus = "RED";
                    res.RemedialActionDuration = "Action to be taken in 2 weeks";
                }


                return res;
            }
            catch(Exception)
            {
                return null;
            }
                  
        }
    }
}
