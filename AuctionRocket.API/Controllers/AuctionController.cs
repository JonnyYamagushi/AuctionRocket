using AuctionRocket.API.DataAcess;
using AuctionRocket.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AuctionRocket.API.Controllers;

public class AuctionController : AuctionRocketBaseController
{
    [HttpGet("GetCurrentAuction")]
    [ProducesResponseType(typeof(List<Auction>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction()
    {
        var result = new AuctionsDataAcess().GetActiveAuctions().Result;

        if (result.Any() == false)
        {
            return NoContent();
        }

        return Ok(result);
    }
}
