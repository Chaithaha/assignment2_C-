using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PepperController : ControllerBase
    {
        // Dictionary for storing pepper Scoville units
        private static readonly Dictionary<string, int> PepperScovilleUnits = new()
        {
            { "Poblano", 1500 },
            { "Mirasol", 6000 },
            { "Serrano", 15500 },
            { "Cayenne", 40000 },
            { "Thai", 75000 },
            { "Habanero", 125000 }
        };

        /// <summary>
        /// This method calculates the total spiciness (SHU) of a list of chili peppers.
        /// It receives a comma-separated string of pepper names and returns the sum of their Scoville units.
        /// </summary>
        /// <param name="ChiliPeppersIngredients">
        /// A comma-separated string containing the names of the chili peppers (e.g., "Poblano, Serrano, Habanero").
        /// </param>
        /// <returns>
        /// Returns the total spice level as an integer. The spice level is the sum of the Scoville units of each pepper in the input list.
        /// </returns>
        /// <example>
        /// Example input:
        /// "Poblano, Habanero, Thai, Poblano"
        /// 
        /// Example output:
        /// 118000
        /// </example>
        [HttpGet("ChiliPeppers")]
        public IActionResult CalculateChiliPeppersSpiceLevel(string ChiliPeppersIngredients)
        {
            string[] peppersList = ChiliPeppersIngredients.Split(',');

            int totalSpiceLevel = 0;

            foreach (var pepper in peppersList)
            {
                totalSpiceLevel += PepperScovilleUnits.GetValueOrDefault(pepper.Trim(), 0);
            }

            return Ok(totalSpiceLevel);
        }
    }
}
