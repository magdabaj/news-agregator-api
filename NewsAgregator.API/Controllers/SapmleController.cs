using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NewsAgregator.API.Controllers
{
    public class SapmleController: Controller
    {
        [Authorize(JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
