using DnsTwisterMonitor.Core.Models;

namespace DnsTwisterMonitor.Core.Http
{
	public interface ITwisterHttpClient
	{
		FuzzyResponseWrapper GetFuzzyDomains(string domainName);
	}
}