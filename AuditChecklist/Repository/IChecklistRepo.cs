using AuditChecklistModule.Model;
using System.Collections.Generic;

namespace AuditChecklistModule.Repository
{
    public interface IChecklistRepo
    {
        public List<Questions> GetQuestions(string auditType);
    }
}
