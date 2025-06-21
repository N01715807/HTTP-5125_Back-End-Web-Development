using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CccApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _2020J2Controller : ControllerBase
    {/// <summary>
     /// Calculate the number of days when the cumulative number of infections exceeds P for the first time.
     /// </summary>
     /// <param name="P">INT P</param>
     /// <param name="N">INT N</param>
     /// <param name="R">INT R</param>
     /// <returns>The first “day number” when the cumulative number of infections exceeds P</returns>
        [HttpGet("FourthQuestion")]
        public int FourthQuestion(int P, int N, int R) 
        {
            int total = N;
            int today = N;
            int day = 0;

            while (total <= P)
            {
                day=day+1;
                today = today * R;
                total = total + today;
            }

            return day;

        }
        
        }
}
