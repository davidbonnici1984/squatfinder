using DnsTwisterMonitor.Core.Models;
using RestSharp;

namespace DnsTwisterMonitor.Core.Http
{
    public class TwisterHttpClient
    {
        private const string BaseUrl = "http://dnstwister.report/api/fuzz/";

        public TwisterResponseWrapper GetFuzzyDomains(string domainName)
        {
            var url = BaseUrl + domainName;
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            var response = client.Execute<TwisterResponseWrapper>(request);

            return response.Data;
        }
    }
}