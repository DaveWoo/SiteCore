﻿using Microsoft.AspNetCore.Mvc;
using WebApiSample.DataAccess.Models;

namespace WebApiSample.Api._21.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class TestController : ControllerBase
    {
        #region snippet_ActionsCausingExceptions
        // Don't do this. All of the following actions result in an exception.
        [HttpPost]
        public IActionResult Action1(Pet pet) => null;
        
        [HttpPost]
        public IActionResult Action3([FromBody] Pet pet) => null;
        #endregion
    }
}