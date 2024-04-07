<Query Kind="Statements">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

using var handler = new HttpClientHandler() { MaxConnectionsPerServer = 20 };
using var client = new HttpClient(handler);


var tasks =
	Enumerable.Range(0, 1000)
		.Select(_ => client.GetAsync("http://localhost:5001/users/random"))
		.ToList();

var results = await Task.WhenAll(tasks);

foreach (var res in results)
	res.EnsureSuccessStatusCode();
