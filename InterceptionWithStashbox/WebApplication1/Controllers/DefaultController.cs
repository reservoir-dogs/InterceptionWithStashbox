using Library;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/default")]
    public class DefaultController : ControllerBase
    {
        private readonly ILevel2Service level2Service;

        public DefaultController(ILevel2Service level2Service)
        {
            this.level2Service = level2Service;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello";
        }
    }
}
