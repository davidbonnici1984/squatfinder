using SquatFinder.Web.Core.Models;

namespace SquatFinder.Web.Core.Services
{
	public interface ITwisterService
	{
		FuzzyResponseWrapper GetFuzzyDomains(string domain);
	}
}