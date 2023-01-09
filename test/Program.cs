

var url = $"https://api.binance.com/api/v3/ticker/price?symbol=ETHTRY";
var client = new HttpClient();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri(url),
    Headers =
    {
      { "Accept", "application/json" },
    //  { "Authorization", $"Bearer {token}" }
    },
};
    using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    Console.WriteLine(body);
}
