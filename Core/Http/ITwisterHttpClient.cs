using SquatFinder.Web.Core.Models;

namespace SquatFinder.Web.Core.Http
{
	public interface ITwisterHttpClient
	{
		DnsTwisterResponseWrapper GetFuzzyDomains(string domainName);
	}
}