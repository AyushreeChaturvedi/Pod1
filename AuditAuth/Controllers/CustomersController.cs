using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuditAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        //[Authorize]
        public IEnumerable<string> Get()
            => new string[] { "Ayushree", "Nikita", "Ruchita" };
    }
}
