using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using ProjectEulerDataContracts;
using ProjectEulerLib;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace ProjectEulerWebAPI.Controllers
{
    [ApiController]
    public class GitHubUserInfoController : ControllerBase
    {
        private readonly ILogger<GitHubUserInfoController> _logger;
        private readonly IConfiguration _configuration;
        public GitHubUserInfoController(ILogger<GitHubUserInfoController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("/GitHubUserInfo/AccessToken")]
        public ActionResult GetAccessToken()
        {

            byte[] data = Convert.FromBase64String(_configuration.GetValue<string>("GitHubToken"));
            string decodedString = Encoding.UTF8.GetString(data);

            return Ok(new {token = decodedString});
        }

    }
}