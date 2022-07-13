using AuditBenchmarkModule.Models;
using System.Collections.Generic;

namespace AuditBenchmarkModule.Providers
{
    public interface IBenchmarkProvider
    {
        public List<AuditBenchmark> GetBenchmark();
    }

}
