<Query Kind="Statements">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

using var handler = new HttpClientHandler(){
	MaxConnectionsPerServer = 4
};
using var client = new HttpClient(handler);

var tasks = 
	Enumerable.Range(0, 12)
		.Select(_ => client.GetStringAsync("http://localhost:5065/users/random"))
		.ToList();
	
await Task.WhenAll(tasks);	
	
