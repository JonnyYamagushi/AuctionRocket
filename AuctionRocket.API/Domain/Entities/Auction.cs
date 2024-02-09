using AuctionRocket.API.Domain.Enums;

namespace AuctionRocket.API.Domain.Entities;

public class Auction
{
    public int Id { get; set; }
    public DateTime Starts { get; set; }
    public DateTime Ends { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<AuctionItem> Items { get; set; } = [];
}

public class AuctionItem
{
    public int Id { get; set; }
    public int Id_Auction { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public Condition Condition { get; set; }
    public decimal BasePrice { get; set; }
}
