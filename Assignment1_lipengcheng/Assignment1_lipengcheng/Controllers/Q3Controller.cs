using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1_lipengcheng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q3Controller : ControllerBase
    {
        /// <summary>
        /// Returns the cube of the integer {base}
        /// </summary>
        /// <param name="baseNumber">The integer to be cubed.</param>
        /// <returns>integer number</returns>
        /// <example>
        /// GET: /api/q3/cube/4
        /// Returns: 64
        /// </example>
        /// <example>
        /// GET: /api/q3/cube/-4
        /// Returns: -64
        /// </example>
        /// <example>
        /// GET: /api/q3/cube/10
        /// Returns: 1000
        /// </example>
        [HttpGet("/api/q3/cube/{baseNumber}")]
        public int Cube(int baseNumber)
        {
            return baseNumber * baseNumber * baseNumber;
        }
    }
}
