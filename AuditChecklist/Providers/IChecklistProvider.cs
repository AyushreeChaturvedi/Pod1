using AuditChecklistModule.Model;
using System.Collections.Generic;

namespace AuditChecklistModule.Providers
{
    public interface IChecklistProvider
    {
        public List<Questions> QuestionsProvider(string auditType);
    }
}
