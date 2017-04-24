using SquatFinder.Core.Models;

namespace SquatFinder.Core.Services
{
	public interface ITwisterService
	{
		FuzzyResponseWrapper GetFuzzyDomains(string domain);
	}
}