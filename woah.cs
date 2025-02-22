using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretInstructionsController : ControllerBase
    {
        /// <summary>
        /// Decodes a list of secret instructions into directional steps.
        /// The direction is determined based on the sum of the first two digits in each instruction.
        /// </summary>
        /// <param name="instructionsList">A list of 5-digit numeric strings representing instructions.</param>
        /// <returns>
        /// A list of decoded instructions with direction and step count.
        /// </returns>
        /// <example>
        /// **Example usage:**  
        /// **POST** /api/SecretInstructions  
        /// **Body:**
        /// [
        ///   "57234",
        ///   "00907",
        ///   "34100",
        ///   "99999"
        /// ]
        /// **Response:**
        /// [
        ///   "right 234",
        ///   "right 907",
        ///   "left 100"
        /// ]
        /// </example>
        [HttpPost]
        public IActionResult DecodeInstructions([FromBody] List<string> instructionsList)
        {
            if (instructionsList == null || instructionsList.Count == 0)
                return BadRequest("Instruction list cannot be empty.");

            List<string> decodedInstructions = new List<string>();
            string previousDirection = "";

            foreach (string instruction in instructionsList)
            {
                // If instruction is "99999", stop processing
                if (instruction == "99999")
                    break;

                // Validate that the instruction is exactly 5 digits
                if (!int.TryParse(instruction, out _) || instruction.Length != 5)
                    return BadRequest($"Invalid instruction format: {instruction}");

                // Extract first two digits and sum them to determine direction
                int directionSum = int.Parse(instruction[0].ToString()) + int.Parse(instruction[1].ToString());
                string direction;

                if (directionSum == 0)
                {
                    direction = previousDirection; // Keep the previous direction
                }
                else if (directionSum % 2 == 0)
                {
                    direction = "right";
                }
                else
                {
                    direction = "left";
                }

                // Extract the last three digits as the step count
                int steps = int.Parse(instruction.Substring(2, 3));

                // Only update previousDirection if directionSum is not zero
                if (directionSum != 0)
                {
                    previousDirection = direction;
                }

                // Add the formatted instruction to the output list
                decodedInstructions.Add($"{direction} {steps}");
            }

            return Ok(decodedInstructions);
        }
    }
}
