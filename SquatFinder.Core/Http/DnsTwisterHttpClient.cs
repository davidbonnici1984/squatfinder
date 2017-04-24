using RestSharp;
using SquatFinder.Core.Models;

namespace SquatFinder.Core.Http
{
	public class DnsTwisterHttpClient : ITwisterHttpClient
	{
		private const string BASE_URL = "http://dnstwister.report/api/fuzz/";

		public FuzzyResponseWrapper GetFuzzyDomains(string domainName)
		{
			var url = BASE_URL + domainName;
			var client = new RestClient(url);
			var request = new RestRequest(Method.GET);

			var response = client.Execute<FuzzyResponseWrapper>(request);

			return response.Data;
		}
	}
}