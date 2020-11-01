using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Extensions;
using MultiTenant.Models;

namespace multi_tenant_webapp.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("test")]
        public async Task<IActionResult> GetValue()
        {
            return Ok(await Task.FromResult(HttpContext.GeTenantContext<Tenant>().Tenant));
        }
    }
}
