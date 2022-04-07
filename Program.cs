using PS5AvailabilityNotifier;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

var client = new HttpClient();

await Runner(client);

async Task Runner(HttpClient client)
{
    string? lastUrl = null;

    while (true)
    {
        var response = await client.GetAsync($"https://ps5suomessa.com/api/GetLatestAndPastStoreAvailability?random={new Random().Next(100000, 999999)}");
        var result = await response.Content.ReadAsStringAsync();

        PlaystationApiDto json;

        try
        {
            json = JsonSerializer.Deserialize<PlaystationApiDto>(result);
        }
        catch (Exception)
        {
            continue;
        }

        Console.WriteLine(string.Empty);
        var store = PlaystationAvailabilityService.CheckStores(json.latestAvailability);

        if (store is not null)
        {
            if (store.digital)
            {
                if (lastUrl != store.digitalUrl)
                {
                    Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)} - Digital available at {store.GetType().Name}!");
                    LaunchUrl(store.digitalUrl);
                }

                lastUrl = store.digitalUrl;
            }

            if (store.disc)
            {
                if (lastUrl != store.discUrl)
                {
                    Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)} - Disc available at {store.GetType().Name}!");
                    LaunchUrl(store.discUrl);
                }

                lastUrl = store.discUrl;
            }
        }
        else
        {
            lastUrl = null;
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