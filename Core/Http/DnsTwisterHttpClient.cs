using RestSharp;
using SquatFinder.Web.Core.Models;

namespace SquatFinder.Web.Core.Http
{
	public class DnsTwisterHttpClient : ITwisterHttpClient
	{
		private const string BASE_URL = "http://dnstwister.report/api/fuzz/";

		public DnsTwisterResponseWrapper GetFuzzyDomains(string domainName)
		{
			var url = BASE_URL + domainName;
			var client = new RestClient(url);
			var request = new RestRequest(Method.GET);

			var response = client.Execute<DnsTwisterResponseWrapper>(request);

			return response.Data;
		}
	}
}