using AuctionRocket.API.Communication.Requests;
using AuctionRocket.API.DataAcess;
using AuctionRocket.API.Domain.Entities;
using AuctionRocket.API.Filters;
using AuctionRocket.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuctionRocket.API.Controllers;

public class OfferController : AuctionRocketBaseController
{

    [HttpPost]
    [Route("CreateOffer/{Id_Item}")]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public async Task<IActionResult> CreateOffer([FromRoute]int Id_Item, [FromBody] RequestCreateOffer requestCreateOffer, [FromServices] LoggedUser loggedUser)
    {
        Offer offer = new Offer 
        {
            Id_Item = Id_Item,
            Price = requestCreateOffer.Price,
            CreatedOn = DateTime.Now,
            Id_User = loggedUser.User()!.Id
        };

        await new OffersDataAcess().CreateOffer(offer);
        
        return Created(string.Empty, offer.Id);
    }
}
