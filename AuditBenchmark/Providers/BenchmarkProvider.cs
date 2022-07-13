using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditBenchmarkModule.Repository;
using AuditBenchmarkModule.Models;

namespace AuditBenchmarkModule.Providers
{
    public class BenchmarkProvider
    {
        private readonly IBenchmarkRepo obj;

        public BenchmarkProvider(IBenchmarkRepo _obj)
        {
            obj = _obj;
        }        

        public List<AuditBenchmark> GetBenchmark()
        {
            List<AuditBenchmark> ls = new List<AuditBenchmark>();
            try
            {
                ls=obj.GetNolist();

                if (ls == null)
                    return null;
                return ls;
            }
            catch(Exception)
            {
                return null;
            }
            
        }
    }
}
