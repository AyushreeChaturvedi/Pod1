using AuditChecklistModule.Model;
using AuditChecklistModule.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AuditChecklistModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditChecklistController : ControllerBase
    {
        private readonly IChecklistProvider checklistProviderobj;
        readonly log4net.ILog _log4net;

        public AuditChecklistController(IChecklistProvider _checklistProviderobj)
        {
            checklistProviderobj = _checklistProviderobj;
            _log4net = log4net.LogManager.GetLogger(typeof(AuditChecklistController));
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AuditCheckListQuestions([FromQuery] string auditType)
        {


            _log4net.Info("AuditChecklistController Http GET request called" + nameof(AuditChecklistController));
            if (string.IsNullOrEmpty(auditType))
                return BadRequest("No Input");
            if ((auditType != "Internal") && (auditType != "SOX"))
                return Ok("Wrong Input");

            try
            {
                List<Questions> list = checklistProviderobj.QuestionsProvider(auditType);
                return Ok(list);
            }
            catch (Exception e)
            {
                _log4net.Error("Exception " + e.Message + nameof(AuditChecklistController));
                return StatusCode(500);
            }
        }
    }
}
