using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1_lipengcheng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q6Controller : ControllerBase
    {
        ///<summary>
        ///Returns the area of a regular hexagon with side length double {S} using the formula. 3×32×𝑆2You may assume {S}>0.
        /// </summary>
        /// <param name="side">regular hexagon with side length double {S} using the formula. 3×32×𝑆2You may assume {S}>0.</param>
        /// <returns>the hexagon. </returns>
        /// <example>
        /// GET: /api/q6/hexagon?side=1
        /// Returns: 2.598076211353316
        /// </example>
        /// <example>
        /// GET: /api/q6/hexagon?side=1.5
        /// Returns: 5.845671475544961
        /// </example>
        /// <example>
        /// GET: /api/q6/hexagon?side=20
        /// Returns: 1039.2304845413264
        /// </example>
        [HttpPost (template:"/api/q6/hexagon")]
        public double HexagonArea([FromQuery] double side)
        {
            double area = (3 * Math.Sqrt(3) / 2) * Math.Pow(side, 2);
            return area;
        }
    }
}
