using System.Net.Http;
using System.Threading.Tasks;

namespace BookStore.App.Infrastructure
{
	class HttpService
	{
		public async Task<string> Get(string url)
		{
			using (var client = new HttpClient())
			{
				var response = await client.GetAsync(url);
				return await response.Content.ReadAsStringAsync();
			}
		}
	}
}
