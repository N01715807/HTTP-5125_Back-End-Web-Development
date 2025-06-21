using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CccApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J32020Controller : ControllerBase
    {
        [HttpGet("Art")]
        public string[] Art([FromQuery] string points)
        {
            var arr = points.Split(';', StringSplitOptions.RemoveEmptyEntries);
            int minX = 101, maxX = -1, minY = 101, maxY = -1;

            foreach (var p in arr)
            {
                var xy = p.Split(',');
                int x = int.Parse(xy[0]);
                int y = int.Parse(xy[1]);
                minX = Math.Min(minX, x);
                maxX = Math.Max(maxX, x);
                minY = Math.Min(minY, y);
                maxY = Math.Max(maxY, y);
            }
            string bottomLeft = $"{minX - 1},{minY - 1}";
            string topRight = $"{maxX + 1},{maxY + 1}";
            return new[] { bottomLeft, topRight };
        }
    }
}
