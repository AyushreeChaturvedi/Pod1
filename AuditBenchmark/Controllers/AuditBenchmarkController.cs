using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AuditBenchmarkModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AuditBenchmarkController : ControllerBase   //Port 44386
    {
        private readonly log4net.ILog _log4net;
        private readonly BenchmarkProvider obj;
        public AuditBenchmarkController(BenchmarkProvider _obj)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuditBenchmarkController));
            obj = _obj;
        }

        // GET: api/AuditBenchmark
        [HttpGet]
        public IActionResult AuditBenchmark()
        {
            List<AuditBenchmark> ls = new List<AuditBenchmark>();
            _log4net.Info(" Http GET request hoi");
            try
            {
                ls = obj.GetBenchmark();
                if (ls == null)
                    return BadRequest();
                return Ok(ls);
            }
            catch (Exception e)
            {
                _log4net.Error(" Exception here" + e.Message);
                return StatusCode(500);
            }
        }
    }
}


