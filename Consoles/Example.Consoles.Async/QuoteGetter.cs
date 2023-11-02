using System.Text.Json;

namespace Example.Consoles.Async;

public static class QuoteGetter
{
    public static async Task<IEnumerable<Quote>> GetRandomQuotes(int quantity = 1)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var httpClient = new HttpClient
        {
            BaseAddress = new Uri($"https://api.quotable.io/quotes/random?limit={quantity}")
        };

        var result = await httpClient.GetAsync("");
        var content = await result.Content.ReadAsStringAsync();
        var quotes = JsonSerializer.Deserialize<IEnumerable<Quote>>(content, options);

        return quotes ?? Enumerable.Empty<Quote>();
    }
}
