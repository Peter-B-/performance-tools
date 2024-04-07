<Query Kind="Statements">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

using var handler = new HttpClientHandler() { MaxConnectionsPerServer = 4 };
using var client = new HttpClient(handler);


var tasks =
	Enumerable.Range(0, 1000)
		.Select(_ => client.GetAsync("http://localhost:5001/Binary/bigEndian/tick"))
		.ToList();

var results = await Task.WhenAll(tasks);

foreach (var res in results)
	res.EnsureSuccessStatusCode();
