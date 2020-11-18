using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using multi_tenant_webapp.Abstractions;
using MultiTenant.Extensions;
using MultiTenant.Models;

namespace multi_tenant_webapp.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IService _service;

        public ValuesController(IService service)
        {
            _service = service;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetValue()
        {
            return Ok(await Task.FromResult(HttpContext.GeTenantContext<Tenant>().Tenant));
        }

        [HttpGet("calculate")]
        public async Task<IActionResult> Calculate(int a, int b)
        {
            return Ok(await _service.CalculateAsync(a, b));
        }
    }
}
