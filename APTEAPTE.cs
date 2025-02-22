using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APTEAPTE : ControllerBase
        {
            /// <summary>
            /// This method calculates the atmospheric pressure at which water boils based on the given boiling point temperature.
            /// It also determines the sea level status based on the pressure value:
            /// - -1 for below sea level
            /// - 0 for at sea level
            /// - 1 for above sea level
            /// </summary>
            /// <param name="B">The boiling point temperature of water in degrees Celsius (B)</param>
            /// <returns>
            /// Returns the calculated atmospheric pressure (P) and the sea level status:
            /// - The atmospheric pressure (P) is calculated by the formula: P = 5 * B - 400
            /// - The sea level status is determined based on the value of P:
            ///   - P > 100: Below sea level
            ///   - P = 100: At sea level
            ///   - P < 100: Above sea level
            /// </returns>
            /// <example>
            /// Example input:
            /// B = 99
            /// 
            /// Example output:
            /// 95
            /// 1
            /// </example>
            [HttpPost("BoilingWater")]
            public IActionResult Index(int B)
            {
                //Atmospheric pressure P = 5 * B - 400 --Commented by Kunal
                int P = 5 * B - 400;

                int seaLevelStatus;

                if (P > 100)
                    seaLevelStatus = -1; // Below sea level
                else if (P == 100)
                    seaLevelStatus = 0;  // At sea level
                else
                    seaLevelStatus = 1;  // Above sea level

                return Ok(P + "\n" + seaLevelStatus);
            }
        }
    }
