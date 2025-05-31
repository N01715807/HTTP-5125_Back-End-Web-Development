using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1_lipengcheng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q2Controller : ControllerBase
    {
        ///<summary>
        ///Returns a greeting to {name}
        ///</summary>
        ///<param name="name">Greeting someone by name</param>
        ///<returns>hi+"give name"</returns>
        ///<example>
        ///GET: /api/q2/greeting?name=Gary
        ///return: Hi Gary!
        /// </example>
        /// ///<example>
        ///GET: /api/q2/greeting?name=Ren%C3%A9e
        ///return: Hi Renée!
        /// </example>
        [HttpGet(template: "/api/q2/greeting")]
        public string Greeting([FromQuery] string name)
        {
            return $"Hi {name}!";
                }
    }
}
