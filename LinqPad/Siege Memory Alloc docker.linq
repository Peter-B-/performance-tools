<Query Kind="Statements">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

using var client = new HttpClient() {
	BaseAddress=new Uri("http://localhost:5000")
};

var dcCount = new DumpContainer(0).Dump();
var dc = new DumpContainer().Dump();

var start = DateTime.Now;
var count = 0;

while(DateTime.Now - start < TimeSpan.FromSeconds(45))
{
	var diff = DateTime.Now - start;
	
	var url = diff switch{
		var d when d < TimeSpan.FromSeconds(15) => "/alloc",
		var d when d < TimeSpan.FromSeconds(25) => Random.Shared.NextDouble()<0.5? "/leak":"/alloc",
		_ => "/leak"
	};

	var resp = await client.GetAsync(url);
	resp.EnsureSuccessStatusCode();

	dc.Content = resp.RequestMessage.RequestUri;
	dcCount.Content = ++count;
}

dc.Content ="completed";
