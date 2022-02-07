using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingProblems.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CodingControllerBase : ControllerBase
    {

        //private readonly ILogger<CodingBaseController> _logger;

        //public CodingBaseController(ILogger<CodingBaseController> logger)
        //{
        //    _logger = logger;
        //}

    }
}
