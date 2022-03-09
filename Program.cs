using PS5AvailabilityNotifier;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

var client = new HttpClient();

await Runner(client);

async Task Runner(HttpClient client)
{
    var response = await client.GetAsync($"https://ps5suomessa.com/api/GetLatestAndPastStoreAvailability?random={new Random().Next(100000, 999999)}");
    var result = await response.Content.ReadAsStringAsync();

    var json = JsonSerializer.Deserialize<PlaystationApiDto>(result);

    //var json = new PlaystationApiDto { latestAvailability = new Latestavailability { power = new Power { digital = true, digitalUrl = "http://google.com" } } };

    while (true)
    {
        Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)} - Checking availability");
        var store = PlaystationAvailabilityService.CheckStores(json.latestAvailability);

        if (store is not null)
        {
            if (store.digital)
            {
                Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)} - Digital available!");
                LaunchUrl(store.digitalUrl);
            }

            if (store.disc)
            {
                Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)} - Disc available!");
                LaunchUrl(store.discUrl);
            }
        }
        else
        {
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