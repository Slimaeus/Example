using Example.Consoles.Async;

var quotes = await QuoteGetter.GetRandomQuotes(5).ConfigureAwait(false);

foreach (var quote in quotes)
{
    Console.WriteLine(quote.Content);
}