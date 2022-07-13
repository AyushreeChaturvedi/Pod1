using AuditChecklistModule.Model;
using AuditChecklistModule.Repository;
using System.Collections.Generic;

namespace AuditChecklistModule.Providers
{
    public class ChecklistProvider : IChecklistProvider
    {
        private readonly IChecklistRepo checklistRepoObj;
        readonly log4net.ILog _log4net;
        public ChecklistProvider(IChecklistRepo _checklistRepoObj)
        {
            checklistRepoObj = _checklistRepoObj;
            _log4net = log4net.LogManager.GetLogger(typeof(ChecklistProvider));
        }
        List<Questions> listOfQuestions = new List<Questions>();

        public List<Questions> QuestionsProvider(string auditType)
        {

            _log4net.Info(" Http GET request called" + nameof(ChecklistProvider));
            listOfQuestions = checklistRepoObj.GetQuestions(auditType);
            return listOfQuestions;



        }
    }
}
