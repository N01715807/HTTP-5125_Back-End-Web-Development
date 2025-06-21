using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CccApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _2020J3Controller : ControllerBase
    {
        /// <summary>
        /// Calculate whether Barley is happy based on the number of small/medium/large snacks.
        /// </summary>
        /// <param name="S">Number of small snacks (0‒9)</param>
        /// <param name="M">Number of medium snacks (0‒9)</param>
        /// <param name="L">Number of large snacks (0‒9)</param>
        /// <returns>"happy" or "sad"</returns>
        [HttpGet("thirdQuestion")]
        public string thirdQuestion(int S, int M, int L)
        {
            int score = 1 * S + 2 * M + 3 * L;

            if (score >= 10)
                return "happy";
            else
                return "sad";
        }
    }
}
