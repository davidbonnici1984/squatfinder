using SquatFinder.Core.Models;

namespace SquatFinder.Core.Http
{
	public interface ITwisterHttpClient
	{
		FuzzyResponseWrapper GetFuzzyDomains(string domainName);
	}
}