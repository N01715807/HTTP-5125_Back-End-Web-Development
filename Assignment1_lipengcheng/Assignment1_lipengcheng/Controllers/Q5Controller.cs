using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1_lipengcheng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q5Controller : ControllerBase
    {
        ///<summary>
        ///Returns an acknowledgement of the {secret} integer
        /// </summary>
        /// <param name="secret">the integer secret number </param>
        /// <return>Shh.. the secret is integer number</return>
        /// <example>
        /// POST: /api/q5/secret
        /// Content-Type: application/json
        /// Request Body: 5
        /// Returns: "Shh.. the secret is 5"
        /// </example>
        /// <example>
        /// POST: /api/q5/secret
        /// Content-Type: application/json
        /// Request Body: -200
        /// Returns: "Shh.. the secret is -200"
        /// </example>
        [HttpPost (template: "/api/q5/secret")]
        public string Secret([FromBody] int secret)
        {
            return $"Shh.. the secret is {secret}";
        }
    }
}
