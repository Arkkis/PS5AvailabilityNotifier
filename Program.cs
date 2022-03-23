using PS5AvailabilityNotifier;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

var client = new HttpClient();

await Runner(client);

async Task Runner(HttpClient client)
{
    IStore? lastStore = null;

    while (true)
    {
        var response = await client.GetAsync($"https://ps5suomessa.com/api/GetLatestAndPastStoreAvailability?random={new Random().Next(100000, 999999)}");
        var result = await response.Content.ReadAsStringAsync();

        var json = JsonSerializer.Deserialize<PlaystationApiDto>(result);

        Console.WriteLine(string.Empty);
        var store = PlaystationAvailabilityService.CheckStores(json.latestAvailability);

        if (store is not null)
        {
            if (store.digital)
            {
                if (lastStore != store)
                {
                    Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)} - Digital available at {store.GetType().Name}!");
                    LaunchUrl(store.digitalUrl);
                }

                lastStore = store;
            }

            if (store.disc)
            {
                if (lastStore != store)
                {
                    Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)} - Disc available at {store.GetType().Name}!");
                    LaunchUrl(store.discUrl);
                }

                lastStore = store;
            }
        }
        else
        {
            lastStore = null;
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)} - Nothing available.");
        }

        await Task.Delay(60000);
    }
}

void LaunchUrl(string url)
{
    var startInfo = new ProcessStartInfo
    {
        UseShellExecute = true,
        FileName = url
    };

    Process.Start(startInfo);
}