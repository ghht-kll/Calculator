var httpClient = new HttpClient();
var baseUrl = "https://localhost:7015";

await GetResult(httpClient, $"{baseUrl}/Add/5/3");
await GetResult(httpClient, $"{baseUrl}/Subtract/5/3");
await GetResult(httpClient, $"{baseUrl}/Multiply/5/3");
await GetResult(httpClient, $"{baseUrl}/Divide/5/2");
await GetResult(httpClient, $"{baseUrl}/Divide/5/0");

Console.ReadLine();

async Task GetResult(HttpClient httpClient, string url)
{
    try
    {
        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{url}: {result}");
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"Error {url}: {ex.Message}");
    }
}