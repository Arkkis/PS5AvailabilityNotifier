namespace PS5AvailabilityNotifier;

public class PlaystationApiDto
{
    public LatestAvailability latestAvailability { get; set; }
    public Pastsale[] pastSales { get; set; }
}

public class LatestAvailability
{
    public Power power { get; set; }
    public Gigantti gigantti { get; set; }
    public Verkkokauppa verkkokauppa { get; set; }
    public Telia telia { get; set; }
    public Prisma prisma { get; set; }
    public Dna dna { get; set; }
    public Elisa elisa { get; set; }
}

public class Power : IStore
{
    public string storeId { get; set; }
    public bool disc { get; set; }
    public bool digital { get; set; }
    public string discUrl { get; set; }
    public string digitalUrl { get; set; }
    public DateTime updatedTimestamp { get; set; }
    public bool discAvailableBatchStart { get; set; }
    public bool digitalAvailableBatchStart { get; set; }
    public DateTime discLastAvailable { get; set; }
    public DateTime digitalLastAvailable { get; set; }
    public DateTime discPreviouslyAvailable { get; set; }
    public DateTime digitalPreviouslyAvailable { get; set; }
}

public class Gigantti : IStore
{
    public string storeId { get; set; }
    public bool disc { get; set; }
    public bool digital { get; set; }
    public string discUrl { get; set; }
    public string digitalUrl { get; set; }
    public DateTime updatedTimestamp { get; set; }
    public bool discAvailableBatchStart { get; set; }
    public bool digitalAvailableBatchStart { get; set; }
    public DateTime discLastAvailable { get; set; }
    public DateTime discPreviouslyAvailable { get; set; }
    public DateTime digitalLastAvailable { get; set; }
    public DateTime digitalPreviouslyAvailable { get; set; }
}

public class Verkkokauppa : IStore
{
    public string discUrl { get; set; }
    public string digitalUrl { get; set; }
    public string storeId { get; set; }
    public bool disc { get; set; }
    public bool discAvailableBatchStart { get; set; }
    public bool digital { get; set; }
    public bool digitalAvailableBatchStart { get; set; }
    public DateTime updatedTimestamp { get; set; }
    public DateTime discLastAvailable { get; set; }
    public DateTime discPreviouslyAvailable { get; set; }
    public DateTime digitalLastAvailable { get; set; }
    public DateTime digitalPreviouslyAvailable { get; set; }
}

public class Telia : IStore
{
    public string discUrl { get; set; }
    public string digitalUrl { get; set; }
    public string storeId { get; set; }
    public bool disc { get; set; }
    public bool discAvailableBatchStart { get; set; }
    public bool digital { get; set; }
    public bool digitalAvailableBatchStart { get; set; }
    public DateTime updatedTimestamp { get; set; }
}

public class Prisma : IStore
{
    public string discUrl { get; set; }
    public string digitalUrl { get; set; }
    public string storeId { get; set; }
    public bool disc { get; set; }
    public bool discAvailableBatchStart { get; set; }
    public bool digital { get; set; }
    public bool digitalAvailableBatchStart { get; set; }
    public DateTime updatedTimestamp { get; set; }
    public DateTime discLastAvailable { get; set; }
    public DateTime discPreviouslyAvailable { get; set; }
    public DateTime digitalLastAvailable { get; set; }
    public DateTime digitalPreviouslyAvailable { get; set; }
}

public class Dna : IStore
{
    public string discUrl { get; set; }
    public string digitalUrl { get; set; }
    public string storeId { get; set; }
    public bool disc { get; set; }
    public bool discAvailableBatchStart { get; set; }
    public bool digital { get; set; }
    public bool digitalAvailableBatchStart { get; set; }
    public DateTime updatedTimestamp { get; set; }
    public DateTime discLastAvailable { get; set; }
    public DateTime discPreviouslyAvailable { get; set; }
    public DateTime digitalLastAvailable { get; set; }
    public DateTime digitalPreviouslyAvailable { get; set; }
}

public class Elisa : IStore
{
    public string discUrl { get; set; }
    public string digitalUrl { get; set; }
    public string storeId { get; set; }
    public bool disc { get; set; }
    public bool discAvailableBatchStart { get; set; }
    public bool digital { get; set; }
    public bool digitalAvailableBatchStart { get; set; }
    public DateTime updatedTimestamp { get; set; }
    public DateTime discLastAvailable { get; set; }
    public DateTime discPreviouslyAvailable { get; set; }
    public DateTime digitalLastAvailable { get; set; }
    public DateTime digitalPreviouslyAvailable { get; set; }
    public string maxStockStatus { get; set; }
}

public class Pastsale
{
    public string store { get; set; }
    public DateTime notificationSentTimestamp { get; set; }
    public int emailCount { get; set; }
}

public interface IStore
{
    public bool disc { get; set; }
    public bool digital { get; set; }
    public string discUrl { get; set; }
    public string digitalUrl { get; set; }
}