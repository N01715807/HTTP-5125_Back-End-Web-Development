using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1_lipengcheng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q7Controller : ControllerBase
    {
        /// <summary>
        /// Returns a string representation of the current date (formatted yyyy-MM-dd), adjusted by {days}
        /// </summary>
        /// <param name="days">The number of days to adjust. Can be positive or negative. </param>
        /// <returns>"yyyy-MM-dd."</returns>
        /// <example>
        /// (if called on January 1, 2000)
        /// GET: /api/q7/timemachine?days=1
        /// Returns: "2000-01-02"
        /// </example>
        /// <example>
        /// (if called on January 1, 2000)
        /// GET: /api/q7/timemachine?days=-1
        /// Returns: "1999-12-31"
        /// </example>
        [HttpGet (template: "/api/q7/timemachine")]
        public string TimeMachine([FromQuery] int days) 
        
       {
            DateTime today = DateTime.Today;
            DateTime final = today.AddDays(days);
            return final.ToString("yyyy-MM-dd");
        }
            
    }
}
