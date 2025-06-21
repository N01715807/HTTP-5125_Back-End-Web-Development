using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CccApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        /// <summary>
        /// Calculate the total spiciness of the input pepper list（SHU）。
        /// </summary>
        /// <param name="Ingredients">
        /// Poblano,Cayenne,Thai,Poblano
        /// </param>
        /// <returns>
        /// The integer sum of all peppers' spiciness (SHU)
        /// </returns>
        /// <example>
        /// GET /api/J2/secondQuestion?Ingredients=Poblano,Cayenne,Thai,Poblano  → 118000
        /// GET /api/J2/secondQuestion?Ingredients=Habanero,Habanero,Habanero,Habanero,Habanero  → 625000
        /// GET /api/J2/secondQuestion?Ingredients=Poblano,Mirasol,Serrano,Cayenne,Thai,Habanero,Serrano → 278500
        /// </example>
        [HttpGet(template: "api/j2/secondQuestion")]
        public int secondQuestion (string Ingredients)
        {
            if(string.IsNullOrWhiteSpace(Ingredients))
                return 0;

            int total = 0;
            foreach (var Chili in Ingredients.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                if (Chili.Equals("Poblano", StringComparison.OrdinalIgnoreCase))
                    total += 1500;
                else if (Chili.Equals("Mirasol", StringComparison.OrdinalIgnoreCase))
                    total += 6000;
                else if (Chili.Equals("Serrano", StringComparison.OrdinalIgnoreCase))
                    total += 15500;
                else if (Chili.Equals("Cayenne", StringComparison.OrdinalIgnoreCase))
                    total += 40000;
                else if (Chili.Equals("Thai", StringComparison.OrdinalIgnoreCase))
                    total += 75000;
                else if (Chili.Equals("Habanero", StringComparison.OrdinalIgnoreCase))
                    total += 125000;
            }
            return total;
        }
    }
}
