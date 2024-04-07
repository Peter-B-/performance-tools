<Query Kind="Statements">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

using var handler = new HttpClientHandler() { MaxConnectionsPerServer = 20 };
using var client = new HttpClient(handler);


var tasks =
	Enumerable.Range(0, 10000)
		.Select(async _ =>
		{
			var resp = await client.GetAsync("http://localhost:5001/Binary/bigEndian/tick");
			resp.EnsureSuccessStatusCode();
			await Task.Delay(1000);
			var str = await resp.Content.ReadAsStringAsync();
			return str;
			})
		.ToList();

var results = await Task.WhenAll(tasks);

