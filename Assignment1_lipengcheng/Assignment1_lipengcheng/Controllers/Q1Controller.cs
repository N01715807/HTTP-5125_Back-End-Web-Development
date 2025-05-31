using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1_lipengcheng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q1Controller : ControllerBase
    {
        /// <summary>
        /// Returns a welcome message
        /// </summary>
        /// <return> string="Welcome to 5125!"
        /// </return>
        /// <example>
        /// GET /api/q1/welcome
        /// Return: Welcome to 5125!
        /// </example>
        [HttpGet(template: "Welcome")]
        public string Welcome()
        {
            return "Welcome to 5125!";
        }
    }
}
