using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CccApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        /// <summary>
        /// Calculate the score of the Deliv-e-droid game.
        /// </summary>
        /// <param name="Collisions">The number of times the robot hits an obstacle (non-negative integer) </param>
        /// <param name="Deliveries">The number of packages successfully delivered (non-negative integer) </param>
        /// <returns>final point</returns>
        /// <example>
        /// POST /api/J1/Delivedroid  body: Collisions=2&amp;Deliveries=5  → 730
        /// POST /api/J1/Delivedroid  body: Collisions=10&Deliveries=0  → -100
        /// POST /api/J1/Delivedroid  body:  Collisions=3&Deliveries=2  → 70
        /// </example>

        [HttpPost(template: "api/j1/firstQuestion")]
        public int firstQuestion(
            [FromForm] int Collisions, 
            [FromForm] int Deliveries )
        {
            int score = Deliveries * 50 - Collisions * 10;
            if (Deliveries > Collisions)
            {
                score += 500;
            }
            return score;
        }
            
    }
}
