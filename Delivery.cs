using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Calculates the performance score for the Delivedroid robot.
        /// </summary>
        /// <param name="collisions">The number of collisions encountered by the robot.</param>
        /// <param name="deliveries">The number of packages successfully delivered.</param>
        /// <returns>
        /// The calculated score based on:
        /// (deliveries * 50) - (collisions * 10) 
        /// If deliveries exceed collisions, an additional 500 points are added.
        /// </returns>
        /// <example>
        /// Example input:
        /// collisions = 2, deliveries = 5
        /// 
        /// Example output:
        /// 730
        /// </example>
        [HttpPost("Delivedroid")]
        public IActionResult DelivedroidPerformance(int collisions, int deliveries)
        {
            // Calculate the base score using deliveries and collisions
            int score = (deliveries * 50) - (collisions * 10);

            // Add a bonus of 500 points if deliveries exceed collisions
            if (deliveries > collisions)
            {
                score += 500;
            }

            // Return the final calculated score as an HTTP 200 OK response
            return Ok(score);
        }
    }
}
