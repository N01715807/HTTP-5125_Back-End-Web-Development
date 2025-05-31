using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1_lipengcheng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q4Controller : ControllerBase
    {
        ///<summary>
        ///Returns the start of a knock knock joke
        /// </summary>
        /// <returns>who is there</returns>
        /// <example>
        /// POST /api/q4/knockknock
        /// REQUEST HEADERS: (NONE)
        /// REQUEST BODY: (NONE)
        /// Return:"Who’s there?"
        /// </example>
        [HttpPost(template: "/api/q4/knockknock")]
        public string knockknock()
        {
            return "Who's there?";
        }
    }
}
