using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityModule.Models
{
    public class AuditRequest
    {
        public string ProjectName { get; set; }
        public string ProjectManagerName { get; set; }
        public string ApplicationOwnerName { get; set; }

        public AuditDetail Auditdetails { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        public bool Question1 { get; set; }
        public bool Question2 { get; set; }
        public bool Question3 { get; set; }
        public bool Question4 { get; set; }
        public bool Question5 { get; set; }
    }
}
