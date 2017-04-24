using DnsTwisterMonitor.Core.Models;

namespace DnsTwisterMonitor.Core.Services
{
	public interface ITwisterService
	{
		FuzzyResponseWrapper GetFuzzyDomains(string domain);
	}
}