using SquatFinder.Core.Models;

namespace SquatFinder.Core.Http
{
	public interface ITwisterHttpClient
	{
		DnsTwisterResponseWrapper GetFuzzyDomains(string domainName);
	}
}