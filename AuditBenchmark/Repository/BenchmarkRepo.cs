using AuditBenchmarkModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Repository
{
    public class BenchmarkRepo : IBenchmarkRepo
    {
        private static List<AuditBenchmark> AuditBenchmarkList = new List<AuditBenchmark>()
        {
            new AuditBenchmark
            {
                AuditType="Internal",
                BenchmarkNoAnswers=3
            },
            new AuditBenchmark
            {
                AuditType="SOX",
                BenchmarkNoAnswers=1
            }

        };
        public List<AuditBenchmark> GetNolist() 
        {
            List<AuditBenchmark> ls = new List<AuditBenchmark>();
            try
            {
                ls= AuditBenchmarkList;
                return ls;
            }
            catch(Exception)
            {
                return null;
            }
            
        }
    }
}
