namespace PS5AvailabilityNotifier;

internal class PlaystationAvailabilityService
{
    public static IStore? CheckStores(LatestAvailability src)
    {
        var properties = typeof(LatestAvailability).GetProperties();

        foreach (var property in properties)
        {
            if (property.PropertyType.GetInterfaces().Contains(typeof(IStore)))
            {
                var storeObject = src.GetType().GetProperty(property.Name).GetValue(src, null);

                if (storeObject != null)
                {
                    var store = CheckStoreAvailability((IStore)storeObject);

                    if (store != null)
                    {
                        return store;
                    }
                }
            }
        }

        return null;
    }

    public static IStore? CheckStoreAvailability(IStore store)
    {
        if (store.digital || store.disc)
        {
            return store;
        }

        return null;
    }
}
