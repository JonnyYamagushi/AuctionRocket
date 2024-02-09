namespace AuctionRocket.API.Domain.Entities;

public class Offer
{
    public int Id { get; set; }
    public int Id_Item { get; set; }
    public int Id_User { get; set; }
    public DateTime CreatedOn { get; set; }
    public decimal Price { get; set; }
}
