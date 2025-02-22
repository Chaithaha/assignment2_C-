using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HEHE : Controller
    {
        /// <summary>
        /// Determines the highest bid from a given list of bids.
        /// </summary>
        /// <param name="N">The number of bids to process. If omitted, all bids will be considered.</param>
        /// <param name="bids">An array of bid objects containing a person's name and the bid amount.</param>
        /// <returns>
        /// Returns the name of the highest bidder.
        /// </returns>
        /// <example>
        /// Example request:
        /// POST /api/HEHE/SilentAuction?N=3
        /// Body:
        /// [
        ///   { "Name": "Jackson", "Bid": 300 },
        ///   { "Name": "Vivek", "Bid": 500 },
        ///   { "Name": "Jacky", "Bid": 450 }
        /// ]
        /// Response:
        /// "Suzanne"
        /// </example>

        [HttpPost("[action]")]  // Uses "SilentAuction" as the route
        public IActionResult SilentAuction(int? N, [FromBody] BidClass[] bids)
        {
            // Ensure bids list is not null or empty
            if (bids == null || bids.Length == 0)
            {
                return BadRequest("Error: No bids provided.");
            }

            // Determine how many bids to process (use all if N is not specified)
            int totalBids = bids.Length;
            int bidsToProcess = N.HasValue ? Math.Min(N.Value, totalBids) : totalBids;

            string winnerName = "";
            int highestBid = 0;

            for (int i = 0; i < bidsToProcess; i++)
            {
                // Update winner if current bid is the highest
                if (bids[i].Bid > highestBid)
                {
                    highestBid = bids[i].Bid;
                    winnerName = bids[i].Name;
                }
            }

            return Ok(winnerName);
        }
    }

    /// <summary>
    /// Represents a bid in the silent auction.
    /// </summary>
    public class BidClass
    {
        public required string Name { get; set; }  // Name of the bidder
        public int Bid { get; set; }  // Bid amount
    }
}
